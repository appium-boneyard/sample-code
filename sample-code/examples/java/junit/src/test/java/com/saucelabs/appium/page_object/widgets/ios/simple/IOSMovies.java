package com.saucelabs.appium.page_object.widgets.ios.simple;

import com.saucelabs.appium.page_object.widgets.Movie;
import com.saucelabs.appium.page_object.widgets.Movies;
import io.appium.java_client.pagefactory.iOSFindBy;
import org.openqa.selenium.WebElement;

import java.util.List;

//classNme = UIATableView
public class IOSMovies extends Movies {

    @iOSFindBy(className = "UIATableCell")
    List<IOSMovie> movieList;

    /*
    There could be additional behavior.
    But for test it is enough.
     */

    protected IOSMovies(WebElement element) {
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
