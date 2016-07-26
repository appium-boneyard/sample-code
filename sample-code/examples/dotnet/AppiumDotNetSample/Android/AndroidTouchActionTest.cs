using NUnit.Framework;
using System;
using Appium.Samples.Helpers;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Remote;
using System.Collections.Generic;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.MultiTouch;
using System.Threading;

namespace Appium.Samples.Android
{
	[TestFixture ()]
	public class AndroidTouchActionTest
	{
		private AndroidDriver<AppiumWebElement> driver;

		[TestFixtureSetUp]
		public void BeforeAll(){
			DesiredCapabilities capabilities = Env.isSauce () ? 
				Caps.getAndroid501Caps (Apps.get ("androidApiDemos")) :
				Caps.getAndroid19Caps (Apps.get ("androidApiDemos"));
			if (Env.isSauce ()) {
				capabilities.SetCapability("username", Env.getEnvVar("SAUCE_USERNAME")); 
				capabilities.SetCapability("accessKey", Env.getEnvVar("SAUCE_ACCESS_KEY"));
				capabilities.SetCapability("name", "android - complex");
				capabilities.SetCapability("tags", new string[]{"sample"});
			}
			Uri serverUri = Env.isSauce () ? AppiumServers.sauceURI : AppiumServers.LocalServiceURIAndroid;
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
        public void SimpleTouchActionTestCase()
        {
            IList<AppiumWebElement> els = driver.FindElementsByClassName("android.widget.TextView");

            int number1 = els.Count;

            TouchAction tap = new TouchAction(driver);
            tap.Tap(els[4], 10, 5, 2).Perform();

            els = driver.FindElementsByClassName("android.widget.TextView");

            Assert.AreNotEqual(number1, els.Count);
        }

        [Test ()]
		public void ComplexTouchActionTestCase ()
		{
			IList<AppiumWebElement> els = driver.FindElementsByClassName ("android.widget.TextView");
			var loc1 = els [7].Location;
            AppiumWebElement target = els[1];
            var loc2 = target.Location;
			driver.Swipe (loc1.X, loc1.Y, loc2.X, loc2.Y, 800); //this action includes almost all touch actions
            Assert.AreNotEqual(loc2.Y, target.Location.Y);
		}

        [Test()]
        public void SingleMultiActionTestCase()
        {
            IList<AppiumWebElement> els = driver.FindElementsByClassName("android.widget.TextView");
            var loc1 = els[7].Location;
            AppiumWebElement target = els[1];
            var loc2 = target.Location;

            TouchAction swipe = new TouchAction(driver);

            swipe.Press(loc1.X, loc1.Y).Wait(1000)
                    .MoveTo(loc2.X, loc2.Y).Release();

            MultiAction multiAction = new MultiAction(driver);
            multiAction.Add(swipe).Perform();
            Assert.AreNotEqual(loc2.Y, target.Location.Y);
        }

        [Test()]
        public void SequentalMultiActionTestCase()
        {
            string originalActivity = driver.CurrentActivity;
            IList<AppiumWebElement> els = driver.FindElementsByClassName("android.widget.TextView");
            MultiAction multiTouch = new MultiAction(driver);

            TouchAction tap1 = new TouchAction(driver);
            tap1.Press(els[5]).Wait(1500).Release();

            multiTouch.Add(tap1).Add(tap1).Perform();

            Thread.Sleep(2500);
            els = driver.FindElementsByClassName("android.widget.TextView");

            TouchAction tap2 = new TouchAction(driver);
            tap2.Press(els[1]).Wait(1500).Release();

            MultiAction multiTouch2 = new MultiAction(driver);
            multiTouch2.Add(tap2).Add(tap2).Perform();

            Thread.Sleep(2500);
            Assert.AreNotEqual(originalActivity, driver.CurrentActivity);
        }

    }
}

