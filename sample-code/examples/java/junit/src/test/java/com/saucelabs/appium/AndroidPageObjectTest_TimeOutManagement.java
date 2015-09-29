package com.saucelabs.appium;

import com.saucelabs.appium.page_object.PageObjectWithCustomizedTimeOuts;
import io.appium.java_client.MobileElement;
import io.appium.java_client.android.AndroidDriver;
import io.appium.java_client.pagefactory.AppiumFieldDecorator;
import io.appium.java_client.pagefactory.TimeOutDuration;
import io.appium.java_client.remote.MobileCapabilityType;
import org.junit.After;
import org.junit.Before;
import org.junit.Test;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.remote.DesiredCapabilities;
import org.openqa.selenium.support.PageFactory;

import java.io.File;
import java.net.URL;
import java.util.Calendar;
import java.util.List;
import java.util.concurrent.TimeUnit;

import static org.junit.Assert.assertEquals;

/**
 * This sample just demonstrates that the time out customization/changing
 * works fine
 */
public class AndroidPageObjectTest_TimeOutManagement {

    private WebDriver driver;
    private PageObjectWithCustomizedTimeOuts pageObjectWithCustomizedTimeOuts;
    private TimeOutDuration timeOutDuration;
    private final static long ACCEPTABLE_DELTA_MILLS = 1500; //Android UIAutomator sometimes
    //is very slow

    @Before
    public void setUp() throws Exception {
        File classpathRoot = new File(System.getProperty("user.dir"));
        File appDir = new File(classpathRoot, "../../../apps/ApiDemos/bin");
        File app = new File(appDir, "ApiDemos-debug.apk");
        DesiredCapabilities capabilities = new DesiredCapabilities();
        capabilities.setCapability(MobileCapabilityType.DEVICE_NAME, "Android Emulator");
        capabilities.setCapability(MobileCapabilityType.APP, app.getAbsolutePath());
        driver = new AndroidDriver<MobileElement>(new URL("http://127.0.0.1:4723/wd/hub"), capabilities);
        timeOutDuration = new TimeOutDuration(1, TimeUnit.SECONDS); /* This object can be passed through
        the constructor of AppiumFieldDecorator. It allows users to set general timeout
        of the waiting for elements conveniently and change it when it is needed.
        */

        pageObjectWithCustomizedTimeOuts = new PageObjectWithCustomizedTimeOuts();
        //This time out is set because test can be run on slow Android SDK emulator
        PageFactory.initElements(new AppiumFieldDecorator(driver, timeOutDuration),
                pageObjectWithCustomizedTimeOuts);
    }

    @After
    public void tearDown() throws Exception {
        driver.quit();
    }

    private static void checkTimeDifference(long expectedTime,
                                            TimeUnit timeUnit, long currentMillis) {
        long expectedMillis = TimeUnit.MILLISECONDS.convert(expectedTime,
                timeUnit);
        try {
            assertEquals(true,
                    ((currentMillis - expectedMillis) < ACCEPTABLE_DELTA_MILLS)
                            && ((currentMillis - expectedMillis) >= 0));
        }
        catch (Error e){
            String message = String.valueOf(expectedTime) + " "  + timeUnit.toString() + " current duration in millis " +
                    String.valueOf(currentMillis) + " Failed";
            throw new RuntimeException(message, e);
        }
    }

    private long getBenchMark(List<MobileElement> stubElements) {
        long startMark = Calendar.getInstance().getTimeInMillis();
        stubElements.size();
        long endMark = Calendar.getInstance().getTimeInMillis();
        return endMark - startMark;
    }

    /**
     * Please read about Page Object design pattern here:
     *  https://code.google.com/p/selenium/wiki/PageObjects
     */
     /**
     * Page Object best practice is to describe interactions with target
     * elements by methods. These methods describe business logic of the page/screen.
     * Here test interacts with lazy instantiated elements directly.
     * It was done so just for obviousness
     */

    @Test
    public void test() {
        checkTimeDifference(AppiumFieldDecorator.DEFAULT_IMPLICITLY_WAIT_TIMEOUT, AppiumFieldDecorator.DEFAULT_TIMEUNIT,
                getBenchMark(pageObjectWithCustomizedTimeOuts.stubElements));
        System.out.println(String.valueOf(AppiumFieldDecorator.DEFAULT_IMPLICITLY_WAIT_TIMEOUT)
                + " " + AppiumFieldDecorator.DEFAULT_TIMEUNIT.toString() + ": Fine");

        timeOutDuration.setTime(15500000, TimeUnit.MICROSECONDS);
        checkTimeDifference(15500000, TimeUnit.MICROSECONDS, getBenchMark(pageObjectWithCustomizedTimeOuts.stubElements));
        System.out.println("Change time: " + String.valueOf(15500000) + " "
                + TimeUnit.MICROSECONDS.toString() + ": Fine");

        timeOutDuration.setTime(3, TimeUnit.SECONDS);
        checkTimeDifference(3, TimeUnit.SECONDS, getBenchMark(pageObjectWithCustomizedTimeOuts.stubElements));
        System.out.println("Change time: " + String.valueOf(3) + " "
                + TimeUnit.SECONDS.toString() + ": Fine");
    }

    @Test
    public void test2() {
        checkTimeDifference(AppiumFieldDecorator.DEFAULT_IMPLICITLY_WAIT_TIMEOUT, AppiumFieldDecorator.DEFAULT_TIMEUNIT,
                getBenchMark(pageObjectWithCustomizedTimeOuts.stubElements));
        System.out.println(String.valueOf(AppiumFieldDecorator.DEFAULT_IMPLICITLY_WAIT_TIMEOUT)
                + " " + AppiumFieldDecorator.DEFAULT_TIMEUNIT.toString() + ": Fine");

        checkTimeDifference(5, TimeUnit.SECONDS,
                getBenchMark(pageObjectWithCustomizedTimeOuts.stubElements2));
        System.out.println(String.valueOf(5)
                + " " + TimeUnit.SECONDS.toString() + ": Fine");


        timeOutDuration.setTime(15500000, TimeUnit.MICROSECONDS);
        checkTimeDifference(15500000, TimeUnit.MICROSECONDS, getBenchMark(pageObjectWithCustomizedTimeOuts.stubElements));
        System.out.println("Change time: " + String.valueOf(15500000) + " "
                + TimeUnit.MICROSECONDS.toString() + ": Fine");

        checkTimeDifference(5, TimeUnit.SECONDS,
                getBenchMark(pageObjectWithCustomizedTimeOuts.stubElements2));
        System.out.println(String.valueOf(5)
                + " " + TimeUnit.SECONDS.toString() + ": Fine");

    }
}
