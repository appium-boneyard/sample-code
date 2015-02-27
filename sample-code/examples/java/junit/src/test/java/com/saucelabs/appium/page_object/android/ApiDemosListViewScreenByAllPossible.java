package com.saucelabs.appium.page_object.android;

import io.appium.java_client.MobileElement;

import java.util.List;
import io.appium.java_client.android.AndroidElement;
import io.appium.java_client.pagefactory.AndroidFindAll;
import io.appium.java_client.pagefactory.AndroidFindBy;

public class ApiDemosListViewScreenByAllPossible {
	
	@AndroidFindAll({
		@AndroidFindBy(uiAutomator = "new UiSelector().resourceId(\"android:id/Fakecontent\")"),
		@AndroidFindBy(id = "android:id/Faketext1"),
		@AndroidFindBy(uiAutomator = "new UiSelector().resourceId(\"android:id/list\")"), //by this locator element is found
		@AndroidFindBy(id = "android:id/FakeId")
		})
	public List<MobileElement> findAllElementViews;
	
	@AndroidFindAll({
		@AndroidFindBy(uiAutomator = "new UiSelector().resourceId(\"android:id/Fakecontent\")"),
		@AndroidFindBy(id = "android:id/Faketext1"),
		@AndroidFindBy(uiAutomator = "new UiSelector().resourceId(\"android:id/list\")"), //by this locator element is found
		@AndroidFindBy(id = "android:id/FakeId")
		})
	public AndroidElement findAllElementView;
}
