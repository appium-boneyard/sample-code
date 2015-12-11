package com.saucelabs.appium.page_object.widgets.android.simple;

import com.saucelabs.appium.page_object.widgets.Movie;
import io.appium.java_client.android.AndroidElement;
import io.appium.java_client.pagefactory.AndroidFindBy;
import org.openqa.selenium.WebElement;

public class AndroidMovie extends Movie {

    @AndroidFindBy(id = "com.codepath.example.rottentomatoes:id/tvTitle")
    private AndroidElement title;

    @AndroidFindBy(uiAutomator = "resourceId(\"com.codepath.example.rottentomatoes:id/tvCriticsScore\")")
    private AndroidElement score;

    @AndroidFindBy(accessibility = "poster image")
    private AndroidElement poster;

    protected AndroidMovie(WebElement element) {
        super(element);
    }

    @Override
    public String title() {
        return title.getText();
    }

    @Override
    public String score() {
        return score.getText();
    }

    @Override
    public Object getPoster() {
        return poster.getSize();
    }

    @Override
    public void goToReview() {
        ((AndroidElement) getWrappedElement()).tap(1, 1500);
    }
}
