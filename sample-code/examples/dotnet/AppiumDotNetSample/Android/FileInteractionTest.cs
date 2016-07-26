using Appium.Samples.Helpers;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Remote;
using System;
using System.IO;
using System.Text;

namespace Appium.Samples.Android
{
    class FileInteractionTest
    {
        private AndroidDriver<IWebElement> driver;

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
        public void PushStringTest()
        {
            string data =
                "The eventual code is no more than the deposit of your understanding. ~E. W. Dijkstra";
            driver.PushFile("/data/local/tmp/remote.txt", data);
            byte[] returnDataBytes = driver.PullFile("/data/local/tmp/remote.txt");
            string returnedData = Encoding.UTF8.GetString(returnDataBytes);
            Assert.AreEqual(data, returnedData);
        }

        [Test]
        public void PushBytesTest()
        {
            string data =
                "The eventual code is no more than the deposit of your understanding. ~E. W. Dijkstra";
            var bytes = Encoding.UTF8.GetBytes(data);
            var base64 = Convert.ToBase64String(bytes);

            driver.PushFile("/data/local/tmp/remote.txt", Convert.FromBase64String(base64));
            byte[] returnDataBytes = driver.PullFile("/data/local/tmp/remote.txt");
            string returnedData = Encoding.UTF8.GetString(returnDataBytes);
            Assert.AreEqual(data, returnedData);
        }

        [Test]
        public void PushFileTest()
        {
            string filePath = System.IO.Path.GetTempPath();
            var fileName = Guid.NewGuid().ToString();
            string fullPath = Path.Combine(filePath, fileName);

            File.WriteAllText(fullPath, 
                "The eventual code is no more than the deposit of your understanding. ~E. W. Dijkstra");

            try
            {
                FileInfo file = new FileInfo(fullPath);
                driver.PushFile("/data/local/tmp/remote.txt", file);
                byte[] returnDataBytes = driver.PullFile("/data/local/tmp/remote.txt");
                string returnedData = Encoding.UTF8.GetString(returnDataBytes);
                Assert.AreEqual(
                    "The eventual code is no more than the deposit of your understanding. ~E. W. Dijkstra", 
                    returnedData);
            }
            finally
            {
                File.Delete(fullPath);
            }
        }
    }
}
