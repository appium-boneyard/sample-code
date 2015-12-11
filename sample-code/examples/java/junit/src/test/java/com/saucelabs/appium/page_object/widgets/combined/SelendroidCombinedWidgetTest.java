package com.saucelabs.appium.page_object.widgets.combined;

import com.saucelabs.appium.page_object.widgets.Movie;
import com.saucelabs.appium.page_object.widgets.WidgetTest;
import io.appium.java_client.android.AndroidDriver;
import io.appium.java_client.pagefactory.AppiumFieldDecorator;
import io.appium.java_client.pagefactory.TimeOutDuration;
import io.appium.java_client.remote.AutomationName;
import io.appium.java_client.remote.MobileCapabilityType;
import org.apache.commons.lang3.StringUtils;
import org.junit.*;
import org.openqa.selenium.NoSuchElementException;
import org.openqa.selenium.remote.DesiredCapabilities;
import org.openqa.selenium.support.PageFactory;

import java.io.File;
import java.net.URL;
import java.util.concurrent.TimeUnit;

import static org.junit.Assert.assertNotNull;
import static org.junit.Assert.assertTrue;

public class SelendroidCombinedWidgetTest implements WidgetTest {
    private static int SELENDROID_PORT = 9999;

    private AndroidDriver<?> driver;
    private RottenTomatoesAppWithCombinedWidgets rottenTomatoes;
    private TimeOutDuration duration;

    @Before
    public void setUp() throws Exception {
        File appDir = new File("../../../apps");
        File app = new File(appDir, "android-rottentomatoes-demo-debug.apk");
        DesiredCapabilities capabilities = new DesiredCapabilities();
        capabilities.setCapability(MobileCapabilityType.DEVICE_NAME, "Android Emulator");
        capabilities.setCapability(MobileCapabilityType.APP, app.getAbsolutePath());
        capabilities.setCapability(MobileCapabilityType.SELENDROID_PORT, SELENDROID_PORT);
        capabilities.setCapability("automationName", AutomationName.SELENDROID);
        driver = new AndroidDriver(new URL("http://127.0.0.1:4723/wd/hub"), capabilities);

        duration = new TimeOutDuration(20, TimeUnit.SECONDS);
        rottenTomatoes = new RottenTomatoesAppWithCombinedWidgets();
        PageFactory.initElements(new AppiumFieldDecorator(driver, duration), rottenTomatoes);
    }

    @After
    public void tearDown() throws Exception {
        if (driver != null) {
            driver.quit();
        }
    }

    @Test
    @Override
    public void checkACommonWidget() {
        assertTrue(rottenTomatoes.getSimpleMovieCount() >= 1);
        Movie movie = rottenTomatoes.getASimpleMovie(0);
        assertTrue(!StringUtils.isBlank(movie.title()));
        assertTrue(!StringUtils.isBlank(movie.score()));
        assertNotNull(movie.getPoster());
        movie.goToReview();
        driver.getPageSource();  //forcing the refreshing hierarchy
        rottenTomatoes.checkSimpleReview();
    }

    @Override
    @Test
    public void checkAnAnnotatedWidget() {
        assertTrue(rottenTomatoes.getAnnotatedMovieCount() >= 1);
        Movie movie = rottenTomatoes.getAnAnnotatedMovie(0);
        assertTrue(!StringUtils.isBlank(movie.title()));
        assertTrue(!StringUtils.isBlank(movie.score()));
        assertNotNull(movie.getPoster());
        movie.goToReview();
        driver.getPageSource();  //forcing the refreshing hierarchy
        rottenTomatoes.checkAnnotatedReview();
    }


    @Override
    @Test
    public void checkAnExtendedWidget() {
        assertTrue(rottenTomatoes.getExtendeddMovieCount() >= 1);
        Movie movie = rottenTomatoes.getAnExtendedMovie(0);
        assertTrue(!StringUtils.isBlank(movie.title()));
        assertTrue(!StringUtils.isBlank(movie.score()));
        assertNotNull(movie.getPoster());
        movie.goToReview();
        driver.getPageSource();  //forcing the refreshing hierarchy
        rottenTomatoes.checkExtendedReview();
    }

    @Override
    @Test
    public void checkTheLocatorOverridingOnAWidget() {
        duration.setTime(5);
        try {
            assertTrue(rottenTomatoes.getFakedMovieCount() == 0);
        }
        catch (Exception e){
            if (!NoSuchElementException.class.isAssignableFrom(e.getClass()))
                throw e;
        }

        rottenTomatoes.getASimpleMovie(0).goToReview();
        driver.getPageSource();  //forcing the refreshing hierarchy
        try {
            rottenTomatoes.checkFakeReview();
        }
        catch (Exception e){
            if (NoSuchElementException.class.isAssignableFrom(e.getClass()))
                return;
            else
                throw e;
        }
        throw new RuntimeException("Any exception was expected");
    }
}
