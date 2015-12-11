package com.saucelabs.appium.page_object.widgets.ios.annotated;

import com.saucelabs.appium.page_object.widgets.Movie;
import com.saucelabs.appium.page_object.widgets.Movies;
import io.appium.java_client.pagefactory.iOSFindBy;
import org.openqa.selenium.WebElement;

import java.util.List;

@iOSFindBy(className = "UIATableView")
public class AnnotatedIOSMovies extends Movies {

    List<AnnotatedIOSMovie> movieList;

    /*
    There could be additional behavior.
    But for test it is enough.
     */

    protected AnnotatedIOSMovies(WebElement element) {
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
