package com.saucelabs.appium.page_object.android;

import io.appium.java_client.MobileElement;
import io.appium.java_client.pagefactory.AndroidFindBy;
import io.appium.java_client.pagefactory.iOSFindBy;

import java.util.List;

import org.openqa.selenium.WebElement;
import org.openqa.selenium.remote.RemoteWebElement;
import org.openqa.selenium.support.FindBy;

/**
 * 
 * Here is the common sample shows how to use
 * {@link FindBy}, {@link AndroidFindBy} and {@link iOSFindBy}
 * annotations.
 * 
 * Also it demonstrates how to declare screen elements using Appium
 * page objects facilities.
 * 
 * About Page Object design pattern read here:
 * https://code.google.com/p/selenium/wiki/PageObjects
 *
 */
public class ApiDemosListViewScreenSimple {
	/**
	 * Page Object best practice is to describe interactions with target 
	 * elements by methods. This methods describe business logic of the page/screen.
	 * Here lazy instantiated elements are public.
	 * It was done so just for obviousness
	 */
	
	
	//Common Selenium @FindBy annotations are effective 
	//against browser apps and web views. They can be used against native 
	//content. But it is useful to know that By.css, By.link, By.partialLinkText
	//are invalid at this case.
	@FindBy(className = "android.widget.TextView")
	public List<WebElement> textVieWs;

	//@AndroidFindBy annotation is designed to be used for Android native content 
	//description.
	@AndroidFindBy(className = "android.widget.TextView")
	public List<WebElement> androidTextViews;

	@iOSFindBy(uiAutomator = ".elements()[0]")
	public List<WebElement> iosTextViews;

	//if it is necessary to use the same Page Object 
	//in the browser and cross platform mobile app testing
	//then it is possible to combine different annotations
	@FindBy(css = "someBrowserCss") //this locator is used when here is browser (desktop or mobile)
	@iOSFindBy(uiAutomator = ".elements()[0]") //this locator is used when here is iOS native content
	@AndroidFindBy(className = "android.widget.TextView") //this locator is used when here is Android 
	//native content
	public List<WebElement> androidOriOsTextViews;

	@AndroidFindBy(uiAutomator = "new UiSelector().resourceId(\"android:id/text1\")")
	public List<WebElement> androidUIAutomatorViews;

	@AndroidFindBy(uiAutomator = "new UiSelector().resourceId(\"android:id/text1\")")
	public List<MobileElement> mobileElementViews; //Also with Appium page object tools it is
	//possible to declare RemoteWebElement or any MobileElement subclass

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
