using NUnit.Framework;
using System;
using Appium.Samples.Helpers;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Interfaces;
using OpenQA.Selenium.Appium.MultiTouch;
using OpenQA.Selenium.Appium.iOS;

namespace Appium.Sampless.iOS
{
    [TestFixture()]
    public class iOSTouchActionTest
    {
        private AppiumDriver<IWebElement> driver;

		[TestFixtureSetUp]
        public void BeforeAll()
        {
            DesiredCapabilities capabilities = Caps.getIos92Caps(Apps.get("iosTestApp"));
            if (Env.isSauce())
            {
                capabilities.SetCapability("username", Env.getEnvVar("SAUCE_USERNAME"));
                capabilities.SetCapability("accessKey", Env.getEnvVar("SAUCE_ACCESS_KEY"));
                capabilities.SetCapability("name", "ios - actions");
                capabilities.SetCapability("tags", new string[] { "sample" });
            }
            Uri serverUri = Env.isSauce() ? AppiumServers.sauceURI : AppiumServers.LocalServiceURIForIOS;
            driver = new IOSDriver<IWebElement>(serverUri, capabilities, Env.INIT_TIMEOUT_SEC);
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
        public void SimpleActionTestCase()
        {
			driver.FindElementById ("TextField1").Clear();
			driver.FindElementById ("TextField1").SendKeys ("1");
			driver.FindElementById ("TextField2").Clear ();
			driver.FindElementById ("TextField2").SendKeys ("3");
            IWebElement el = driver.FindElementByAccessibilityId("ComputeSumButton");
            ITouchAction action = new TouchAction(driver);
            action.Press(el, 10, 10).Release();
            action.Perform();
			const string str = "4";
			Assert.AreEqual (driver.FindElementByXPath ("//*[@name = \"Answer\"]").Text, str);
        }

        [Test()]
        public void MultiActionTestCase()
        {
			driver.FindElementById ("TextField1").Clear();
			driver.FindElementById ("TextField1").SendKeys ("2");
			driver.FindElementById ("TextField2").Clear();
			driver.FindElementById ("TextField2").SendKeys ("4");
            IWebElement el = driver.FindElementByAccessibilityId("ComputeSumButton");
            ITouchAction a1 = new TouchAction(driver);
            a1.Tap(el, 10, 10);
            ITouchAction a2 = new TouchAction(driver);
            a2.Tap(el);
            IMultiAction m = new MultiAction(driver);
            m.Add(a1).Add(a2);
            m.Perform();
			const string str = "6";
			Assert.AreEqual (driver.FindElementByXPath ("//*[@name = \"Answer\"]").Text, str);
        }
    }
}
