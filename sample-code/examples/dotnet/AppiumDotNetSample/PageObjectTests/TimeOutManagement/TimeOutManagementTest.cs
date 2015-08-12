using Appium.Samples.Helpers;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.PageObjects;
using OpenQA.Selenium.Appium.PageObjects.Attributes;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;


namespace Appium.Samples.PageObjectTests.TimeOutManagement
{
    public class TimeOutManagementTest
    {
        private IWebDriver driver;
        private bool allPassed = true;
        private TimeOutDuration duration;

        [FindsBy(How = How.ClassName, Using = "FakeClass", Priority = 1)]
        [FindsBy(How = How.TagName, Using = "FakeTag", Priority = 2)]
        private IList<IWebElement> stubElements;

        [WithTimeSpan(Seconds = 15)]
        [FindsBy(How = How.ClassName, Using = "FakeClass", Priority = 1)]
        [FindsBy(How = How.TagName, Using = "FakeTag", Priority = 2)]
        private IList<IWebElement> stubElements2;

        private readonly TimeSpan accepableTimeDelta = new TimeSpan(0, 0, 2); //Another procceses/environment issues can interfere 
        //the checking

        [SetUp]
        public void Before()
        {   
            if (driver == null)
            {
                driver = new FirefoxDriver();
            }
            duration = new TimeOutDuration(new TimeSpan(0, 0, 5));
            PageFactory.InitElements(driver, this, new AppiumPageObjectMemberDecorator(duration));
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

        private bool IsInTime(TimeSpan span, IList<IWebElement> list)
        {
            DateTime start = DateTime.Now;
            TimeSpan checkingSpan = new TimeSpan(span.Hours, span.Seconds + accepableTimeDelta.Seconds, span.Milliseconds);
            DateTime deadline = DateTime.Now.Add(checkingSpan);
            var size = list.Count;
            DateTime now = DateTime.Now;

            return (now <= deadline & start.Add(span) <= now);
        }



        [Test()]
        public void CheckAbilityToChangeWaitingTime()
        {
            Assert.AreEqual(true, IsInTime(new TimeSpan(0, 0, 5), stubElements));
            TimeSpan newTime = new TimeSpan(0, 0, 0, 20, 500);
            duration.WaitingDuration = newTime;
            Assert.AreEqual(true, IsInTime(newTime, stubElements));
            newTime = new TimeSpan(0, 0, 0, 2, 0);
            duration.WaitingDuration = newTime;
            Assert.AreEqual(true, IsInTime(newTime, stubElements));
        }

        [Test()]
        public void CheckWaitingTimeIfMemberHasAttribute_WithTimeSpan()
        {
            TimeSpan fifteenSeconds = new TimeSpan(0, 0, 0, 15, 0); ;
            Assert.AreEqual(true, IsInTime(new TimeSpan(0, 0, 5), stubElements));
            Assert.AreEqual(true, IsInTime(fifteenSeconds, stubElements2));

            TimeSpan newTime = new TimeSpan(0, 0, 0, 2, 0);
            duration.WaitingDuration = newTime;
            Assert.AreEqual(true, IsInTime(newTime, stubElements));
            Assert.AreEqual(true, IsInTime(fifteenSeconds, stubElements2));
        }
    }
}
