package com.saucelabs.appium.page_object.widgets.selendroid.simple;

import com.saucelabs.appium.page_object.widgets.Movie;
import io.appium.java_client.pagefactory.SelendroidFindBy;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.remote.RemoteWebElement;

public class SelendroidMovie extends Movie {

    @SelendroidFindBy(id = "tvTitle")
    private RemoteWebElement title;

    @SelendroidFindBy(id = "tvCriticsScore")
    private RemoteWebElement score;

    @SelendroidFindBy(id = "ivPosterImage")
    private RemoteWebElement poster;

    protected SelendroidMovie(WebElement element) {
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
        getWrappedElement().click();
    }
}
