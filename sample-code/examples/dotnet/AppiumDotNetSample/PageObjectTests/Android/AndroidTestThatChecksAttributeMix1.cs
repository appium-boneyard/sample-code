using Appium.Samples.Helpers;
using Appium.Samples.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.PageObjects;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.PageObjects;
using System;

namespace Appium.Samples.PageObjectTests.Android
{
    [TestFixture()]
    public class AndroidTestThatChecksAttributeMix1
    {
        private AndroidDriver<AppiumWebElement> driver;
        private bool allPassed = true;
        private AndroidPageObjectChecksAttributeMixOnNativeApp1 pageObject;

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
            TimeOutDuration timeSpan = new TimeOutDuration(new TimeSpan(0, 0, 0, 5, 0));
            pageObject = new AndroidPageObjectChecksAttributeMixOnNativeApp1();
            PageFactory.InitElements(driver, pageObject, new AppiumPageObjectMemberDecorator(timeSpan));
        }

        [TestFixtureTearDown]
        public void AfterEach()
        {
            allPassed = allPassed && (TestContext.CurrentContext.Result.State == TestState.Success);
            if (Env.isSauce())
                ((IJavaScriptExecutor)driver).ExecuteScript("sauce:job-result=" + (allPassed ? "passed" : "failed"));
            driver.Quit();
        }

        [Test()]
        public void CheckMobileElement()
        {
            Assert.NotNull(pageObject.GetMobileElementText());
        }

        [Test()]
        public void CheckMobileElements()
        {
            Assert.GreaterOrEqual(pageObject.GetMobileElementSize(), 1);
        }

        [Test()]
        public void CheckMobileElementProperty()
        {
            Assert.NotNull(pageObject.GetMobileElementPropertyText());
        }

        [Test()]
        public void CheckMobileElementsProperty()
        {
            Assert.GreaterOrEqual(pageObject.GetMobileElementPropertySize(), 1);
        }

        [Test()]
        public void CheckElementFoundUsingMultipleLocators()
        {
            Assert.NotNull(pageObject.GetMultipleFindByElementText());
        }

        [Test()]
        public void CheckElementsFoundUsingMultipleLocators()
        {
            Assert.GreaterOrEqual(pageObject.GetMultipleFindByElementSize(), 10);
            Assert.LessOrEqual(pageObject.GetMultipleFindByElementSize(), 14);
        }

        [Test()]
        public void CheckElementFoundUsingMultipleLocatorsProperty()
        {
            Assert.NotNull(pageObject.GetMultipleFindByElementPropertyText());
        }

        [Test()]
        public void CheckElementsFoundUsingMultipleLocatorssProperty()
        {
            Assert.GreaterOrEqual(pageObject.GetMultipleFindByElementPropertySize(), 10);
            Assert.LessOrEqual(pageObject.GetMultipleFindByElementSize(), 14);
        }

        [Test()]
        public void CheckElementFoundByChainedSearch()
        {
            Assert.NotNull(pageObject.GetFoundByChainedSearchElementText());
        }

        [Test()]
        public void CheckElementsFoundByChainedSearch()
        {
            Assert.GreaterOrEqual(pageObject.GetFoundByChainedSearchElementSize(), 10);
            Assert.LessOrEqual(pageObject.GetMultipleFindByElementSize(), 14);
        }

        [Test()]
        public void CheckFoundByChainedSearchElementProperty()
        {
            Assert.NotNull(pageObject.GetFoundByChainedSearchElementPropertyText());
        }

        [Test()]
        public void CheckFoundByChainedSearchElementsProperty()
        {
            Assert.GreaterOrEqual(pageObject.GetFoundByChainedSearchElementPropertySize(), 10);
            Assert.LessOrEqual(pageObject.GetMultipleFindByElementSize(), 14);
        }

        [Test()]
        public void CheckElementMatchedToAll()
        {
            Assert.NotNull(pageObject.GetMatchedToAllLocatorsElementText());
        }

        [Test()]
        public void CheckElementsMatchedToAll()
        {
            Assert.GreaterOrEqual(pageObject.GetMatchedToAllLocatorsElementSize(), 1);
            Assert.LessOrEqual(pageObject.GetMatchedToAllLocatorsElementSize(), 13);
        }

        [Test()]
        public void CheckElementMatchedToAllProperty()
        {
            Assert.NotNull(pageObject.GetMatchedToAllLocatorsElementPropertyText());
        }

        [Test()]
        public void CheckElementMatchedToAllElementsProperty()
        {
            Assert.GreaterOrEqual(pageObject.GetMatchedToAllLocatorsElementPropertySize(), 1);
            Assert.LessOrEqual(pageObject.GetMatchedToAllLocatorsElementPropertySize(), 13);
        }
    }
}
