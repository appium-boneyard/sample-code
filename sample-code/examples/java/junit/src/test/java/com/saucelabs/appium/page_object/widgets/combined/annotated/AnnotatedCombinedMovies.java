package com.saucelabs.appium.page_object.widgets.combined.annotated;


import com.saucelabs.appium.page_object.widgets.Movie;
import com.saucelabs.appium.page_object.widgets.Movies;
import io.appium.java_client.pagefactory.AndroidFindBy;
import io.appium.java_client.pagefactory.SelendroidFindBy;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.support.FindBy;

import java.util.List;

@AndroidFindBy(id = "com.codepath.example.rottentomatoes:id/lvMovies")
@SelendroidFindBy(id = "lvMovies")
@FindBy(id = "movies-collection")
public class AnnotatedCombinedMovies extends Movies {

    List<AnnotatedCombinedMovie> movieList;

    /*
    There could be additional behavior.
    But for test it is enough.
     */

    protected AnnotatedCombinedMovies(WebElement element) {
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
