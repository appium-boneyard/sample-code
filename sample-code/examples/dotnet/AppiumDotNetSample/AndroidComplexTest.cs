using NUnit.Framework;
using System;
using Appium.Samples.Helpers;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Remote;
using System.Collections.Generic;
using OpenQA.Selenium;
using System.Threading;
using System.Drawing;
using System.Collections;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.MultiTouch;
using OpenQA.Selenium.Appium.Interfaces;
using System.Diagnostics.Contracts;
using System.Diagnostics;

namespace Appium.Samples
{
	[TestFixture ()]
	public class AndroidComplexTest
	{
		private AndroidDriver<AppiumWebElement> driver;
		private bool allPassed = true;

		[SetUp]
		public void BeforeAll(){
			DesiredCapabilities capabilities = Env.isSauce () ? 
				Caps.getAndroid18Caps (Apps.get ("androidApiDemos")) :
				Caps.getAndroid19Caps (Apps.get ("androidApiDemos"));
			if (Env.isSauce ()) {
				capabilities.SetCapability("username", Env.getEnvVar("SAUCE_USERNAME")); 
				capabilities.SetCapability("accessKey", Env.getEnvVar("SAUCE_ACCESS_KEY"));
				capabilities.SetCapability("name", "android - complex");
				capabilities.SetCapability("tags", new string[]{"sample"});
			}
			Uri serverUri = Env.isSauce () ? AppiumServers.sauceURI : AppiumServers.localURI;
            driver = new AndroidDriver<AppiumWebElement>(serverUri, capabilities, Env.INIT_TIMEOUT_SEC);	
			driver.Manage().Timeouts().ImplicitlyWait(Env.IMPLICIT_TIMEOUT_SEC);
		}

		[TearDown]
		public void AfterEach(){
			allPassed = allPassed && (TestContext.CurrentContext.Result.State == TestState.Success);
            if (Env.isSauce())
                ((IJavaScriptExecutor)driver).ExecuteScript("sauce:job-result=" + (allPassed ? "passed" : "failed"));
            driver.Quit();
		}

		[Test ()]
		public void FindElementTestCase ()
		{
			driver.FindElementByXPath ("//android.widget.TextView[@text='Animation']");
			Assert.AreEqual( driver.FindElementByXPath ("//android.widget.TextView").Text,
				"API Demos");
			IList<AppiumWebElement> els = driver.FindElementsByXPath ("//android.widget.TextView[contains(@text, 'Animat')]");
            var elsres = Filters.FilterDisplayed<AppiumWebElement>(els);
			if (!Env.isSauce ()) {
				Assert.AreEqual (elsres [0].Text, "Animation");
			}
			driver.FindElementByName ("App").Click();
			Thread.Sleep (3000);
            els = driver.FindElementsByAndroidUIAutomator("new UiSelector().clickable(true)");
			Assert.GreaterOrEqual (els.Count, 10);
			Assert.IsNotNull (
				driver.FindElementByXPath("//android.widget.TextView[@text='Action Bar']"));
			els = driver.FindElementsByXPath ("//android.widget.TextView");
            elsres = Filters.FilterDisplayed<AppiumWebElement>(els);
            Assert.AreEqual(elsres[0].Text, "API Demos");
			driver.Navigate ().Back ();
		}

		[Test]
		public void StartActivityInThisAppTestCase()
		{
            driver.StartActivity("io.appium.android.apis", ".ApiDemos");

			_AssertActivityNameContains("Demos");

            driver.StartActivity("io.appium.android.apis", ".accessibility.AccessibilityNodeProviderActivity");

			_AssertActivityNameContains("Node");
		}
		
		[Test]
		public void StartActivityInNewAppTestCase()
		{
            driver.StartActivity("io.appium.android.apis", ".ApiDemos");

			_AssertActivityNameContains("Demos");

            driver.StartActivity("com.android.contacts", ".ContactsListActivity");

			_AssertActivityNameContains("Contact");
		}

		private void _AssertActivityNameContains(string activityName)
		{
			Contract.Requires(!String.IsNullOrWhiteSpace(activityName));

            String activity = driver.CurrentActivity;
			Debug.WriteLine (activity);

			Assert.IsNotNullOrEmpty(activity);
			Assert.IsTrue(activity.Contains(activityName));
		}

