using System;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium;
using NUnit.Framework;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Appium.Android;
using Appium.Samples.Helpers;

namespace Appium.Samples.Android
{
	[TestFixture]
	public class AndroidAppStringsTest
	{
		private AppiumDriver<IWebElement> driver;

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
			driver = new AndroidDriver<IWebElement>(serverUri, capabilities, Env.INIT_TIMEOUT_SEC);
			driver.Manage().Timeouts().ImplicitlyWait(Env.IMPLICIT_TIMEOUT_SEC);
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

		[Test]
		public void GetAppStrings() {
			Assert.AreNotSame(0, driver.GetAppStringDictionary ().Count);
		}

		[Test]
		public void GetAppStringsUsingLang() {
			Assert.AreNotSame(0, driver.GetAppStringDictionary ("en").Count);
		}
	}
}

