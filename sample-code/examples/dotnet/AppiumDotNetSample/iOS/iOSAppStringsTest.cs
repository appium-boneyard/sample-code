using System;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium;
using NUnit.Framework;
using OpenQA.Selenium.Remote;
using Appium.Integration.Tests.Helpers;
using OpenQA.Selenium.Appium.iOS;

namespace Appium.Integration.Tests.iOS
{
	public class iOSAppStringsTest
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
				capabilities.SetCapability("name", "ios - complex");
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

		[Test]
		public void GetAppStrings() {
			Assert.AreNotSame(0, driver.GetAppStringDictionary ().Count);
		}

		[Test]
		public void GetAppStringsUsingLang() {
			Assert.AreNotSame(0, driver.GetAppStringDictionary ("en").Count);
		}

		[Test]
		public void GetAppStringsUsingLangAndFileStrings() {
			Assert.AreNotSame(0, driver.GetAppStringDictionary ("en", "Localizable.strings").Count);
		}
	}
}

