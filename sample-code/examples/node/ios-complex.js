"use strict";

require("./helpers/setup");

var wd = require("wd"),
    _ = require('underscore'),
    Q = require('q'),
    serverConfigs = require('./helpers/appium-servers'),
    _p = require('./helpers/promise-utils'),
    fs = require('fs');

describe("ios complex", function () {
  this.timeout(300000);
  var driver;
  var allPassed = true;

  before(function () {
    var serverConfig = process.env.npm_package_config_sauce ?
      serverConfigs.sauce : serverConfigs.local;
    driver = wd.promiseChainRemote(serverConfig);
    require("./helpers/logging").configure(driver);

    var desired = _.clone(require("./helpers/caps").ios81);
    desired.app = require("./helpers/apps").iosUICatalogApp;
    if (process.env.npm_package_config_sauce) {
      desired.name = 'ios - complex';
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

  function clickMenuItem(name) {
    return driver
      .elementByName(name)
      .catch(function () {
        return driver
          .elementByClassName('XCUIElementTypeTable')
          .elementsByClassName('>','XCUIElementTypeCell')
          .then(_p.filterWithName(name)).first();
      }).click();
  }

  function goBack() {
    return driver
      .elementByName('Back')
      .click();
  }

  it("should print every menu item", function () {
    return driver
      .elementByClassName('XCUIElementTypeTable')
      .elementsByClassName('>','XCUIElementTypeCell')
      .then(_p.printNames);
  });

  it("should find an element", function () {
    return driver
      // first view in UICatalog is a table
      .elementByClassName('XCUIElementTypeTable')
        .should.eventually.exist
      // check the number of cells/rows inside the  table
      .elementsByClassName('XCUIElementTypeCell')
        .then(_p.filterDisplayed)
      .then(function (els) {
        els.should.have.length.above(6);
        return els;
      })
      .first()
      .elementsByClassName('>', 'XCUIElementTypeStaticText')
      // various checks
      .first().getAttribute('value')
        .should.become('Action Sheets')
      .waitForElementByClassName('XCUIElementTypeNavigationBar')
        .should.eventually.exist;
  });

  it("should switch context", function () {
    return clickMenuItem('Web View')
      .sleep(1000)

      // get the contexts
      .contexts()
      .then(function(contexts){
        // switch to webview
        return driver.context(contexts[1]);          
      })
      .sleep(1000)
      
      // Wait for an element from apple.com homepage to be present
      .waitForElementById('ac-globalnav')
        .should.eventually.exist

      // leave the webview  
      .context('NATIVE_APP').sleep(1000)
      
      //Verify we are out of the webview
      .waitForElementByClassName('XCUIElementTypeWindow')
        .should.eventually.exist
      .then(goBack)
  });

  it("should get an element location", function () {
    return driver.elementsByClassName("XCUIElementTypeCell")
      .then(_p.filterDisplayed)
      .at(2)
      .getLocation()
      .then(function (loc) {
        loc.x.should.equal(0);
        loc.y.should.be.above(100);
      });
  });

  it("should take screenshots", function () {
    return driver
      // base64 screeshot
      .takeScreenshot()
        .should.eventually.exist
      // save screenshot to local file
      .then(function () {
        try {
          fs.unlinkSync('/tmp/foo.png');
        } catch (ign) {}
        fs.existsSync('/tmp/foo.png').should.not.be.ok;
      })
      .saveScreenshot('/tmp/foo.png')
      .then(function () {
        fs.existsSync('/tmp/foo.png').should.be.ok;
      });

  });

  it("should edit a text field", function () {
    var el, defaultValue;
    return clickMenuItem('Text Fields')
      // get the field and the default/empty text
      .elementByClassName('XCUIElementTypeTextField')
        .then(function (_el) {
          el = _el;
          return el.getValue(); })
      .then(function (val) { defaultValue = val; })
      // type something
      .then(function () {
          return el
            .sendKeys('1234 appium')
            .getValue().should.become('1234 appium')
            .elementByName('Done').click().sleep(1000); // dismissing keyboard
      })
      // clear the field
      .then(function () { return el.clear(); })
      .then(function () { el.getValue().should.become(defaultValue); })
      // back to main menu
      .then(goBack);
  });

  it("should trigger/accept/dismiss an alert", function () {
    return clickMenuItem('Alert Views')
      // trigger simple alert
      .elementByName('Simple').click()
      .alertText().should.eventually.include('A Short Title Is Best')
      .dismissAlert()
      // trigger modal alert with cancel & ok buttons
      .sleep(1000)
      .elementByName('Okay / Cancel').click()
      .alertText().should.eventually.include('A Short Title Is Best')
      .acceptAlert()
      .sleep(1000)
      // back to main menu
      .then(goBack);
  });

  // TODO: Waiting to hear back from Facebook to see if WebDriverAgent supports programatically setting sliders.
  // (see issue: https://github.com/facebook/WebDriverAgent/issues/339)
  /*it("should set a slider value", function () {
    var slider;
    return clickMenuItem('Sliders')
      // retrieve slider, check initial value
      .elementByClassName("UIASlider")
      .then(function (_slider) { slider = _slider; })
      .then(function () {
        return slider.getValue().should.become('42%');
      })
      // change value
      .then(function () { return slider.sendKeys("0%"); })
      .then(function () {
        return slider.getValue().should.become('0%');
      })
      // back to main menu
      .then(goBack);
  });*/

  if (!process.env.npm_package_config_sauce) {
    it("should retrieve the session list", function () {
      driver.sessions()
      .then(function (sessions) {
        JSON.stringify(sessions).should.include(driver.getSessionId());
      });
    });
  }

  it("should retrieve an element size", function () {
    return Q.all([
      driver.elementByClassName('XCUIElementTypeTable').getSize(),
      driver.elementByClassName('XCUIElementTypeCell').getSize(),
    ]).then(function (sizes) {
      sizes[0].width.should.equal(sizes[1].width);
      sizes[0].height.should.not.equal(sizes[1].height);
    });
  });

  it("should get the source", function () {
    var mainMenuSource;
    // main menu source
    return driver
      .source().then(function (source) {
        mainMenuSource = source;
        mainMenuSource.should.include('XCUIElementTypeStaticText');
        mainMenuSource.should.include('Text Fields');
      })
      // text fields section source
      .then(function () {
        return clickMenuItem("Text Fields");
      }).source().then(function (textFieldSectionSource) {
        textFieldSectionSource.should.include('XCUIElementTypeStaticText');
        textFieldSectionSource.should.include('Text Fields');
      })
      // back to main menu
      .then(goBack);
  });
});
