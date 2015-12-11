package com.saucelabs.appium.page_object.widgets;


import com.saucelabs.appium.page_object.widgets.android.annotated.AnnotatedAndroidMovies;
import com.saucelabs.appium.page_object.widgets.android.annotated.AnnotatedAndroidReview;
import com.saucelabs.appium.page_object.widgets.android.extended.ExtendedAndroidMovies;
import com.saucelabs.appium.page_object.widgets.android.extended.ExtendedAndroidReview;
import com.saucelabs.appium.page_object.widgets.android.simple.AndroidMovies;
import com.saucelabs.appium.page_object.widgets.android.simple.AndroidReview;
import com.saucelabs.appium.page_object.widgets.html.annotated.AnnotatedHtmlMovies;
import com.saucelabs.appium.page_object.widgets.html.annotated.AnnotatedHtmlReview;
import com.saucelabs.appium.page_object.widgets.html.extended.ExtendedHtmlMovies;
import com.saucelabs.appium.page_object.widgets.html.extended.ExtendedHtmlReview;
import com.saucelabs.appium.page_object.widgets.html.simple.HtmlMovies;
import com.saucelabs.appium.page_object.widgets.html.simple.HtmlReview;
import com.saucelabs.appium.page_object.widgets.ios.annotated.AnnotatedIOSMovies;
import com.saucelabs.appium.page_object.widgets.ios.annotated.AnnotatedIOSReview;
import com.saucelabs.appium.page_object.widgets.ios.extended.ExtendedIOSMovies;
import com.saucelabs.appium.page_object.widgets.ios.extended.ExtendedIOSReview;
import com.saucelabs.appium.page_object.widgets.ios.simple.IOSMovies;
import com.saucelabs.appium.page_object.widgets.ios.simple.IOSReview;
import com.saucelabs.appium.page_object.widgets.selendroid.annotated.AnnotatedSelendroidMovies;
import com.saucelabs.appium.page_object.widgets.selendroid.annotated.AnnotatedSelendroidReview;
import com.saucelabs.appium.page_object.widgets.selendroid.extended.ExtendedSelendroidMovies;
import com.saucelabs.appium.page_object.widgets.selendroid.extended.ExtendedSelendroidReview;
import com.saucelabs.appium.page_object.widgets.selendroid.simple.SelendroidMovies;
import com.saucelabs.appium.page_object.widgets.selendroid.simple.SelendroidReview;
import io.appium.java_client.pagefactory.*;
import org.apache.commons.lang3.StringUtils;
import org.openqa.selenium.support.FindBy;

import static junit.framework.Assert.assertTrue;

public class RottenTomatoes {

    @FindBy(id = "movies-collection")
    @AndroidFindBy(id = "com.codepath.example.rottentomatoes:id/lvMovies")
    @SelendroidFindBy(id = "lvMovies")
    @iOSFindBy(className = "UIATableView")
    @OverrideWidget(html = HtmlMovies.class, selendroid = SelendroidMovies.class,
    androidUIAutomator = AndroidMovies.class, iOSUIAutomation = IOSMovies.class)
    private Movies simpleMovies;


    @AndroidFindBys({@AndroidFindBy(id = "android:id/content"),
            @AndroidFindBy(className = "android.widget.RelativeLayout")})
    @FindBy(id = "main_container")
    @SelendroidFindBy(className = "android.widget.RelativeLayout")
    @iOSFindBy(className = "UIAWindow")
    @OverrideWidget(html = HtmlReview.class, selendroid = SelendroidReview.class,
            androidUIAutomator = AndroidReview.class, iOSUIAutomation = IOSReview.class)
    private Review simpleReview;

    @OverrideWidget(html = AnnotatedHtmlMovies.class, selendroid = AnnotatedSelendroidMovies.class,
    androidUIAutomator = AnnotatedAndroidMovies.class, iOSUIAutomation = AnnotatedIOSMovies.class)
    private Movies annotatedMovies;

    @OverrideWidget(html = AnnotatedHtmlReview.class, selendroid = AnnotatedSelendroidReview.class,
            androidUIAutomator = AnnotatedAndroidReview.class, iOSUIAutomation = AnnotatedIOSReview.class)
    private Review annotatedReview;

    @OverrideWidget(html = ExtendedHtmlMovies.class, selendroid = ExtendedSelendroidMovies.class,
            androidUIAutomator = ExtendedAndroidMovies.class, iOSUIAutomation = ExtendedIOSMovies.class)
    private Movies extendedMovies;

    @OverrideWidget(html = ExtendedHtmlReview.class, selendroid = ExtendedSelendroidReview.class,
            androidUIAutomator = ExtendedAndroidReview.class, iOSUIAutomation = ExtendedIOSReview.class)
    private Review extendedReview;


    @FindBy(id = "Fake_ID_For_All_Platforms")
    @AndroidFindBy(id = "Fake_ID_For_All_Platforms")
    @SelendroidFindBy(id = "Fake_ID_For_All_Platforms")
    @iOSFindBy(id = "Fake_ID_For_All_Platforms")
    @OverrideWidget(html = ExtendedHtmlMovies.class, selendroid = ExtendedSelendroidMovies.class,
            androidUIAutomator = ExtendedAndroidMovies.class, iOSUIAutomation = ExtendedIOSMovies.class)
    private Movies fakeMovies;

    @FindBy(id = "Fake_ID_For_All_Platforms")
    @AndroidFindBy(id = "Fake_ID_For_All_Platforms")
    @SelendroidFindBy(id = "Fake_ID_For_All_Platforms")
    @iOSFindBy(id = "Fake_ID_For_All_Platforms")
    @OverrideWidget(html = ExtendedHtmlReview.class, selendroid = ExtendedSelendroidReview.class,
            androidUIAutomator = ExtendedAndroidReview.class, iOSUIAutomation = ExtendedIOSReview.class)
    private Review fakeReview;



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
        return annotatedMovies.getMovieCount();
    }

    public Movie getAnAnnotatedMovie(int index){
        return annotatedMovies.getMovie(index);
    }

    public void checkAnnotatedReview(){
        assertTrue(!StringUtils.isBlank(annotatedReview.title()));
        assertTrue(!StringUtils.isBlank(annotatedReview.score()));
        assertTrue(!StringUtils.isBlank(annotatedReview.info()));
        assertTrue(annotatedReview.getPoster() != null);
    }
    /////////////////////////////////////////////////////////

    public int getExtendeddMovieCount(){
        return extendedMovies.getMovieCount();
    }

    public Movie getAnExtendedMovie(int index){
        return extendedMovies.getMovie(index);
    }

    public void checkExtendedReview(){
        assertTrue(!StringUtils.isBlank(extendedReview.title()));
        assertTrue(!StringUtils.isBlank(extendedReview.score()));
        assertTrue(!StringUtils.isBlank(extendedReview.info()));
        assertTrue(extendedReview.getPoster() != null);
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
