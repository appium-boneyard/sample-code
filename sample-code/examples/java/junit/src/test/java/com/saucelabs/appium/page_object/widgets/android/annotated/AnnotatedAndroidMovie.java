package com.saucelabs.appium.page_object.widgets.android.annotated;

import com.saucelabs.appium.page_object.widgets.android.simple.AndroidMovie;
import io.appium.java_client.pagefactory.AndroidFindBy;
import org.openqa.selenium.WebElement;

@AndroidFindBy(className = "android.widget.RelativeLayout")
public class AnnotatedAndroidMovie extends AndroidMovie {
    protected AnnotatedAndroidMovie(WebElement element) {
        super(element);
    }
}
