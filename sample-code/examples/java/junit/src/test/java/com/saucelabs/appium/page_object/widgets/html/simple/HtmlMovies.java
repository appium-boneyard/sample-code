package com.saucelabs.appium.page_object.widgets.html.simple;

import com.saucelabs.appium.page_object.widgets.Movie;
import com.saucelabs.appium.page_object.widgets.Movies;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.support.FindBy;

import java.util.List;

public class HtmlMovies extends Movies {

    @FindBy(className = "mb-movie")
    List<HtmlMovie> movieList;

    /*
    There could be additional behavior.
    But for test it is enough.
     */

    protected HtmlMovies(WebElement element) {
        super(element);
    }

    @Override
    public int getMovieCount() {
        return movieList.size();
    }

    @Override
    public Movie getMovie(int index) {
        return movieList.get(index);
    }
}
