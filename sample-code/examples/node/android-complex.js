"use strict";

require("./helpers/setup");

var wd = require("wd"),
    _ = require('underscore'),
    actions = require("./helpers/actions"),
    serverConfigs = require('./helpers/appium-servers'),
    _p = require('./helpers/promise-utils'),
    Q = require('q');

wd.addPromiseChainMethod('swipe', actions.swipe);

describe("android complex", function () {
  this.timeout(300000);
  var driver;
  var allPassed = true;

  before(function () {
    var serverConfig = process.env.SAUCE ?
      serverConfigs.sauce : serverConfigs.local;
    driver = wd.promiseChainRemote(serverConfig);
    require("./helpers/logging").configure(driver);

    var desired = process.env.SAUCE ?
      _.clone(require("./helpers/caps").android18) :
      _.clone(require("./helpers/caps").android19);
    desired.app = require("./helpers/apps").androidApiDemos;
    if (process.env.SAUCE) {
      desired.name = 'android - complex';
      desired.tags = ['sample'];
    }
    return driver
      .init(desired)
      .setImplicitWaitTimeout(5000);
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

  it("should scroll down", function () {
    return driver.getWindowSize()
      .then(function(size){
        var center = {
          x:  size.width / 2,
          y:  size.height / 2
        };
        return driver.swipe({
          startX: center.x, startY: center.y,
          endX: center.x, endY: 100,
          duration: 800
        });
      });
  });

  it("should scroll with an element", function () {
    return driver
      .elementByXPath('//android.widget.TextView[@text=\'Animation\']')
      .elementsByXPath('//android.widget.TextView')
      .then(function (els) {
        return Q.all([
          els[7].getLocation(),
          els[3].getLocation()
        ]).then(function (locs) {
          console.log('locs -->', locs);
          return driver.swipe({
            startX: locs[0].x, startY: locs[0].y,
            endX: locs[1].x, endY: locs[1].y,
            duration: 800
          });
        });
      });
  });
});
