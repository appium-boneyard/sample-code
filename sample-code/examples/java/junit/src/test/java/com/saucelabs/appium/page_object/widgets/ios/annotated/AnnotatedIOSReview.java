package com.saucelabs.appium.page_object.widgets.ios.annotated;


import com.saucelabs.appium.page_object.widgets.ios.simple.IOSReview;
import io.appium.java_client.pagefactory.iOSFindBy;
import org.openqa.selenium.WebElement;

@iOSFindBy(className = "UIAWindow")
public class AnnotatedIOSReview extends IOSReview {
    protected AnnotatedIOSReview(WebElement element) {
        super(element);
    }
}
