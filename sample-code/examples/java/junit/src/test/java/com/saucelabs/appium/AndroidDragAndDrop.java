package com.saucelabs.appium;

import io.appium.java_client.MobileBy;
import io.appium.java_client.MobileElement;
import io.appium.java_client.TouchAction;
import org.junit.Test;
import org.openqa.selenium.support.ui.ExpectedConditions;
import org.openqa.selenium.support.ui.WebDriverWait;

import static org.junit.Assert.assertEquals;

public class AndroidDragAndDrop extends BaseCrossPlatformDriver {
    @Test
    public void testDragAndDrop() throws InterruptedException {
        login();
        driver.findElementByAccessibilityId("dragAndDrop").click();
        MobileElement dragMe = (MobileElement) new WebDriverWait(driver, 30)
                .until(ExpectedConditions
                        .elementToBeClickable(MobileBy.AccessibilityId("dragMe")));
        new TouchAction(driver).press(dragMe).waitAction(3000)
                .moveTo(driver.findElementByAccessibilityId("dropzone")).release().perform();
        String expected = driver.findElementByAccessibilityId("success").getText();
        assertEquals(expected,"Circle dropped");
    }
}
