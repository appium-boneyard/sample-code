package com.saucelabs.appium;

import io.appium.java_client.TouchAction;
import org.junit.Test;
import org.openqa.selenium.Dimension;
import org.openqa.selenium.Point;
import org.openqa.selenium.WebElement;

public class AndroidSlideTest extends BaseDriver {

    @Test
    public void testSlider(){
        scrollTo("Views").click();
        scrollTo("Seek Bar").click();

        WebElement slider = driver.findElementById("io.appium.android.apis:id/seek");
        Point sliderLocation = getCenter(slider);
        new TouchAction(driver).press(sliderLocation.getX(),sliderLocation.getY())
                .moveTo(sliderLocation.getX() / 2 , sliderLocation.getY()).perform().release();

    }

    private Point getCenter(WebElement element) {

        Point upperLeft = element.getLocation();
        Dimension dimensions = element.getSize();
        return new Point(upperLeft.getX() + dimensions.getWidth()/2, upperLeft.getY() + dimensions.getHeight()/2);
    }
}
