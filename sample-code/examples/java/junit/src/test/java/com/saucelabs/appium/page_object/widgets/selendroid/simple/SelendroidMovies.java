package com.saucelabs.appium.page_object.widgets.selendroid.simple;


import com.saucelabs.appium.page_object.widgets.Movie;
import com.saucelabs.appium.page_object.widgets.Movies;
import io.appium.java_client.pagefactory.SelendroidFindBy;
import org.openqa.selenium.WebElement;

import java.util.List;

public class SelendroidMovies extends Movies {

    @SelendroidFindBy(className = "android.widget.RelativeLayout")
    List<SelendroidMovie> movieList;

    /*
    There could be additional behavior.
    But for test it is enough.
     */

    protected SelendroidMovies(WebElement element) {
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
