package com.saucelabs.appium.page_object.android;

import io.appium.java_client.android.AndroidElement;
import java.util.List;
import org.openqa.selenium.WebElement;
import io.appium.java_client.pagefactory.AndroidFindBy;
import io.appium.java_client.pagefactory.AndroidFindBys;
import io.appium.java_client.pagefactory.iOSFindBy;
import io.appium.java_client.pagefactory.iOSFindBys;

public class ApiDemosListViewScreenChaided {
	

	@AndroidFindBys({
		@AndroidFindBy(uiAutomator = "new UiSelector().resourceId(\"android:id/list\")"),
		@AndroidFindBy(className = "android.widget.TextView")
		})
	public List<WebElement> chainElementViews;

	@AndroidFindBys({
		@AndroidFindBy(uiAutomator = "new UiSelector().resourceId(\"android:id/content\")"),
		@AndroidFindBy(uiAutomator = "new UiSelector().resourceId(\"android:id/list\")"),
		@AndroidFindBy(id = "android:id/text1")
		})
	@iOSFindBys({@iOSFindBy(uiAutomator = ".elements()[0]"),
		@iOSFindBy(xpath = "//someElement")})
	public List<WebElement> chainAndroidOrIOSUIAutomatorViews;


	@AndroidFindBys({
		@AndroidFindBy(uiAutomator = "new UiSelector().resourceId(\"android:id/list\")"),
		@AndroidFindBy(className = "android.widget.TextView")
		})
	public WebElement chainElementView;


	@AndroidFindBys({
		@AndroidFindBy(uiAutomator = "new UiSelector().resourceId(\"android:id/content\")"),
		@AndroidFindBy(uiAutomator = "new UiSelector().resourceId(\"android:id/list\")"),
		@AndroidFindBy(id = "android:id/text1")
		})
	@iOSFindBys({@iOSFindBy(uiAutomator = ".elements()[0]"),
		@iOSFindBy(xpath = "//someElement")})
	public WebElement chainAndroidOrIOSUIAutomatorView;
	
	@AndroidFindBys({
		@AndroidFindBy(uiAutomator = "new UiSelector().resourceId(\"android:id/content\")"),
		@AndroidFindBy(uiAutomator = "new UiSelector().resourceId(\"android:id/list\")"),
		@AndroidFindBy(id = "android:id/text1")
		})
	public AndroidElement androidElementView;
	
	@AndroidFindBys({
		@AndroidFindBy(uiAutomator = "new UiSelector().resourceId(\"android:id/content\")"),
		@AndroidFindBy(uiAutomator = "new UiSelector().resourceId(\"android:id/list\")"),
		@AndroidFindBy(id = "android:id/text1")
		})
	public List<AndroidElement> androidElementViews;
}
