package com.saucelabs.appium.page_object.widgets.html.annotated;

import com.saucelabs.appium.page_object.widgets.html.simple.HtmlMovie;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.support.FindBy;

@FindBy(className = "mb-movie")
public class AnnotatedHtmlMovie extends HtmlMovie {
    protected AnnotatedHtmlMovie(WebElement element) {
        super(element);
    }
}
