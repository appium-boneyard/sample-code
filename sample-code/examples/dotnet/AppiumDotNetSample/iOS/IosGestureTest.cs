using Appium.Samples.Helpers;
using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.iOS;
using OpenQA.Selenium.Remote;
using System;
using System.Drawing;

namespace Appium.Samples.iOS
{
    [TestFixture()]
    class iOSGestureTest
    {
        private AppiumDriver<IOSElement> driver;

        [TestFixtureSetUp]
        public void BeforeAll()
        {
			DesiredCapabilities capabilities = Caps.getIos92Caps(Apps.get("iosTestApp"));
			if (Env.isSauce ())
			{
				capabilities.SetCapability ("username", Env.getEnvVar ("SAUCE_USERNAME"));
				capabilities.SetCapability ("accessKey", Env.getEnvVar ("SAUCE_ACCESS_KEY"));
				capabilities.SetCapability ("name", "ios - complex");
				capabilities.SetCapability ("tags", new string[] { "sample" });
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

		[Test()]
		public void TapTest()
		{

			driver.FindElementById ("IntegerA").SendKeys("2");
			driver.FindElementById ("IntegerB").SendKeys("4");

			IOSElement e = driver.FindElementByAccessibilityId("ComputeSumButton");
			driver.Tap(2, e, 2000);
			const string str = "6";
			Assert.AreEqual (driver.FindElementByXPath ("//*[@name = \"Answer\"]").Text, str);
		}

		[Test()]
		public void ZoomTest()
		{
			IOSElement e = driver.FindElementById ("IntegerA");
			driver.Zoom(e);
		}

        [Test()]
        public void PinchTest()
        {
			IOSElement e = driver.FindElementById ("IntegerA");
            driver.Pinch(e);
        }

		[Test()]
		public void SwipeTest()
		{
			IOSElement slider = driver.FindElementByClassName ("UIASlider");
			Point location = slider.Location;
			Size size = slider.Size;

			driver.Swipe (location.X + size.Width / 2, location.Y + size.Height / 2, location.X - 1, location.Y + size.Height / 2, 3000);
			Assert.AreEqual ("0%", slider.GetAttribute ("value"));
		}
    }
}
