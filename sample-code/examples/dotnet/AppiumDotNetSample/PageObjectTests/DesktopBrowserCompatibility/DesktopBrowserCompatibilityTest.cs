using Appium.Samples.Helpers;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.PageObjects;
using OpenQA.Selenium.Appium.PageObjects.Attributes;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Internal;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;

namespace Appium.Samples.PageObjectTests.DesktopBrowserCompatibility
{
    [TestFixture()]
    public class DesktopBrowserCompatibilityTest
    {
        private IWebDriver driver;
        private bool allPassed = true;
        private FoundLinks links;

        [FindsBy(How = How.Name, Using = "q")]
        [FindsByAndroidUIAutomator(AndroidUIAutomator = "new UiSelector().resourceId(\"android:id/someId\")")]
        [FindsByIOSUIAutomation(IosUIAutomation = ".elements()[0]")]
        private IWebElement searchTextField;

        [FindsByAndroidUIAutomator(ClassName = "someClass")]
        [FindsByIOSUIAutomation(IosUIAutomation = "//selector[1]")]
        [FindsBy(How = How.Name, Using = "btnG")]
        private IWebElement searchButton;

        [CacheLookup] //this element will be found once
        private IWebElement ires; //Should be found by ID or Name equal "ires"

        private IList<IWebElement> btnG; //these elements are found by name="btnG"

        [TestFixtureSetUp]
        public void BeforeAll()
        {
            TimeOutDuration timeSpan = new TimeOutDuration(new TimeSpan(0, 0, 0, 5, 0));
            driver = new FirefoxDriver();
            driver.Url = "https://www.google.com";
            AppiumPageObjectMemberDecorator decorator = new AppiumPageObjectMemberDecorator(timeSpan);
            PageFactory.InitElements(driver, this, decorator);
            links = new FoundLinks();
            PageFactory.InitElements(ires, links, decorator);
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

        [Test()]
        public void GoogleSearching()
        {
            searchTextField.SendKeys("Hello Appium!");
            Assert.GreaterOrEqual(1, btnG.Count);
            searchButton.Click();
            Assert.GreaterOrEqual(10, links.Links.Count);
            Assert.AreNotEqual(ires, null);
            Assert.AreNotEqual(((IWrapsElement) ires).WrappedElement, null);

            //this checking notices that element is found once and cached
            Assert.AreEqual(((IWrapsElement)ires).WrappedElement.GetHashCode(), ((IWrapsElement)ires).WrappedElement.GetHashCode());

            //this checking notices that element are found once and cached
            IList<IWebElement> cachedList = links.Links;
            Assert.GreaterOrEqual(10, cachedList.Count);
            Assert.AreEqual(links.Links.Count, cachedList.Count);

            int i = 0;
            foreach (var element in cachedList)
            {
                Assert.AreEqual(element.GetHashCode(), links.Links[i].GetHashCode());
                i++;
            }
        }
    }


    class FoundLinks
    {
        [CacheLookup]
        [FindsBySequence]
        [FindsBy(How = How.ClassName, Using = "r", Priority = 1)]
        [FindsBy(How = How.TagName, Using = "a", Priority = 2)]
        public IList<IWebElement> Links { set;  get; }

        
    }
}
