package com.saucelabs.appium.page_object.widgets.selendroid.annotated;


import com.saucelabs.appium.page_object.widgets.selendroid.simple.SelendroidReview;
import io.appium.java_client.pagefactory.SelendroidFindBy;
import org.openqa.selenium.WebElement;


@SelendroidFindBy(className = "android.widget.RelativeLayout")
public class AnnotatedSelendroidReview extends SelendroidReview {

    protected AnnotatedSelendroidReview(WebElement element) {
        super(element);
    }
}
