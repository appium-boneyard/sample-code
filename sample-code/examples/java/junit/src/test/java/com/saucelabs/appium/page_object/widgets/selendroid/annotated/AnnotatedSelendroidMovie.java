package com.saucelabs.appium.page_object.widgets.selendroid.annotated;

import com.saucelabs.appium.page_object.widgets.selendroid.simple.SelendroidMovie;
import io.appium.java_client.pagefactory.SelendroidFindBy;
import org.openqa.selenium.WebElement;

@SelendroidFindBy(className = "android.widget.RelativeLayout")
public class AnnotatedSelendroidMovie extends SelendroidMovie {

    protected AnnotatedSelendroidMovie(WebElement element) {
        super(element);
    }
}
