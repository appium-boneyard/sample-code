package com.saucelabs.appium.page_object.android;

import io.appium.java_client.MobileElement;
import io.appium.java_client.pagefactory.AndroidFindBy;
import io.appium.java_client.pagefactory.iOSFindBy;

import java.util.List;

import org.openqa.selenium.WebElement;
import org.openqa.selenium.remote.RemoteWebElement;
import org.openqa.selenium.support.FindBy;

public class ApiDemosListViewScreenSimple {
	
	@FindBy(className = "android.widget.TextView")
	public List<WebElement> textVieWs;

	@AndroidFindBy(className = "android.widget.TextView")
	public List<WebElement> androidTextViews;

	@iOSFindBy(uiAutomator = ".elements()[0]")
	public List<WebElement> iosTextViews;

	@iOSFindBy(uiAutomator = ".elements()[0]")
	@AndroidFindBy(className = "android.widget.TextView")
	public List<WebElement> androidOriOsTextViews;

	@AndroidFindBy(uiAutomator = "new UiSelector().resourceId(\"android:id/text1\")")
	public List<WebElement> androidUIAutomatorViews;

	@AndroidFindBy(uiAutomator = "new UiSelector().resourceId(\"android:id/text1\")")
	public List<MobileElement> mobileElementViews;

	@FindBy(className = "android.widget.TextView")
	public List<MobileElement> mobiletextVieWs;

	@AndroidFindBy(uiAutomator = "new UiSelector().resourceId(\"android:id/text1\")")
	public List<RemoteWebElement> remoteElementViews;

	@FindBy(id = "android:id/text1")
	public WebElement textView;

	@AndroidFindBy(className = "android.widget.TextView")
	public WebElement androidTextView;

	@iOSFindBy(uiAutomator = ".elements()[0]")
	public WebElement iosTextView;

	@AndroidFindBy(className = "android.widget.TextView")
	@iOSFindBy(uiAutomator = ".elements()[0]")
	public WebElement androidOriOsTextView;

	@AndroidFindBy(uiAutomator = "new UiSelector().resourceId(\"android:id/text1\")")
	public WebElement androidUIAutomatorView;

	@AndroidFindBy(uiAutomator = "new UiSelector().resourceId(\"android:id/text1\")")
	public MobileElement mobileElementView;

	@FindBy(className = "android.widget.TextView")
	public MobileElement mobiletextVieW;

	@AndroidFindBy(uiAutomator = "new UiSelector().resourceId(\"android:id/text1\")")
	public RemoteWebElement remotetextVieW;

}
