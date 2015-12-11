package com.saucelabs.appium.page_object.widgets.html.annotated;

import com.saucelabs.appium.page_object.widgets.Movie;
import com.saucelabs.appium.page_object.widgets.Movies;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.support.FindBy;

import java.util.List;

@FindBy(id = "movies-collection")
public class AnnotatedHtmlMovies extends Movies {
    List<AnnotatedHtmlMovie> movieList;

    /*
    There could be additional behavior.
    But for test it is enough.
     */

    protected AnnotatedHtmlMovies(WebElement element) {
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
