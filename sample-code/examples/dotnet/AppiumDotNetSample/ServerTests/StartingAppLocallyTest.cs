using Appium.Samples.Helpers;
using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.iOS;
using OpenQA.Selenium.Appium.Service;
using OpenQA.Selenium.Appium.Service.Options;
using OpenQA.Selenium.Remote;
using System;

namespace Appium.Samples.ServerTests
{
    class StartingAppLocallyTest
    {
        [Test]
        public void StartingAndroidAppWithCapabilitiesOnlyTest()
        {
            string app = Apps.get("androidApiDemos");
            DesiredCapabilities capabilities =
                Caps.getAndroid19Caps(app);

            AndroidDriver<AppiumWebElement> driver = null;
            try
            {
                driver = new AndroidDriver<AppiumWebElement>(capabilities);
                driver.CloseApp();
            }
            finally
            {
                if (driver != null)
                {
                    driver.Quit();
                }
            }
        }

        [Test]
        public void StartingAndroidAppWithCapabilitiesAndServiceTest()
        {

            DesiredCapabilities capabilities = Env.isSauce() ?
                Caps.getAndroid501Caps(Apps.get("androidApiDemos")) :
                Caps.getAndroid19Caps(Apps.get("androidApiDemos"));


            OptionCollector argCollector = new OptionCollector()
                .AddArguments(GeneralOptionList.OverrideSession()).AddArguments(GeneralOptionList.StrictCaps());
            AppiumServiceBuilder builder = new AppiumServiceBuilder().WithArguments(argCollector);

            AndroidDriver<AppiumWebElement> driver = null;
            try
            {
                driver = new AndroidDriver<AppiumWebElement>(builder, capabilities);
                driver.CloseApp();
            }
            finally
            {
                if (driver != null)
                {
                    driver.Quit();
                }
            }
        }


        [Test]
        public void StartingAndroidAppWithCapabilitiesOnTheServerSideTest()
        {
            string app = Apps.get("androidApiDemos");

            DesiredCapabilities serverCapabilities = Env.isSauce() ?
                Caps.getAndroid501Caps(Apps.get("androidApiDemos")) :
                Caps.getAndroid19Caps(Apps.get("androidApiDemos"));

            DesiredCapabilities clientCapabilities = new DesiredCapabilities();
            clientCapabilities.SetCapability(AndroidMobileCapabilityType.AppPackage, "io.appium.android.apis");
            clientCapabilities.SetCapability(AndroidMobileCapabilityType.AppActivity, ".view.WebView1");

            OptionCollector argCollector = new OptionCollector().AddCapabilities(serverCapabilities);
            AppiumServiceBuilder builder = new AppiumServiceBuilder().WithArguments(argCollector);

            AndroidDriver<AppiumWebElement> driver = null;
            try
            {
                driver = new AndroidDriver<AppiumWebElement>(builder, clientCapabilities);
                driver.CloseApp();
            }
            finally
            {
                if (driver != null)
                {
                    driver.Quit();
                }
            }
        }

        [Test]
        public void StartingIOSAppWithCapabilitiesOnlyTest()
        {
            string app = Apps.get("iosTestApp");
            DesiredCapabilities capabilities =
                Caps.getIos92Caps(app);

            IOSDriver<AppiumWebElement> driver = null;
            try
            {
				driver = new IOSDriver<AppiumWebElement>(capabilities, Env.INIT_TIMEOUT_SEC);
                driver.CloseApp();
            }
            finally
            {
                if (driver != null)
                {
                    driver.Quit();
                }
            }
        }

        [Test]
        public void StartingIOSAppWithCapabilitiesAndServiseTest()
        {
            string app = Apps.get("iosTestApp");
            DesiredCapabilities capabilities =
                Caps.getIos92Caps(app);

            OptionCollector argCollector = new OptionCollector()
                .AddArguments(GeneralOptionList.OverrideSession()).AddArguments(GeneralOptionList.StrictCaps());

            AppiumServiceBuilder builder = new AppiumServiceBuilder().WithArguments(argCollector);
            IOSDriver<AppiumWebElement> driver = null;
            try
            {
				driver = new IOSDriver<AppiumWebElement>(builder, capabilities, Env.INIT_TIMEOUT_SEC);
                driver.CloseApp();
            }
            finally
            {
                if (driver != null)
                {
                    driver.Quit();
                }
            }
        }

        [Test]
        public void CheckThatServiseIsNotRunWhenTheCreatingOfANewSessionIsFailed()
        {
            DesiredCapabilities capabilities = Env.isSauce() ?   //it will be a cause of error
                Caps.getAndroid501Caps(Apps.get("androidApiDemos")) :
                Caps.getAndroid19Caps(Apps.get("androidApiDemos"));
            capabilities.SetCapability(MobileCapabilityType.DeviceName, "iPhone Simulator");
            capabilities.SetCapability(MobileCapabilityType.PlatformName, MobilePlatform.IOS);

            AppiumServiceBuilder builder = new AppiumServiceBuilder();
            AppiumLocalService service = builder.Build();
            service.Start();

            IOSDriver<AppiumWebElement> driver = null;
            try
            {
                try
                {
					driver = new IOSDriver<AppiumWebElement>(service, capabilities);
                }
                catch (Exception e)
                {
                    Assert.IsTrue(!service.IsRunning);
                    return;
                }
                throw new Exception("Any exception was expected");
            }
            finally
            {
                if (driver != null)
                {
                    driver.Quit();
                }
            }
        }
    }
}
