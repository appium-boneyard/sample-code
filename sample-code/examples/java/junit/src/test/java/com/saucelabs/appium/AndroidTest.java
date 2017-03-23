package com.saucelabs.appium;

import org.junit.Test;
import org.openqa.selenium.By;
import org.openqa.selenium.WebElement;

import java.util.List;

import static org.junit.Assert.assertEquals;

public class AndroidTest extends BaseDriver{


    @Test
    public void apiDemo(){
        WebElement el = driver.findElement(By.xpath(".//*[@text='Animation']"));
        assertEquals("Animation", el.getText());
        el = driver.findElementByClassName("android.widget.TextView");
        assertEquals("API Demos", el.getText());
        el = driver.findElement(By.xpath(".//*[@text='App']"));
        el.click();
        List<WebElement> els = driver.findElementsByClassName("android.widget.TextView");
        assertEquals("Activity", els.get(2).getText());
    }

}
