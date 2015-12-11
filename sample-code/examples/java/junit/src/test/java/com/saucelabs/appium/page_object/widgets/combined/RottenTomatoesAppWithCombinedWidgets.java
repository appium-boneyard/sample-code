package com.saucelabs.appium.page_object.widgets.combined;

import com.saucelabs.appium.page_object.widgets.Movie;
import com.saucelabs.appium.page_object.widgets.combined.annotated.AnnotatedCombinedMovies;
import com.saucelabs.appium.page_object.widgets.combined.annotated.AnnotatedCombinedReview;
import com.saucelabs.appium.page_object.widgets.combined.extended.ExtendedCombinedMovies;
import com.saucelabs.appium.page_object.widgets.combined.extended.ExtendedCombinedReview;
import com.saucelabs.appium.page_object.widgets.combined.simple.CombinedMovies;
import com.saucelabs.appium.page_object.widgets.combined.simple.CombinedReview;
import io.appium.java_client.pagefactory.AndroidFindBy;
import io.appium.java_client.pagefactory.AndroidFindBys;
import io.appium.java_client.pagefactory.SelendroidFindBy;
import org.apache.commons.lang3.StringUtils;
import org.openqa.selenium.support.FindBy;

import static junit.framework.Assert.assertTrue;

/**
 * This is the example of page object with declared Widgets
 * instead of WebElement
 */
public class RottenTomatoesAppWithCombinedWidgets {

    @AndroidFindBy(id = "com.codepath.example.rottentomatoes:id/lvMovies")
    @SelendroidFindBy(id = "lvMovies")
    @FindBy(id = "movies-collection")
    private CombinedMovies simpleMovies;

    @AndroidFindBys({@AndroidFindBy(id = "android:id/content"),
            @AndroidFindBy(className = "android.widget.RelativeLayout")})
    @FindBy(id = "main_container")
    @SelendroidFindBy(className = "android.widget.RelativeLayout")
    private CombinedReview simpleReview;

    private AnnotatedCombinedMovies annotatedCombinedMovies;

    private AnnotatedCombinedReview annotatedCombinedReview;

    private ExtendedCombinedMovies extendedCombinedMovies;

    private ExtendedCombinedReview extendedCombinedReview;

    @AndroidFindBy(id = "fakeId")
    @FindBy(id = "fakeId")
    private ExtendedCombinedMovies fakeMovies;

    @AndroidFindBy(id = "fakeId")
    @FindBy(id = "fakeId")
    private ExtendedCombinedReview fakeReview;


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
        return annotatedCombinedMovies.getMovieCount();
    }

    public Movie getAnAnnotatedMovie(int index){
        return annotatedCombinedMovies.getMovie(index);
    }

    public void checkAnnotatedReview(){
        assertTrue(!StringUtils.isBlank(annotatedCombinedReview.title()));
        assertTrue(!StringUtils.isBlank(annotatedCombinedReview.score()));
        assertTrue(!StringUtils.isBlank(annotatedCombinedReview.info()));
        assertTrue(annotatedCombinedReview.getPoster() != null);
    }
    /////////////////////////////////////////////////////////

    public int getExtendeddMovieCount(){
        return extendedCombinedMovies.getMovieCount();
    }

    public Movie getAnExtendedMovie(int index){
        return extendedCombinedMovies.getMovie(index);
    }

    public void checkExtendedReview(){
        assertTrue(!StringUtils.isBlank(extendedCombinedReview.title()));
        assertTrue(!StringUtils.isBlank(extendedCombinedReview.score()));
        assertTrue(!StringUtils.isBlank(extendedCombinedReview.info()));
        assertTrue(extendedCombinedReview.getPoster() != null);
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
