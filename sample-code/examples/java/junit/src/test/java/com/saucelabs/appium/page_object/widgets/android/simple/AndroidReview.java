package com.saucelabs.appium.page_object.widgets.android.simple;


import com.saucelabs.appium.page_object.widgets.Review;
import io.appium.java_client.android.AndroidElement;
import io.appium.java_client.pagefactory.AndroidFindBy;
import org.openqa.selenium.WebElement;

public class AndroidReview extends Review {

    @AndroidFindBy(id = "com.codepath.example.rottentomatoes:id/tvTitle")
    private AndroidElement title;

    @AndroidFindBy(uiAutomator = "resourceId(\"com.codepath.example.rottentomatoes:id/tvCriticsScore\")")
    private AndroidElement score;

    @AndroidFindBy(id = "com.codepath.example.rottentomatoes:id/tvSynopsis")
    private AndroidElement synopsis;

    @AndroidFindBy(id = "com.codepath.example.rottentomatoes:id/ivPosterImage")
    private AndroidElement poster;


    protected AndroidReview(WebElement element) {
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
    public String info() {
        return synopsis.getText();
    }

    @Override
    public Object getPoster() {
        return poster.getSize();
    }
}
