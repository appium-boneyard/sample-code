package com.saucelabs.appium.page_object.widgets.selendroid.annotated;


import com.saucelabs.appium.page_object.widgets.Movie;
import com.saucelabs.appium.page_object.widgets.Movies;
import io.appium.java_client.pagefactory.SelendroidFindBy;
import org.openqa.selenium.WebElement;

import java.util.List;

@SelendroidFindBy(id = "lvMovies")
public class AnnotatedSelendroidMovies extends Movies {

    List<AnnotatedSelendroidMovie> movieList;

    /*
    There could be additional behavior.
    But for test it is enough.
     */

    protected AnnotatedSelendroidMovies(WebElement element) {
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
