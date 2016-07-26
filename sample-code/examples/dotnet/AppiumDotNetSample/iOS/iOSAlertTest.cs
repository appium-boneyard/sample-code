using Appium.Samples.Helpers;
using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.iOS;
using OpenQA.Selenium.Remote;
using System;
using System.Threading;

namespace Appium.Samples.iOS
{
    public class iOSAlertTest
    {
        private AppiumDriver<IOSElement> driver;

        [TestFixtureSetUp]
        public void BeforeAll()
        {
            DesiredCapabilities capabilities = Caps.getIos92Caps(Apps.get("iosTestApp"));
            if (Env.isSauce())
            {
                capabilities.SetCapability("username", Env.getEnvVar("SAUCE_USERNAME"));
                capabilities.SetCapability("accessKey", Env.getEnvVar("SAUCE_ACCESS_KEY"));
                capabilities.SetCapability("name", "ios - complex");
                capabilities.SetCapability("tags", new string[] { "sample" });
            }
            Uri serverUri = Env.isSauce() ? AppiumServers.sauceURI : AppiumServers.LocalServiceURIForIOS;
            driver = new IOSDriver<IOSElement>(serverUri, capabilities, Env.INIT_TIMEOUT_SEC);
            driver.Manage().Timeouts().ImplicitlyWait(Env.IMPLICIT_TIMEOUT_SEC);
        }

        [TestFixtureTearDown]
        public void AfterEach()
        {
            if (driver != null)
            {
                driver.Quit();
            }
            if (!Env.isSauce())
            {
                AppiumServers.StopLocalService();
            }
        }

        [Test]
        public void AcceptAlertTest()
        {
            driver.FindElement(new ByIosUIAutomation(".elements().withName(\"show alert\")")).Click();
            Thread.Sleep(10000);
            driver.SwitchTo().Alert().Accept();
        }

        [Test]
        public void DismissAlertTest()
        {
            driver.FindElement(new ByIosUIAutomation(".elements().withName(\"show alert\")")).Click();
            Thread.Sleep(10000);
            driver.SwitchTo().Alert().Dismiss();
        }
    }
}
