package com.saucelabs.appium;

import io.appium.java_client.AppiumDriver;
import io.appium.java_client.MobileBy;
import io.appium.java_client.MobileElement;
import io.appium.java_client.TouchAction;
import io.appium.java_client.android.AndroidDriver;
import io.appium.java_client.ios.IOSDriver;
import io.appium.java_client.service.local.AppiumDriverLocalService;
import io.appium.java_client.service.local.AppiumServerHasNotBeenStartedLocallyException;
import org.junit.After;
import org.junit.Before;
import org.openqa.selenium.Dimension;
import org.openqa.selenium.remote.DesiredCapabilities;
import org.openqa.selenium.support.ui.ExpectedConditions;
import org.openqa.selenium.support.ui.WebDriverWait;

import java.io.File;
import java.io.IOException;


public class BaseCrossPlatformDriver {
    public AppiumDriver<MobileElement> driver;
    private static AppiumDriverLocalService service;

    @Before
    public void setUp() throws Exception {
        service = AppiumDriverLocalService.buildDefaultService();
        service.start();

        if (service == null || !service.isRunning()) {
            throw new AppiumServerHasNotBeenStartedLocallyException(
                    "An appium server node is not started!");
        }
        if (System.getProperty("platform").equalsIgnoreCase("ios")) {
            iOSCaps();
        } else if (System.getProperty("platform").equalsIgnoreCase("android")) {
            androidCaps();
        }
    }

    private void androidCaps() throws IOException {
        File classpathRoot = new File(System.getProperty("user.dir"));
        File appDir = new File(classpathRoot, "../../../apps/");
        File app = new File(appDir.getCanonicalPath(), "VodQA.apk");
        DesiredCapabilities capabilities = new DesiredCapabilities();
        capabilities.setCapability("deviceName", "Android");
        capabilities.setCapability("app", app.getAbsolutePath());
        driver = new AndroidDriver<>(service.getUrl(), capabilities);
    }

    private void iOSCaps() throws Exception {
        // set up appium
        File classpathRoot = new File(System.getProperty("user.dir"));
        File appDir = new File(classpathRoot, "../../../apps/");
        File app = new File(appDir, "VodQAReactNative.zip");
        DesiredCapabilities capabilities = new DesiredCapabilities();
        capabilities.setCapability("platformVersion", "10.2");
        capabilities.setCapability("deviceName", "iPhone 5s");
        capabilities.setCapability("app", app.getAbsolutePath());
        driver = new IOSDriver<>(service.getUrl(), capabilities);
    }

    @After
    public void tearDown() throws Exception {
        if (driver != null) {
            driver.quit();
        }
        if (service != null) {
            service.stop();
        }
    }

    public void login() {
        new WebDriverWait(driver, 30).until(ExpectedConditions.
                elementToBeClickable(MobileBy.AccessibilityId("login"))).click();
    }

    public void verticalSwipe(String locator) throws InterruptedException {
        Thread.sleep(3000);
        MobileElement slider = driver.findElementByAccessibilityId(locator);
        Dimension size = slider.getSize();

        TouchAction swipe = new TouchAction(driver).press(slider, size.width / 2, size.height - 20)
                .waitAction(2000).moveTo(slider,size.width / 2, size.height / 2 + 50).release();
        swipe.perform();
    }
}
