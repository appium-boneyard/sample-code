#Node.js samples

## prerequisites

Upgrade Mocha to the latest version:

```
npm install -g -f mocha
```

Install local packages:

```
npm install
```

### to run tests locally

Install appium and start the appium server for your device, please refer to:

- http://appium.io
- https://github.com/appium/appium/blob/master/README.md

### to run tests using Sauce Labs cloud

[Sign up here](https://saucelabs.com/signup/trial)

Configure your environment:

```
export SAUCE_USERNAME=<SAUCE_USERNAME>
export SAUCE_ACCESS_KEY=<SAUCE_ACCESS_KEY>
```

If you also want to use Sauce Connect (secure tunelling):

- [Read the doc here](https://saucelabs.com/docs/connect)
- Install and start the Sauce Connect client 

## running tests

###iOS

####local:

```
mocha ios-simple.js
mocha ios-complex.js
mocha ios-webview.js
mocha ios-actions.js
mocha ios-local-server.js
mocha ios-selenium-webdriver-bridge.js
```

####using Sauce Labs:

```
SAUCE=1 mocha ios-simple.js
SAUCE=1 mocha ios-complex.js
SAUCE=1 mocha ios-webview.js
SAUCE=1 mocha ios-actions.js
SAUCE=1 mocha ios-selenium-webdriver-bridge.js
```

####using Sauce Labs + Sauce Connect:

```
SAUCE=1 mocha ios-local-server.js
```

###Android

####local:

```
mocha android-simple.js
mocha android-complex.js
mocha android-webview.js
mocha android-local-server.js
```

####using Sauce Labs:

```
SAUCE=1 mocha android-simple.js
SAUCE=1 mocha android-complex.js
SAUCE=1 mocha android-webview.js
```

####using Sauce Labs + Sauce Connect

```
SAUCE=1 mocha android-local-server.js
```

###Selendroid

####local:

```
mocha selendroid-simple.js
```

####using Sauce Labs:

```
SAUCE=1 mocha selendroid-simple.js
```

###Node.js 0.11 + Generator with Yiewd

prerequisite: switch to node > 0.11

####local:

```
mocha --harmony ios-yiewd.js
```

####using Sauce Labs:

```
SAUCE=1 mocha --harmony ios-yiewd.js
```
