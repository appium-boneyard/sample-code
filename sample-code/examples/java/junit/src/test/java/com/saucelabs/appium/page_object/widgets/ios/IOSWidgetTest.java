package com.saucelabs.appium.page_object.widgets.ios;

import com.saucelabs.appium.page_object.widgets.Movie;
import com.saucelabs.appium.page_object.widgets.WidgetTest;
import io.appium.java_client.ios.IOSDriver;
import io.appium.java_client.pagefactory.AppiumFieldDecorator;
import io.appium.java_client.pagefactory.TimeOutDuration;
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

public class IOSWidgetTest implements WidgetTest {

    private IOSDriver<?> driver;
    private RottenTomatoesIOSApp rottenTomatoesApp;

    @Before
    public void setUp() throws Exception {
        File appDir = new File("../../../apps");
        File app = new File(appDir, "RottenTomatoes.zip");

        DesiredCapabilities capabilities = new DesiredCapabilities();
        capabilities.setCapability(MobileCapabilityType.BROWSER_NAME, "");
        capabilities.setCapability(MobileCapabilityType.PLATFORM_VERSION, "7.1");
        capabilities.setCapability(MobileCapabilityType.DEVICE_NAME, "iPhone Simulator");
        capabilities.setCapability(MobileCapabilityType.APP, app.getAbsolutePath());
        driver = new IOSDriver<>(new URL("http://127.0.0.1:4723/wd/hub"), capabilities);

        rottenTomatoesApp = new RottenTomatoesIOSApp();
        PageFactory.initElements(new AppiumFieldDecorator(driver, new TimeOutDuration(5, TimeUnit.SECONDS)), rottenTomatoesApp);
    }

    @After
    public void tearDown() {
        if (driver != null)
            driver.quit();
    }

    @Test
    @Override
    public void checkACommonWidget() {
        assertTrue(rottenTomatoesApp.getSimpleMovieCount() >= 1);
        Movie movie = rottenTomatoesApp.getASimpleMovie(0);
        assertTrue(!StringUtils.isBlank(movie.title()));
        assertTrue(!StringUtils.isBlank(movie.score()));
        assertNotNull(movie.getPoster());
        movie.goToReview();

        rottenTomatoesApp.checkSimpleReview();
    }

    @Override
    @Test
    public void checkAnAnnotatedWidget() {
        assertTrue(rottenTomatoesApp.getAnnotatedMovieCount() >= 1);
        Movie movie = rottenTomatoesApp.getAnAnnotatedMovie(0);
        assertTrue(!StringUtils.isBlank(movie.title()));
        assertTrue(!StringUtils.isBlank(movie.score()));
        assertNotNull(movie.getPoster());
        movie.goToReview();

        rottenTomatoesApp.checkAnnotatedReview();
    }


    @Override
    @Test
    public void checkAnExtendedWidget() {
        assertTrue(rottenTomatoesApp.getExtendeddMovieCount() >= 1);
        Movie movie = rottenTomatoesApp.getAnExtendedMovie(0);
        assertTrue(!StringUtils.isBlank(movie.title()));
        assertTrue(!StringUtils.isBlank(movie.score()));
        assertNotNull(movie.getPoster());
        movie.goToReview();

        rottenTomatoesApp.checkExtendedReview();
    }

    @Override
    @Test
    public void checkTheLocatorOverridingOnAWidget() {
        try {
            assertTrue(rottenTomatoesApp.getFakedMovieCount() == 0);
        }
        catch (Exception e){
            if (!NoSuchElementException.class.isAssignableFrom(e.getClass()))
                throw e;
        }

        rottenTomatoesApp.getASimpleMovie(0).goToReview();

        try {
            rottenTomatoesApp.checkFakeReview();
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
