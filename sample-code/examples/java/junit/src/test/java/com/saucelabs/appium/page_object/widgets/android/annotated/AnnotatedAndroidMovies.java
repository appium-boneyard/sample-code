package com.saucelabs.appium.page_object.widgets.android.annotated;

import com.saucelabs.appium.page_object.widgets.Movie;
import com.saucelabs.appium.page_object.widgets.Movies;
import io.appium.java_client.pagefactory.AndroidFindBy;
import org.openqa.selenium.WebElement;

import java.util.List;

@AndroidFindBy(id = "com.codepath.example.rottentomatoes:id/lvMovies")
public class AnnotatedAndroidMovies extends Movies {

    List<AnnotatedAndroidMovie> movieList;

    /*
    There could be additional behavior.
    But for test it is enough.
     */

    protected AnnotatedAndroidMovies(WebElement element) {
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
