using NUnit.Framework;
using System;
using Appium.Samples.Helpers;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;

namespace Appium.Samples.Android
{
	[TestFixture ()]
	public class AndroidSearchingTest
	{
		private AndroidDriver<AndroidElement> driver;

		[TestFixtureSetUp]
		public void BeforeAll(){
			DesiredCapabilities capabilities = Env.isSauce () ? 
				Caps.getAndroid501Caps (Apps.get ("androidApiDemos")) :
				Caps.getAndroid19Caps (Apps.get ("androidApiDemos"));
			if (Env.isSauce ()) {
				capabilities.SetCapability("username", Env.getEnvVar("SAUCE_USERNAME")); 
				capabilities.SetCapability("accessKey", Env.getEnvVar("SAUCE_ACCESS_KEY"));
				capabilities.SetCapability("name", "android - simple");
				capabilities.SetCapability("tags", new string[]{"sample"});
			}
			Uri serverUri = Env.isSauce () ? AppiumServers.sauceURI : AppiumServers.LocalServiceURIAndroid;
            driver = new AndroidDriver<AndroidElement>(serverUri, capabilities, Env.INIT_TIMEOUT_SEC);	
			driver.Manage().Timeouts().ImplicitlyWait(Env.IMPLICIT_TIMEOUT_SEC);
		}

        [SetUp]
        public void SetUp()
        {
            driver.StartActivity("io.appium.android.apis", ".ApiDemos");
        }

		[TestFixtureTearDown]
		public void AfterAll(){
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
        public void FindByAccessibilityIdTest()
        {
            By byAccessibilityId = new ByAccessibilityId("Graphics");
            Assert.AreNotEqual(driver.FindElement(byAccessibilityId).Text, null);
            Assert.GreaterOrEqual(driver.FindElements(byAccessibilityId).Count, 1);
        }

        [Test]
        public void FindByAndroidUIAutomatorTest()
        {
            By byAndroidUIAutomator = new ByAndroidUIAutomator("new UiSelector().clickable(true)");
            Assert.IsNotNull(driver.FindElement(byAndroidUIAutomator).Text);
            Assert.GreaterOrEqual(driver.FindElements(byAndroidUIAutomator).Count, 1);
        }

        [Test]
        public void FindByXPathTest()
        {
            string byXPath = "//android.widget.TextView[contains(@text, 'Animat')]";
            Assert.IsNotNull(driver.FindElementByXPath(byXPath).Text);
            Assert.AreEqual(driver.FindElementsByXPath(byXPath).Count, 1);
        }

        [Test]
        public void FindScrollable()
        {
            driver.FindElementByAccessibilityId("Views").Click();
            AndroidElement radioGroup = driver
                    .FindElementByAndroidUIAutomator("new UiScrollable(new UiSelector()"
                    + ".resourceId(\"android:id/list\")).scrollIntoView("
                    + "new UiSelector().text(\"Radio Group\"));");
            Assert.NotNull(radioGroup.Location);
        }
    }
}

