package com.saucelabs.appium.page_object.widgets.selendroid;

import com.saucelabs.appium.page_object.widgets.Movie;
import com.saucelabs.appium.page_object.widgets.selendroid.annotated.AnnotatedSelendroidMovies;
import com.saucelabs.appium.page_object.widgets.selendroid.annotated.AnnotatedSelendroidReview;
import com.saucelabs.appium.page_object.widgets.selendroid.extended.ExtendedSelendroidMovies;
import com.saucelabs.appium.page_object.widgets.selendroid.extended.ExtendedSelendroidReview;
import com.saucelabs.appium.page_object.widgets.selendroid.simple.SelendroidMovies;
import com.saucelabs.appium.page_object.widgets.selendroid.simple.SelendroidReview;
import io.appium.java_client.pagefactory.SelendroidFindBy;
import org.apache.commons.lang3.StringUtils;

import static junit.framework.Assert.assertTrue;

/**
 * This is the example of page object with declared Widgets
 * instead of WebElement
 */
public class RottenTomatoesSelendroidApp {

    @SelendroidFindBy(id = "lvMovies")
    private SelendroidMovies simpleMovies;

    @SelendroidFindBy(className = "android.widget.RelativeLayout")
    private SelendroidReview simpleReview;

    private AnnotatedSelendroidMovies annotatedSelendroidMovies;

    private AnnotatedSelendroidReview annotatedSelendroidReview;

    private ExtendedSelendroidMovies extendedSelendroidMovies;

    private ExtendedSelendroidReview extendedSelendroidReview;

    @SelendroidFindBy(id = "fakeId")
    private ExtendedSelendroidMovies fakeMovies;

    @SelendroidFindBy(id = "fakeId")
    private ExtendedSelendroidReview fakeReview;


    public int getSimpleMovieCount(){
        return simpleMovies.getMovieCount();
    }

    public Movie getASimpleMovie(int index){
        return simpleMovies.getMovie(index);
    }

    public void checkSimpleReview(){
        assertTrue(!StringUtils.isBlank(simpleReview.title()));
        assertTrue(!StringUtils.isBlank(simpleReview.score()));
        assertTrue(!StringUtils.isBlank(simpleReview.info()));
        assertTrue(simpleReview.getPoster() != null);
    }

    /////////////////////////////////////////////////////////
    public int getAnnotatedMovieCount(){
        return annotatedSelendroidMovies.getMovieCount();
    }

    public Movie getAnAnnotatedMovie(int index){
        return annotatedSelendroidMovies.getMovie(index);
    }

    public void checkAnnotatedReview(){
        assertTrue(!StringUtils.isBlank(annotatedSelendroidReview.title()));
        assertTrue(!StringUtils.isBlank(annotatedSelendroidReview.score()));
        assertTrue(!StringUtils.isBlank(annotatedSelendroidReview.info()));
        assertTrue(annotatedSelendroidReview.getPoster() != null);
    }
    /////////////////////////////////////////////////////////

    public int getExtendeddMovieCount(){
        return extendedSelendroidMovies.getMovieCount();
    }

    public Movie getAnExtendedMovie(int index){
        return extendedSelendroidMovies.getMovie(index);
    }

    public void checkExtendedReview(){
        assertTrue(!StringUtils.isBlank(extendedSelendroidReview.title()));
        assertTrue(!StringUtils.isBlank(extendedSelendroidReview.score()));
        assertTrue(!StringUtils.isBlank(extendedSelendroidReview.info()));
        assertTrue(extendedSelendroidReview.getPoster() != null);
    }

    /////////////////////////////////////////////////////////

    public int getFakedMovieCount(){
        return fakeMovies.getMovieCount();
    }

    public void checkFakeReview(){
        assertTrue(!StringUtils.isBlank(fakeReview.title()));
        assertTrue(!StringUtils.isBlank(fakeReview.score()));
        assertTrue(!StringUtils.isBlank(fakeReview.info()));
        assertTrue(fakeReview.getPoster() != null);
    }
}
