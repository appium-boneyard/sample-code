package com.saucelabs.appium.page_object.widgets.combined.simple;


import com.saucelabs.appium.page_object.widgets.Review;
import io.appium.java_client.pagefactory.AndroidFindBy;
import io.appium.java_client.pagefactory.SelendroidFindBy;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.remote.RemoteWebElement;
import org.openqa.selenium.support.FindBy;

public class CombinedReview extends Review {

    @AndroidFindBy(id = "com.codepath.example.rottentomatoes:id/tvTitle")
    @FindBy(id = "movie-title")
    @SelendroidFindBy(id = "tvTitle")
    private RemoteWebElement title;

    @AndroidFindBy(uiAutomator = "resourceId(\"com.codepath.example.rottentomatoes:id/tvCriticsScore\")")
    @SelendroidFindBy(id = "tvCriticsScore")
    @FindBy(xpath = ".//*[@id=\"tomato_meter_link\"]//*[@itemprop=\"ratingValue\"]")
    private RemoteWebElement score;

    @AndroidFindBy(id = "com.codepath.example.rottentomatoes:id/tvSynopsis")
    @SelendroidFindBy(id = "tvSynopsis")
    private RemoteWebElement movieSynopsis;

    @AndroidFindBy(id = "com.codepath.example.rottentomatoes:id/ivPosterImage")
    @SelendroidFindBy(id = "ivPosterImage")
    @FindBy(className = "videoPic")
    private RemoteWebElement poster;


    protected CombinedReview(WebElement element) {
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
        return movieSynopsis.getText();
    }

    @Override
    public Object getPoster() {
        return poster.getSize();
    }
}
