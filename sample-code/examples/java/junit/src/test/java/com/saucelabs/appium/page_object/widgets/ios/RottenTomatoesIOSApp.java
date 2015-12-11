package com.saucelabs.appium.page_object.widgets.ios;


import com.saucelabs.appium.page_object.widgets.Movie;
import com.saucelabs.appium.page_object.widgets.ios.annotated.AnnotatedIOSMovies;
import com.saucelabs.appium.page_object.widgets.ios.annotated.AnnotatedIOSReview;
import com.saucelabs.appium.page_object.widgets.ios.extended.ExtendedIOSMovies;
import com.saucelabs.appium.page_object.widgets.ios.extended.ExtendedIOSReview;
import com.saucelabs.appium.page_object.widgets.ios.simple.IOSMovies;
import com.saucelabs.appium.page_object.widgets.ios.simple.IOSReview;
import io.appium.java_client.pagefactory.iOSFindBy;
import org.apache.commons.lang3.StringUtils;

import static junit.framework.Assert.assertTrue;

/**
 * This is the example of page object with declared Widgets
 * instead of WebElement
 */
public class RottenTomatoesIOSApp {

    @iOSFindBy(className = "UIATableView")
    private IOSMovies simpleMovies;

    @iOSFindBy(className = "UIAWindow")
    private IOSReview simpleReview;

    private AnnotatedIOSMovies annotatedIOSMovies;

    private AnnotatedIOSReview annotatedIOSReview;

    private ExtendedIOSMovies extendedIOSMovies;

    private ExtendedIOSReview extendedIOSReview;

    @iOSFindBy(id = "fakeId")
    private ExtendedIOSMovies fakeMovies;

    @iOSFindBy(id = "fakeId")
    private ExtendedIOSReview fakeReview;


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
        return annotatedIOSMovies.getMovieCount();
    }

    public Movie getAnAnnotatedMovie(int index){
        return annotatedIOSMovies.getMovie(index);
    }

    public void checkAnnotatedReview(){
        assertTrue(!StringUtils.isBlank(annotatedIOSReview.title()));
        assertTrue(!StringUtils.isBlank(annotatedIOSReview.score()));
        assertTrue(!StringUtils.isBlank(annotatedIOSReview.info()));
        assertTrue(annotatedIOSReview.getPoster() != null);
    }
    /////////////////////////////////////////////////////////

    public int getExtendeddMovieCount(){
        return extendedIOSMovies.getMovieCount();
    }

    public Movie getAnExtendedMovie(int index){
        return extendedIOSMovies.getMovie(index);
    }

    public void checkExtendedReview(){
        assertTrue(!StringUtils.isBlank(extendedIOSReview.title()));
        assertTrue(!StringUtils.isBlank(extendedIOSReview.score()));
        assertTrue(!StringUtils.isBlank(extendedIOSReview.info()));
        assertTrue(extendedIOSReview.getPoster() != null);
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
