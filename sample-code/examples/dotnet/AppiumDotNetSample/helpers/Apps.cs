using System.Collections.Generic;
using System.IO;

namespace Appium.Samples.Helpers
{
    public class Apps
    {
        private static bool isInited;
        private static Dictionary<string, string> Appz;

        private static void Init()
        {
            if (!isInited)
            {
                if (Env.isSauce())
                {
                    Appz = new Dictionary<string, string> {
                        { "iosTestApp", "http://appium.github.io/appium/assets/TestApp7.1.app.zip" },
                        { "iosWebviewApp", "http://appium.github.io/appium/assets/WebViewApp7.1.app.zip" },
                        { "iosUICatalogApp", "http://appium.github.io/appium/assets/UICatalog7.1.app.zip" },
                        { "androidApiDemos", "http://appium.github.io/appium/assets/ApiDemos-debug.apk" },
                        { "selendroidTestApp", "http://appium.github.io/appium/assets/selendroid-test-app-0.10.0.apk" }
                    };
                }
                else
                {
                    File.WriteAllBytes("ApiDemos-debug.apk", AppiumDotNetSample.Properties.Resources.ApiDemos_debug);
                    File.WriteAllBytes("selendroid-test-app-0.10.0.apk", AppiumDotNetSample.Properties.Resources.selendroid_test_app_0_10_0);
                    File.WriteAllBytes("TestApp7.1.app.zip", AppiumDotNetSample.Properties.Resources.TestApp7_1_app);
                    File.WriteAllBytes("WebViewApp7.1.app.zip", AppiumDotNetSample.Properties.Resources.WebViewApp7_1_app);
                    File.WriteAllBytes("UICatalog7.1.app.zip", AppiumDotNetSample.Properties.Resources.UICatalog7_1_app);
                    File.WriteAllBytes("IntentExample.apk", AppiumDotNetSample.Properties.Resources.IntentExample);

                    Appz = new Dictionary<string, string> {
                        { "iosTestApp", new FileInfo("TestApp7.1.app.zip").FullName },
                        { "iosWebviewApp", new FileInfo("WebViewApp7.1.app.zip").FullName },
                        { "iosUICatalogApp", new FileInfo("UICatalog7.1.app.zip").FullName },
                        { "androidApiDemos", new FileInfo("ApiDemos-debug.apk").FullName },
                        { "selendroidTestApp", new FileInfo("selendroid-test-app-0.10.0.apk").FullName },
                        { "intentApp", new FileInfo("IntentExample.apk").FullName }
                    };
                }
                isInited = true;
            }
        }

        public static string get(string appKey)
        {
            Init();
            return Appz[appKey];
        }
    }
}
