package com.saucelabs.appium.page_object.android;

import io.appium.java_client.android.AndroidElement;

import java.util.List;

import io.appium.java_client.pagefactory.*;
import org.openqa.selenium.WebElement;

/**
 * Here is the common sample shows how to use
 * {@link AndroidFindBy} annotation to describe the chain of the
 * searching for the target element of a native Android app content.
 * <p>
 * It demonstrates how to declare screen elements using Appium
 * page objects facilities.
 * <p>
 * About Page Object design pattern read here:
 * https://code.google.com/p/selenium/wiki/PageObjects
 */
public class ApiDemosListViewScreenChaided {

    /**
     * Page Object best practice is to describe interactions with target
     * elements by methods. This methods describe business logic of the page/screen.
     * Here lazy instantiated elements are public.
     * It was done so just for obviousness
     */

    @AndroidFindBy(uiAutomator = "new UiSelector().resourceId(\"android:id/list\")")
    //the searching starts here
    @AndroidFindBy(className = "android.widget.TextView") //this element is nested
    //and so on
    public List<WebElement> chainElementViews;

    @AndroidFindBy(uiAutomator = "new UiSelector().resourceId(\"android:id/content\")")
    @AndroidFindBy(uiAutomator = "new UiSelector().resourceId(\"android:id/list\")")
    @AndroidFindBy(id = "android:id/text1")

    @iOSFindBy(uiAutomator = ".elements()[0]")
    @iOSFindBy(xpath = "//someElement")
    public List<WebElement> chainAndroidOrIOSUIAutomatorViews;


    @AndroidFindBy(uiAutomator = "new UiSelector().resourceId(\"android:id/list\")")
    @AndroidFindBy(className = "android.widget.TextView")

    public WebElement chainElementView;

    @AndroidFindBy(uiAutomator = "new UiSelector().resourceId(\"android:id/content\")")
    @AndroidFindBy(uiAutomator = "new UiSelector().resourceId(\"android:id/list\")")
    @AndroidFindBy(id = "android:id/text1")

    @iOSFindBySet({@iOSFindBy(uiAutomator = ".elements()[0]"),
            @iOSFindBy(xpath = "//someElement")})
    public WebElement chainAndroidOrIOSUIAutomatorView;

    @AndroidFindBy(uiAutomator = "new UiSelector().resourceId(\"android:id/content\")")
    @AndroidFindBy(uiAutomator = "new UiSelector().resourceId(\"android:id/list\")")
    @AndroidFindBy(id = "android:id/text1")
    public AndroidElement androidElementView;

    @AndroidFindBy(uiAutomator = "new UiSelector().resourceId(\"android:id/content\")")
    @AndroidFindBy(uiAutomator = "new UiSelector().resourceId(\"android:id/list\")")
    @AndroidFindBy(id = "android:id/text1")
    public List<AndroidElement> androidElementViews;
}
