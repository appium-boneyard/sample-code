package com.saucelabs.appium.page_object.widgets.html.annotated;

import com.saucelabs.appium.page_object.widgets.html.simple.HtmlReview;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.support.FindBy;

@FindBy(id = "main_container")
public class AnnotatedHtmlReview extends HtmlReview {
    protected AnnotatedHtmlReview(WebElement element) {
        super(element);
    }
}
