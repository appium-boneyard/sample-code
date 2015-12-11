package com.saucelabs.appium.page_object.widgets.combined.annotated;

import com.saucelabs.appium.page_object.widgets.combined.simple.CombinedMovie;
import io.appium.java_client.pagefactory.AndroidFindBy;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.support.FindBy;

@AndroidFindBy(className = "android.widget.RelativeLayout")
@FindBy(className = "mb-movie")
public class AnnotatedCombinedMovie extends CombinedMovie {
    protected AnnotatedCombinedMovie(WebElement element) {
        super(element);
    }
}
