using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.Service;
using OpenQA.Selenium.Appium.Service.Options;
using OpenQA.Selenium.Remote;
using System;

namespace Appium.Samples.Helpers
{
    public class AppiumServers
    {
        private static AppiumLocalService LocalService;

        public static Uri sauceURI = new Uri("http://ondemand.saucelabs.com:80/wd/hub");

        public static Uri LocalServiceURIAndroid
        {
            get
            {
                if (LocalService == null)
                {
                    AppiumServiceBuilder builder = new AppiumServiceBuilder().WithLogFile(new System.IO.FileInfo("Log"));
                    LocalService = builder.Build();
                }

                if (!LocalService.IsRunning)
                {
                    LocalService.Start();
                }

                return LocalService.ServiceUrl;
            }
        }

        public static Uri LocalServiceURIForIOS
        {
            get
            {
                if (LocalService == null)
                {
                    AppiumServiceBuilder builder = new AppiumServiceBuilder();
                    DesiredCapabilities capabilities = new DesiredCapabilities();
                    capabilities.SetCapability(IOSMobileCapabilityType.LaunchTimeout, Env.INIT_TIMEOUT_SEC.TotalMilliseconds);
                    OptionCollector collector = new OptionCollector().AddCapabilities(capabilities).
                        //I use MAC OS X VMWare image. Sometimes it is very slow. 
                        AddArguments(IOSOptionList.BackEndRetries("5"));
                    LocalService = builder.WithArguments(collector).Build();
                }

                if (!LocalService.IsRunning)
                {
                    LocalService.Start();
                }

                return LocalService.ServiceUrl;
            }
        }

        public static void StopLocalService()
        {
            if (LocalService != null && LocalService.IsRunning)
            {
                LocalService.Dispose();
                LocalService = null;
            }
        }
    }
}

