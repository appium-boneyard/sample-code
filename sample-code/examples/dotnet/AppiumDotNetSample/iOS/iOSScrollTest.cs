using Appium.Samples.Helpers;
using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.iOS;
using OpenQA.Selenium.Remote;
using System;

namespace Appium.Samples.iOS
{
    public class iOSScrollTest
    {
        private IOSDriver<AppiumWebElement> driver;

        [TestFixtureSetUp]
        public void beforeAll()
        {
            DesiredCapabilities capabilities = Caps.getIos82Caps(Apps.get("iosUICatalogApp"));
            if (Env.isSauce())
            {
                capabilities.SetCapability("username", Env.getEnvVar("SAUCE_USERNAME"));
                capabilities.SetCapability("accessKey", Env.getEnvVar("SAUCE_ACCESS_KEY"));
                capabilities.SetCapability("name", "ios - complex");
                capabilities.SetCapability("tags", new string[] { "sample" });
            }
            Uri serverUri = Env.isSauce() ? AppiumServers.sauceURI : AppiumServers.LocalServiceURIForIOS;
            driver = new IOSDriver<AppiumWebElement>(serverUri, capabilities, Env.INIT_TIMEOUT_SEC);
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

        [Test()]
        public void ScrollToTestCase()
        {
            Assert.AreEqual(driver.ScrollTo("Slider").GetAttribute("name"), "Sliders");
        }

        [Test()]
        public void ScrollToExactTestCase()
        {
            Assert.NotNull(driver.ScrollToExact("Sliders"));
        }
    }
}
