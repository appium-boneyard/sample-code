"use strict";

require("./helpers/setup");

var wd = require("wd"),
    _ = require('underscore'),
    actions = require("./helpers/actions"),
    serverConfigs = require('./helpers/appium-servers');

wd.addPromiseChainMethod('swipe', actions.swipe);
wd.addPromiseChainMethod('pinch', actions.pinch);
wd.addElementPromiseChainMethod('pinch',
  function () { return this.browser.pinch(this); });
wd.addPromiseChainMethod('zoom', actions.zoom);
wd.addElementPromiseChainMethod('zoom',
  function () { return this.browser.zoom(this); });

describe("ios actions", function () {
  this.timeout(300000);
  var driver;
  var allPassed = true;

  beforeEach(function () {
    var serverConfig = process.env.npm_package_config_sauce ?
      serverConfigs.sauce : serverConfigs.local;
    driver = wd.promiseChainRemote(serverConfig);
    require("./helpers/logging").configure(driver);

    var desired = _.clone(require("./helpers/caps").ios81);
    desired.app = require("./helpers/apps").iosTestApp;
    if (process.env.npm_package_config_sauce) {
      desired.name = 'ios - actions';
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

  it("should execute a simple action", function () {
    return driver.chain()
      .elementByAccessibilityId('ComputeSumButton')
      .then(function (el) {
        var action = new wd.TouchAction(driver);
        action
          .tap({el: el, x: 10, y: 10});
        return driver.performTouchAction(action);
      })
      .elementByAccessibilityId('ComputeSumButton')
      .then(function (el) {
        var action = new wd.TouchAction(driver);
        action
          .tap({el: el, x: 10, y: 10});
        return action.perform();
      });
  });

  // TODO: MultiAction not yet implemented. Re-enable this test when they are.
  xit("should execute a multi action", function () {
    return driver.chain()
      .then(function () {
        return driver
          .elementByAccessibilityId('ComputeSumButton')
          .then(function (el) {
            var a1 = new wd.TouchAction();
            a1
              .tap({el: el, x: 10, y: 10});
            var a2 = new wd.TouchAction();
            a2
              .tap({el: el});
            var m = new wd.MultiAction();
            m.add(a1, a2);
            return driver.performMultiAction(m);
          });
      })
      .then(function () {
        return driver
          .elementByAccessibilityId('ComputeSumButton')
          .then(function (el) {
            var a1 = new wd.TouchAction();
            a1
              .tap({el: el, x: 10, y: 10});
            var a2 = new wd.TouchAction();
            a2
              .tap({el: el});
            var m = new wd.MultiAction(driver);
            m.add(a1, a2);
            return m.perform();
          });
      });
  });

  it("should swipe", function () {
    return driver
      .waitForElementByName('Test Gesture', 5000).click()
      .sleep(3000)
      .elementByName('Allow').click()
      .sleep(3000)
      .elementByXPath('//XCUIElementTypeMap').getLocation()
      .then(function (loc) {
        return driver.swipe({ startX: loc.x, startY: loc.y,
          endX: 0.5,  endY: loc.y, duration: 800 });
      });
  });

  // TODO: MultiAction not yet implemented. Re-enable this test when they are.
  xit("should pinch", function () {
    return driver
      .waitForElementByName('Test Gesture', 5000).click()
      .sleep(3000)
      .elementByName('Allow').click()
      .sleep(3000)
      .elementByXPath('//XCUIElementTypeMap')
      .then(function (el) {
        return driver.pinch(el);
      });
  });

  // TODO: MultiAction not yet implemented. Re-enable this test when they are.
  xit("should pinch el", function () {
    return driver
      .waitForElementByName('Test Gesture', 5000).click()
      .sleep(2000)
      .elementByName('Allow').click()
      .sleep(1000)
      .elementByXPath('//XCUIElementTypeMap')
      .then(function (el) {
        return el.pinch();
      });
  });

  xit("should zoom", function () {
    return driver
      .waitForElementByName('Test Gesture', 5000).click()
      .sleep(3000)
      .elementByName('Allow').click()
      .sleep(3000)
      .elementByXPath('//XCUIElementTypeMap')
      .then(function (el) {
        return driver.zoom(el);
      });
  });

  xit("should zoom el", function () {
    return driver
      .waitForElementByName('Test Gesture', 5000).click()
      .sleep(3000)
      .elementByName('Allow').click()
      .sleep(1000)
      .elementByXPath('//XCUIElementTypeMap')
      .then(function (el) {
        return el.zoom();
      });
  });

});