		[Test ()]
		public void ScrollTestCase ()
		{
			driver.FindElementByXPath (".//android.widget.TextView[@text='Animation']");
			IList<AppiumWebElement> els = driver.FindElementsByXPath (".//android.widget.TextView");
			var loc1 = els [7].Location;
			var loc2 = els [3].Location;
			var swipe = Actions.Swipe (driver, loc1.X, loc1.Y, loc2.X, loc2.Y, 800);
			swipe.Perform ();
		}
			
		private IWebElement FindTouchPaint(){
			try {
				return driver.FindElementByName ("Touch Paint");								
			} catch (NoSuchElementException) {
				var els = driver.FindElementsByClassName ("android.widget.TextView");
				var loc1 = els [els.Count - 1].Location;
				var loc2 = els [0].Location;
				var swipe = Actions.Swipe (driver, loc1.X, loc1.Y, loc2.X, loc2.Y, 800);
				swipe.Perform ();
				return FindTouchPaint ();
			}
		}

		[Test ()]
		public void DrawSmileyTestCase ()
		{
			driver.FindElementByName ("Graphics").Click ();
			var el = FindTouchPaint ();
			el.Click ();
			Thread.Sleep (5000);
			ITouchAction a1 = new TouchAction ();
			a1.Press (140, 100).Release ();
			ITouchAction a2 = new TouchAction ();
			a2.Press (250, 100).Release ();
			ITouchAction smile = new TouchAction ();
			smile
				.Press (110, 200)
				.MoveTo(1, 1)
				.MoveTo(1, 1)
				.MoveTo(1, 1)
				.MoveTo(1, 1)
				.MoveTo(1, 1)
				.MoveTo(2, 1)
				.MoveTo(2, 1)
				.MoveTo(2, 1)
				.MoveTo(2, 1)
				.MoveTo(2, 1)
				.MoveTo(3, 1)
				.MoveTo(3, 1)
				.MoveTo(3, 1)
				.MoveTo(3, 1)
				.MoveTo(3, 1)
				.MoveTo(4, 1)
				.MoveTo(4, 1)
				.MoveTo(4, 1)
				.MoveTo(4, 1)
				.MoveTo(4, 1)
				.MoveTo(5, 1)
				.MoveTo(5, 1)
				.MoveTo(5, 1)
				.MoveTo(5, 1)
				.MoveTo(5, 1)
				.MoveTo(5, 0)
				.MoveTo(5, 0)
				.MoveTo(5, 0)
				.MoveTo(5, 0)
				.MoveTo(5, 0)
				.MoveTo(5, 0)
				.MoveTo(5, 0)
				.MoveTo(5, 0)
				.MoveTo(5, -1)
				.MoveTo(5, -1)
				.MoveTo(5, -1)
				.MoveTo(5, -1)
				.MoveTo(5, -1)
				.MoveTo(4, -1)
				.MoveTo(4, -1)
				.MoveTo(4, -1)
				.MoveTo(4, -1)
				.MoveTo(4, -1)
				.MoveTo(3, -1)
				.MoveTo(3, -1)
				.MoveTo(3, -1)
				.MoveTo(3, -1)
				.MoveTo(3, -1)
				.MoveTo(2, -1)
				.MoveTo(2, -1)
				.MoveTo(2, -1)
				.MoveTo(2, -1)
				.MoveTo(2, -1)
				.MoveTo(1, -1)
				.MoveTo(1, -1)
				.MoveTo(1, -1)
				.MoveTo(1, -1)
				.MoveTo(1, -1)
				.Release();

			IMultiAction m = new MultiAction (driver);
			m.Add (a1).Add(a2).Add(smile);
			m.Perform ();
			Thread.Sleep (10000);
			driver.Navigate ().Back ();
			Thread.Sleep (1000);
			driver.Navigate ().Back ();
			Thread.Sleep (1000);
            driver.GetScreenshot();
		}

        [Test()]
        public void HideKeyBoardTestCase()
        {
            driver.StartActivity("io.appium.android.apis", ".app.CustomTitle");
            driver.FindElement(By.Id("io.appium.android.apis:id/left_text_edit")).Clear();
            driver.HideKeyboard();
        }
	}
}

