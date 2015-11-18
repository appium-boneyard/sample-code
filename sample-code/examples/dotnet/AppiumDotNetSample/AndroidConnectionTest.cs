using Appium.Samples.Helpers;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Remote;
using System;

namespace Appium.Samples
{
    [TestFixture()]
    class AndroidConnectionTest
    {
        private AppiumDriver<IWebElement> driver;
        private bool allPassed = true;

        [TestFixtureSetUp]
        public void BeforeAll()
        {
            DesiredCapabilities capabilities = Env.isSauce() ?
                Caps.getAndroid18Caps(Apps.get("androidApiDemos")) :
                Caps.getAndroid19Caps(Apps.get("androidApiDemos"));
            if (Env.isSauce())
            {
                capabilities.SetCapability("username", Env.getEnvVar("SAUCE_USERNAME"));
                capabilities.SetCapability("accessKey", Env.getEnvVar("SAUCE_ACCESS_KEY"));
                capabilities.SetCapability("name", "android - complex");
                capabilities.SetCapability("tags", new string[] { "sample" });
            }
            Uri serverUri = Env.isSauce() ? AppiumServers.sauceURI : AppiumServers.localURI;
            driver = new AndroidDriver<IWebElement>(serverUri, capabilities, Env.INIT_TIMEOUT_SEC);
            driver.Manage().Timeouts().ImplicitlyWait(Env.IMPLICIT_TIMEOUT_SEC);
        }

        [TestFixtureTearDown]
        public void AfterAll()
        {
            try
            {
                if (Env.isSauce())
                    ((IJavaScriptExecutor)driver).ExecuteScript("sauce:job-result=" + (allPassed ? "passed" : "failed"));
            }
            finally
            {
                driver.Quit();
            }
        }

        [TearDown]
        public void AfterEach()
        {
            allPassed = allPassed && (TestContext.CurrentContext.Result.State == TestState.Success);
        }

        [Test]
        public void ConnectionTest()
        {
            ((AndroidDriver<IWebElement>)driver).ConnectionType = ConnectionType.AirplaneMode;
            Assert.AreEqual(ConnectionType.AirplaneMode, ((AndroidDriver<IWebElement>)driver).ConnectionType);

            ((AndroidDriver<IWebElement>)driver).ConnectionType = ConnectionType.WifiOnly;
            Assert.AreEqual(ConnectionType.WifiOnly, ((AndroidDriver<IWebElement>)driver).ConnectionType);
        }
    }
}
