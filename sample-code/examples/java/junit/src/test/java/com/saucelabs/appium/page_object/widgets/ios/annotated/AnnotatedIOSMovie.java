package com.saucelabs.appium.page_object.widgets.ios.annotated;

import com.saucelabs.appium.page_object.widgets.ios.simple.IOSMovie;
import io.appium.java_client.pagefactory.iOSFindBy;
import org.openqa.selenium.WebElement;

@iOSFindBy(className = "UIATableCell")
public class AnnotatedIOSMovie extends IOSMovie {
    protected AnnotatedIOSMovie(WebElement element) {
        super(element);
    }
}
