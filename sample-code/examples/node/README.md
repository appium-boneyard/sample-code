# Node.js samples

## Prerequisites

Install local packages:

```
npm install
```

### To run tests using Sauce Labs cloud

[Sign up here](https://saucelabs.com/signup/trial)

Then when running the tests, add your Sauce Labs credentials as npm config parameters, example :

```
npm run ios-simple --appium-sample-code:sauce=1 --appium-sample-code:username=<SAUCE_USERNAME> --appium-sample-code:key=<SAUCE_ACCESS_KEY>

```

Or set the config parameters directly in package.json :

```
// package.json

...
"config":{
  "sauce":"1",
  "sauce_username":"<SAUCE_USERNAME>",
  "sauce_access_key":"<SAUCE_ACCESS_KEY>"
},
...
```

If you also want to use Sauce Connect (secure tunelling):

- [Read the doc here](https://saucelabs.com/docs/connect)
- Install and start the Sauce Connect client


### To run tests locally

Install appium and start the appium server for your device, please refer to:

- http://appium.io
- https://github.com/appium/appium/blob/master/README.md

## Running tests

### iOS

```
npm run ios-simple
npm run ios-complex
npm run ios-webview
npm run ios-actions
npm run ios-local-server
npm run ios-selenium-webdriver-bridge
```

### Android

```
npm run android-simple
npm run android-complex
npm run android-webview
npm run android-local-server
```

### Selendroid

```
npm run selendroid-simple
```

### Node.js 0.11 + Generator with Yiewd

prerequisite: switch to node > 0.11

```
npm run ios-yiewd
```
