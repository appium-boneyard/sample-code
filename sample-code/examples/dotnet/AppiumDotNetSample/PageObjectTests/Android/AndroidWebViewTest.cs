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
using System.Threading;

namespace Appium.Samples.PageObjectTests.Android
{
    public class AndroidWebViewTest
    {
        private AndroidDriver<AppiumWebElement> driver;
        private bool allPassed = true;
        private AndroidWebView pageObject;

        [TestFixtureSetUp]
        public void BeforeAll()
        {
            DesiredCapabilities capabilities = Env.isSauce() ?
                Caps.getAndroid501Caps(Apps.get("selendroidTestApp")) :
                Caps.getAndroid19Caps(Apps.get("selendroidTestApp"));
            if (Env.isSauce())
            {
                capabilities.SetCapability("username", Env.getEnvVar("SAUCE_USERNAME"));
                capabilities.SetCapability("accessKey", Env.getEnvVar("SAUCE_ACCESS_KEY"));
                capabilities.SetCapability("name", "android - webview");
                capabilities.SetCapability("tags", new string[] { "sample" });
            }
            Uri serverUri = Env.isSauce() ? AppiumServers.sauceURI : AppiumServers.LocalServiceURIAndroid;
            driver = new AndroidDriver<AppiumWebElement>(serverUri, capabilities, Env.INIT_TIMEOUT_SEC);
            TimeOutDuration timeSpan = new TimeOutDuration(new TimeSpan(0, 0, 0, 5, 0));
            pageObject = new AndroidWebView();
            PageFactory.InitElements(driver, pageObject, new AppiumPageObjectMemberDecorator(timeSpan));
            driver.StartActivity("io.selendroid.testapp", ".WebViewActivity");
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
        public void WebViewTestCase()
        {
            Thread.Sleep(5000);
            if (!Env.isSauce())
            {
                var contexts = driver.Contexts;
                string webviewContext = null;
                for (int i = 0; i < contexts.Count; i++)
                {
                    Console.WriteLine(contexts[i]);
                    if (contexts[i].Contains("WEBVIEW"))
                    {
                        webviewContext = contexts[i];
                    }
                }
                Assert.IsNotNull(webviewContext);
                driver.Context = webviewContext;

                pageObject.SendMeYourName();                
            }
        }

    }
}
