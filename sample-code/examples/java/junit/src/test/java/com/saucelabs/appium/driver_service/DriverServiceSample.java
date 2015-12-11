package com.saucelabs.appium.driver_service;

import io.appium.java_client.MobileElement;
import io.appium.java_client.android.AndroidDriver;
import io.appium.java_client.remote.MobileCapabilityType;
import io.appium.java_client.service.local.AppiumDriverLocalService;
import io.appium.java_client.service.local.AppiumServiceBuilder;
import io.appium.java_client.service.local.flags.GeneralServerFlag;
import org.junit.BeforeClass;
import org.junit.Test;
import org.openqa.selenium.Platform;
import org.openqa.selenium.remote.DesiredCapabilities;

import java.io.File;
import java.io.FileInputStream;
import java.util.Properties;

/**
 * Please make sure that:
 * - there is an installed node.js and the path to the folder which contains node.js executable is defined at 
 * PATH environmental variable 
 * - there is an installed appium.js (via npm)
 * - all appium servers are shut down
 * - take a look at custom_node_path.properties. If these files don't exist then please
 * set your values or set up Appium for desktop
 */

/*
    This sample shows how to use AppiumServiceBuilder and AppiumDriverLocalService
 */
public class DriverServiceSample {

    private static Properties properties;

    @BeforeClass
    public static void beforeClass() throws Exception{
        File file = new File("src/test/java/com/saucelabs/appium/driver_service/custom_node_path.properties");
        FileInputStream fileInput = new FileInputStream(file);
        properties = new Properties();
        properties.load(fileInput);
        fileInput.close();
    }

    private static File findCustomNode(){
        Platform current = Platform.getCurrent();
        if (current.is(Platform.WINDOWS))
            return new File(String.valueOf(properties.get("path.to.custom.node.win")));

        if (current.is(Platform.MAC))
            return new File(String.valueOf(properties.get("path.to.custom.node.macos")));

        return new File(String.valueOf(properties.get("path.to.custom.node.linux")));
    }

    @Test
    public void checkTheAbilityToStartADriverWithTheDefaultServerAndNode(){
        File classpathRoot = new File(System.getProperty("user.dir"));
        File appDir = new File(classpathRoot, "../../../apps/ApiDemos/bin");
        File app = new File(appDir, "ApiDemos-debug.apk");
        DesiredCapabilities capabilities = new DesiredCapabilities();
        capabilities.setCapability(MobileCapabilityType.DEVICE_NAME, "Android Emulator");
        capabilities.setCapability(MobileCapabilityType.APP, app.getAbsolutePath());
        new AndroidDriver<MobileElement>(capabilities).quit();
    }

    @Test
    public void checkTheAbilityToStartADriverWithTheDefaultServerAndNotDefaultNode(){
        System.setProperty(AppiumServiceBuilder.APPIUM_PATH, findCustomNode().getAbsolutePath());

        File classpathRoot = new File(System.getProperty("user.dir"));
        File appDir = new File(classpathRoot, "../../../apps/ApiDemos/bin");
        File app = new File(appDir, "ApiDemos-debug.apk");

        DesiredCapabilities capabilities = new DesiredCapabilities();
        capabilities.setCapability(MobileCapabilityType.DEVICE_NAME, "Android Emulator");
        capabilities.setCapability(MobileCapabilityType.APP, app.getAbsolutePath());

        try {
            new AndroidDriver<MobileElement>(capabilities).quit();
        }
        finally {
            System.clearProperty(AppiumServiceBuilder.APPIUM_PATH);
        }

    }

    @Test
     public void checkTheAbilityToBuildServiceAndStartADriver(){

        File classpathRoot = new File(System.getProperty("user.dir"));
        File appDir = new File(classpathRoot, "../../../apps/ApiDemos/bin");
        File app = new File(appDir, "ApiDemos-debug.apk");

        AppiumServiceBuilder builder = new AppiumServiceBuilder().withAppiumJS(findCustomNode()).withArgument(GeneralServerFlag.APP,
                app.getAbsolutePath()).withArgument(GeneralServerFlag.LOG_LEVEL, "info").usingAnyFreePort() /*and so on*/;

        DesiredCapabilities capabilities = new DesiredCapabilities();
        capabilities.setCapability(MobileCapabilityType.DEVICE_NAME, "Android Emulator");

        new AndroidDriver<MobileElement>(builder, capabilities).quit();
        new AndroidDriver<MobileElement>(builder.build(), capabilities).quit();

    }

    @Test
    public void checkTheAbilityToUseServiceSeparatelyFromADriver(){

        File classpathRoot = new File(System.getProperty("user.dir"));
        File appDir = new File(classpathRoot, "../../../apps/ApiDemos/bin");
        File app = new File(appDir, "ApiDemos-debug.apk");

        AppiumServiceBuilder builder = new AppiumServiceBuilder().withAppiumJS(findCustomNode()).withArgument(GeneralServerFlag.APP,
                app.getAbsolutePath()).withArgument(GeneralServerFlag.LOG_LEVEL, "info").usingAnyFreePort() /*and so on*/;
        AppiumDriverLocalService service = builder.build();

        DesiredCapabilities capabilities = new DesiredCapabilities();
        capabilities.setCapability(MobileCapabilityType.DEVICE_NAME, "Android Emulator");

        service.start();
        try {
            new AndroidDriver<MobileElement>(service.getUrl(), capabilities).quit();
        }
        finally {
           service.stop();
        }

    }
}
