"use strict";

require("./helpers/setup");

var wd = require("wd"),
    _ = require('underscore'),
    serverConfigs = require('./helpers/appium-servers');

describe("ios safari", function () {
  this.timeout(300000);
  var driver;
  var allPassed = true;

  before(function () {
    var serverConfig = process.env.SAUCE ?
      serverConfigs.sauce : serverConfigs.local;
    driver = wd.promiseChainRemote(serverConfig);
    require("./helpers/logging").configure(driver);

    var desired = _.clone(require("./helpers/caps").ios81);
    desired.browserName = 'safari';
    if (process.env.SAUCE) {
      desired.name = 'ios - safari';
      desired.tags = ['sample'];
    }
    return driver.init(desired);
  });

  after(function () {
    return driver
      .quit()
      .finally(function () {
        if (process.env.SAUCE) {
          return driver.sauceJobStatus(allPassed);
        }
      });
  });

  afterEach(function () {
    allPassed = allPassed && this.currentTest.state === 'passed';
  });


  it("should get the url", function () {
    return driver
      .get('https://www.google.com')
      .sleep(1000)
      .waitForElementByName('q', 5000)
        .sendKeys('sauce labs')
        .sendKeys(wd.SPECIAL_KEYS.Return)
      .sleep(1000)
      .title().should.eventually.include('sauce labs');
  });

  it("should delete cookie passing domain and path", function () {
    var complexCookieDelete = function(name, path, domain) {
      return function() {
        path = path || '|';
        return driver.setCookie({name: name, value: '', path: path, 
          domain: domain, expiry: 0});        
      };
    };

    return driver
      .get('http://en.wikipedia.org')
      .waitForElementByCss('.mediawiki', 5000)
      .allCookies() // 'GeoIP' cookie is there
      .deleteCookie('GeoIP') 
      .allCookies() // 'GeoIP' is still there, because it is set on
                    // the .wikipedia.org domain
      .then(complexCookieDelete('GeoIP', '/', '.wikipedia.org'))
      .allCookies() // now 'GeoIP' cookie is gone
      .sleep(1000);
  });

});
