package com.saucelabs.appium;

import io.appium.java_client.MobileBy;
import io.appium.java_client.MobileElement;
import io.appium.java_client.TouchAction;
import io.appium.java_client.ios.IOSTouchAction;
import org.junit.Test;
import org.openqa.selenium.Alert;
import org.openqa.selenium.Dimension;
import org.openqa.selenium.support.ui.ExpectedConditions;
import org.openqa.selenium.support.ui.WebDriverWait;

import static org.junit.Assert.assertTrue;

public class GestureTest extends BaseCrossPlatformDriver{

    @Test
    public void horizontalSwipingTest() throws Exception {
        login();
        driver.findElementByAccessibilityId("slider1").click();
        MobileElement slider = driver.findElementByAccessibilityId("slider");
        Dimension size = slider.getSize();

        TouchAction swipe = new TouchAction(driver).press(slider, 0, size.height / 2).waitAction(2000)
                .moveTo(slider, size.width / 2, size.height / 2).release();
        swipe.perform();
    }

    @Test //Will work only on XCUI mode as doubleTap is not supported by IOS/Android
    public void doubleTap() throws InterruptedException {
        login();
        driver.findElementByAccessibilityId("doubleTap").click();
        MobileElement doubleTap = (MobileElement) new WebDriverWait(driver, 30).
                until(ExpectedConditions.elementToBeClickable(MobileBy.AccessibilityId("doubleTapMe")));
        new IOSTouchAction(driver).doubleTap(doubleTap).perform();
        Thread.sleep(2000);
        assertTrue(driver.switchTo().alert().getText().contains("Double tap successful!"));
    }

    @Test
    public void longPress() throws InterruptedException {
        login();
        Thread.sleep(5000);
        driver.findElementByAccessibilityId("longPress").click();
        MobileElement longpress = (MobileElement) new WebDriverWait(driver, 30).
                until(ExpectedConditions.elementToBeClickable(MobileBy.AccessibilityId("longpress")));
        new TouchAction(driver).longPress(longpress,3000).perform();
        assertTrue(driver.switchTo().alert().getText().contains("Long Pressed"));
    }
}
