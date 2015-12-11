package com.saucelabs.appium.page_object.widgets.android.simple;


import com.saucelabs.appium.page_object.widgets.Movie;
import com.saucelabs.appium.page_object.widgets.Movies;
import io.appium.java_client.pagefactory.AndroidFindBy;
import org.openqa.selenium.WebElement;

import java.util.List;

public class AndroidMovies extends Movies {

    @AndroidFindBy(className = "android.widget.RelativeLayout")
    List<AndroidMovie> movieList;

    /*
    There could be additional behavior.
    But for test it is enough.
     */

    protected AndroidMovies(WebElement element) {
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
