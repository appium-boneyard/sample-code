package com.saucelabs.appium.page_object.widgets.combined.annotated;



import com.saucelabs.appium.page_object.widgets.combined.simple.CombinedReview;
import io.appium.java_client.pagefactory.AndroidFindBy;
import io.appium.java_client.pagefactory.AndroidFindBys;
import io.appium.java_client.pagefactory.SelendroidFindBy;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.support.FindBy;

@FindBy(id = "main_container")
@SelendroidFindBy(className = "android.widget.RelativeLayout")
@AndroidFindBys({@AndroidFindBy(id = "android:id/content"),
        @AndroidFindBy(className = "android.widget.RelativeLayout")})
public class AnnotatedCombinedReview extends CombinedReview {
    protected AnnotatedCombinedReview(WebElement element) {
        super(element);
    }
}
