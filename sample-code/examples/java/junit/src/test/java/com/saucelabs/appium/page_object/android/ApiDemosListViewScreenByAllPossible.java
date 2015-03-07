package com.saucelabs.appium.page_object.android;

import io.appium.java_client.MobileElement;

import java.util.List;

import io.appium.java_client.android.AndroidElement;
import io.appium.java_client.pagefactory.AndroidFindAll;
import io.appium.java_client.pagefactory.AndroidFindBy;

/**
 * 
 * Here is the common sample shows how to use
 * {@link AndroidFindAll} annotation to describe all possible
 * locators of a target element. This feature should help to
 * reduce the number of page PageObject-classes
 * 
 * It demonstrates how to declare screen elements using Appium
 * page objects facilities.
 * 
 * About Page Object design pattern read here:
 * https://code.google.com/p/selenium/wiki/PageObjects
 *
 */
public class ApiDemosListViewScreenByAllPossible {
	
	/**
	 * Page Object best practice is to describe interactions with target 
	 * elements by methods. This methods describe business logic of the page/screen.
	 * Here lazy instantiated elements are public.
	 * It was done so just for obviousness
	 */
	
	@AndroidFindAll({
		@AndroidFindBy(uiAutomator = "new UiSelector().resourceId(\"android:id/Fakecontent\")"),
		@AndroidFindBy(id = "android:id/Faketext1"),
		@AndroidFindBy(uiAutomator = "new UiSelector().resourceId(\"android:id/list\")"), //by this locator element is found
		@AndroidFindBy(id = "android:id/FakeId")
		}) //If here is a list then it will be filled by all elements
	//which are found using all declared locators
	public List<MobileElement> findAllElementViews;
	
	@AndroidFindAll({
		@AndroidFindBy(uiAutomator = "new UiSelector().resourceId(\"android:id/Fakecontent\")"),
		@AndroidFindBy(id = "android:id/Faketext1"),
		@AndroidFindBy(uiAutomator = "new UiSelector().resourceId(\"android:id/list\")"), //by this locator element is found
		@AndroidFindBy(id = "android:id/FakeId")
		}) //If here is a single element then it will find the first 
	//element that is found by any of declared locators
	public AndroidElement findAllElementView;
}
