using NUnit.Framework;
using System;
using Appium.Samples.Helpers;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Remote;
using System.Collections.Generic;
using OpenQA.Selenium;
using System.Threading;
using System.Drawing;
using OpenQA.Selenium.Appium.Android;

namespace Appium.Samples
{
	[TestFixture ()]
	public class AndroidSimpleTest
	{
		private AndroidDriver<AndroidElement> driver;
		private bool allPassed = true;

		[TestFixtureSetUp]
		public void BeforeAll(){
			DesiredCapabilities capabilities = Env.isSauce () ? 
				Caps.getAndroid18Caps (Apps.get ("androidApiDemos")) :
				Caps.getAndroid19Caps (Apps.get ("androidApiDemos"));
			if (Env.isSauce ()) {
				capabilities.SetCapability("username", Env.getEnvVar("SAUCE_USERNAME")); 
				capabilities.SetCapability("accessKey", Env.getEnvVar("SAUCE_ACCESS_KEY"));
				capabilities.SetCapability("name", "android - simple");
				capabilities.SetCapability("tags", new string[]{"sample"});
			}
			Uri serverUri = Env.isSauce () ? AppiumServers.sauceURI : AppiumServers.localURI;
            driver = new AndroidDriver<AndroidElement>(serverUri, capabilities, Env.INIT_TIMEOUT_SEC);	
			driver.Manage().Timeouts().ImplicitlyWait(Env.IMPLICIT_TIMEOUT_SEC);
		}

		[TestFixtureTearDown]
		public void AfterAll(){
			try
			{
				if(Env.isSauce())
					((IJavaScriptExecutor)driver).ExecuteScript("sauce:job-result=" + (allPassed ? "passed" : "failed"));
			}
			finally
			{
				driver.Quit();
			}
		}

		[TearDown]
		public void AfterEach(){
			allPassed = allPassed && (TestContext.CurrentContext.Result.State == TestState.Success);
		}

		[Test ()]
		public void FindElementTestCase ()
		{
            By byAccessibilityId = new ByAccessibilityId("Graphics");
            Assert.AreNotEqual(driver.FindElement(byAccessibilityId).Text, null);
            Assert.GreaterOrEqual(driver.FindElements(byAccessibilityId).Count, 1);
			
            driver.FindElementByAccessibilityId ("Graphics").Click ();
			Assert.IsNotNull (driver.FindElementByAccessibilityId ("Arcs"));
			driver.Navigate ().Back ();

            Assert.IsNotNull(driver.FindElementByName("App"));
            
            Assert.IsNotNull(driver.FindElement(new ByAndroidUIAutomator("new UiSelector().clickable(true)")).Text);
			var els = driver.FindElementsByAndroidUIAutomator ("new UiSelector().clickable(true)");
            Assert.GreaterOrEqual(els.Count, 12); 

            var els2 = driver.FindElements(new ByAndroidUIAutomator("new UiSelector().enabled(true)"));
            Assert.GreaterOrEqual(els2.Count, 20);

            els = driver.FindElementsByAndroidUIAutomator("new UiSelector().enabled(true)");
			Assert.GreaterOrEqual (els.Count, 20);
			Assert.IsNotNull (driver.FindElementByXPath ("//android.widget.TextView[@text='API Demos']"));
		}
	}
}

