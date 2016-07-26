using Appium.Samples.Helpers;
using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Remote;
using System;

namespace Appium.Samples.Android
{
    [TestFixture]
    public class AndroidActivityTest
    {
        private AndroidDriver<AppiumWebElement> driver;

        [TestFixtureSetUp]
        public void BeforeAll()
        {
            DesiredCapabilities capabilities = Env.isSauce() ?
                Caps.getAndroid501Caps(Apps.get("androidApiDemos")) :
                Caps.getAndroid19Caps(Apps.get("androidApiDemos"));
            if (Env.isSauce())
            {
                capabilities.SetCapability("username", Env.getEnvVar("SAUCE_USERNAME"));
                capabilities.SetCapability("accessKey", Env.getEnvVar("SAUCE_ACCESS_KEY"));
                capabilities.SetCapability("name", "android - complex");
                capabilities.SetCapability("tags", new string[] { "sample" });
            }
            Uri serverUri = Env.isSauce() ? AppiumServers.sauceURI : AppiumServers.LocalServiceURIAndroid;
            driver = new AndroidDriver<AppiumWebElement>(serverUri, capabilities, Env.INIT_TIMEOUT_SEC);
            driver.Manage().Timeouts().ImplicitlyWait(Env.IMPLICIT_TIMEOUT_SEC);
            driver.CloseApp();
        }

        [SetUp]
        public void SetUp()
        {
            if (driver != null)
            {
                driver.LaunchApp();
            }
        }

        [TearDown]
        public void TearDowwn()
        {
            if (driver != null)
            {
                driver.CloseApp();
            }
        }

        [Test]
        public void StartActivityInThisAppTestCase()
        {
            driver.StartActivity("io.appium.android.apis", ".ApiDemos");

            Assert.AreEqual(driver.CurrentActivity, ".ApiDemos");

            driver.StartActivity("io.appium.android.apis", ".accessibility.AccessibilityNodeProviderActivity");

            Assert.AreEqual(driver.CurrentActivity, ".accessibility.AccessibilityNodeProviderActivity");
        }

        [Test]
        public void StartActivityWithWaitingAppTestCase()
        {
            driver.StartActivity("io.appium.android.apis", ".ApiDemos", "io.appium.android.apis", ".ApiDemos");

            Assert.AreEqual(driver.CurrentActivity, ".ApiDemos");

            driver.StartActivity("io.appium.android.apis", ".accessibility.AccessibilityNodeProviderActivity", 
                "io.appium.android.apis", ".accessibility.AccessibilityNodeProviderActivity");

            Assert.AreEqual(driver.CurrentActivity, ".accessibility.AccessibilityNodeProviderActivity");
        }

        [Test]
        public void StartActivityInNewAppTestCase()
        {
            driver.StartActivity("io.appium.android.apis", ".ApiDemos");

            Assert.AreEqual(driver.CurrentActivity, ".ApiDemos");

            driver.StartActivity("com.android.contacts", ".ContactsListActivity");

            Assert.AreEqual(driver.CurrentActivity, ".ContactsListActivity");
            driver.PressKeyCode(AndroidKeyCode.Back);
            Assert.AreEqual(driver.CurrentActivity, ".ContactsListActivity");
        }

        [Test]
        public void StartActivityInNewAppTestCaseWithoutClosingApp()
        {
            driver.StartActivity("io.appium.android.apis", ".accessibility.AccessibilityNodeProviderActivity");

            Assert.AreEqual(driver.CurrentActivity, ".accessibility.AccessibilityNodeProviderActivity");

            driver.StartActivity("com.android.contacts", ".ContactsListActivity", "com.android.contacts", ".ContactsListActivity", false);

            Assert.AreEqual(driver.CurrentActivity, ".ContactsListActivity");
            driver.PressKeyCode(AndroidKeyCode.Back);
            Assert.AreEqual(driver.CurrentActivity, ".accessibility.AccessibilityNodeProviderActivity");

        }

        [TestFixtureTearDown]
        public void AfterAll()
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
    }
}
