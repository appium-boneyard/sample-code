using Appium.Samples.Helpers;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Remote;
using System;
using System.Drawing;
using System.Threading;

namespace Appium.Samples
{
    [TestFixture()]
    class AndroidGestureTest
    {
        private AndroidDriver<AndroidElement> driver;
        private bool allPassed = true;

        [SetUp]
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
            driver = new AndroidDriver<AndroidElement>(serverUri, capabilities, Env.INIT_TIMEOUT_SEC);
            driver.Manage().Timeouts().ImplicitlyWait(Env.IMPLICIT_TIMEOUT_SEC);
        }

        [TearDown]
        public void AfterEach()
        {
            allPassed = allPassed && (TestContext.CurrentContext.Result.State == TestState.Success);
            if (Env.isSauce())
                ((IJavaScriptExecutor)driver).ExecuteScript("sauce:job-result=" + (allPassed ? "passed" : "failed"));
            driver.Quit();
        }

        [Test()]
        public void scrollAndSwipeTest()
        {
            driver.FindElementByName("Graphics").Click();
            driver.ScrollTo("FingerPaint", "android:id/list");
            driver.FindElementByName("FingerPaint").Click();
            AndroidElement element = driver.FindElementById("android:id/content");
            Point point = element.Coordinates.LocationInDom;
            Size size = element.Size;
            driver.Swipe
            (
                point.X + 5, 
                point.Y + 5, 
                point.X + size.Width - 5,
                point.Y + size.Height - 5, 
                200
            ); 
            
            driver.Swipe
            (
                point.X + size.Width - 5,
                point.Y + 5,
                point.X + 5,
                point.Y + size.Height - 5,
                2000
            );
        }

        [Test()]
        public void pinchAndZoomTest()
        {
            driver.FindElementByName("Graphics").Click();
            driver.ScrollTo("OpenGL ES", "android:id/list").Click();
            //driver.FindElementByName("OpenGL ES").Click();
            driver.ScrollTo("Touch Rotate", "android:id/list").Click();
            //driver.FindElementByName("TouchRotate").Click();

            AndroidElement element = driver.FindElementById("android:id/content");
            driver.Pinch(element);
            driver.Zoom(element);

            Thread.Sleep(2000);
        }
    }
}
