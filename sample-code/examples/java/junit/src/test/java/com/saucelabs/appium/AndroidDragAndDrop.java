package com.saucelabs.appium;

import io.appium.java_client.AppiumDriver;
import io.appium.java_client.MobileElement;
import io.appium.java_client.TouchAction;
import io.appium.java_client.android.AndroidDriver;
import junit.framework.Assert;
import org.junit.After;
import org.junit.Before;
import org.junit.Test;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.remote.DesiredCapabilities;

import java.io.File;
import java.net.URL;

import static org.junit.Assert.assertEquals;

/**
 * Created by saikrisv on 26/04/16.
 */
public class AndroidDragAndDrop extends BaseDriver {
    @Test
    public void testDragAndDrop() throws InterruptedException {
        scrollTo("Views").click();
       scrollTo("Drag and Drop").click();
        MobileElement calc = (MobileElement) driver.findElementById("io.appium.android.apis:id/drag_dot_1");
        TouchAction touchAction = new TouchAction(driver);
        WebElement destination = driver.findElementById("io.appium.android.apis:id/drag_dot_2");
        touchAction.longPress(calc).waitAction(6000).moveTo(destination).perform().release();
        Thread.sleep(5000);
        assertEquals(driver.findElementById("io.appium.android.apis:id/drag_result_text").getText(), "Dropped!");
    }
}
