package com.saucelabs.appium.page_object.widgets.combined.simple;

import com.saucelabs.appium.page_object.widgets.Movie;
import io.appium.java_client.pagefactory.AndroidFindBy;
import io.appium.java_client.pagefactory.SelendroidFindBy;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.remote.RemoteWebElement;
import org.openqa.selenium.support.FindBy;

public class CombinedMovie extends Movie {

    @AndroidFindBy(id = "com.codepath.example.rottentomatoes:id/tvTitle")
    @SelendroidFindBy(id = "tvTitle")
    @FindBy(className = "movieTitle")
    private RemoteWebElement title;

    @AndroidFindBy(uiAutomator = "resourceId(\"com.codepath.example.rottentomatoes:id/tvCriticsScore\")")
    @FindBy(className = "tMeterScore")
    @SelendroidFindBy(id = "tvCriticsScore")
    private RemoteWebElement score;

    @AndroidFindBy(accessibility = "poster image")
    @SelendroidFindBy(id = "ivPosterImage")
    @FindBy(className = "poster_container")
    private RemoteWebElement poster;

    @AndroidFindBy(accessibility = "poster image")
    @SelendroidFindBy(id = "ivPosterImage")
    @FindBy(xpath = ".//*[@class=\"movie_info\"]/a/h3")
    private RemoteWebElement movieSwitcher;

    protected CombinedMovie(WebElement element) {
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
        movieSwitcher.click();
    }
}
