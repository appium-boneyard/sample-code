"use strict";

require("./helpers/setup");

var wd = require("wd"),
    _ = require('underscore'),
    serverConfigs = require('./helpers/appium-servers');

describe("ios webview", function () {
  this.timeout(300000);
  var driver;
  var allPassed = true;

  before(function () {
    var serverConfig = process.env.npm_package_config_sauce ?
      serverConfigs.sauce : serverConfigs.local;
    driver = wd.promiseChainRemote(serverConfig);
    require("./helpers/logging").configure(driver);

    var desired = _.clone(require("./helpers/caps").ios81);
    desired.app = require("./helpers/apps").iosWebviewApp;
    if (process.env.npm_package_config_sauce) {
      desired.name = 'ios - webview';
      desired.tags = ['sample'];
    }
    return driver.init(desired);
  });

  after(function () {
    return driver
      .quit()
      .finally(function () {
        if (process.env.npm_package_config_sauce) {
          return driver.sauceJobStatus(allPassed);
        }
      });
  });

  afterEach(function () {
    allPassed = allPassed && this.currentTest.state === 'passed';
  });


  it("should get the url", function () {
    return driver
      .elementByXPath('//UIATextField[@value=\'Enter URL\']')
        .sendKeys('www.google.com')
      .elementByName('Go').click()
      .sleep(20000)
      .source().then(console.log)
      .elementByClassName('UIAWebView').click() // dismissing keyboard
      .sleep(10000)
      .context('WEBVIEW')
      .sleep(1000)
      .waitForElementByName('q', 5000)
        .sendKeys('sauce labs')
        .sendKeys(wd.SPECIAL_KEYS.Return)
      .sleep(1000)
      .title().should.eventually.include('sauce labs');
  });

});
