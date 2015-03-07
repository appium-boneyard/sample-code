package com.saucelabs.appium.page_object.ios;

import io.appium.java_client.MobileElement;
import io.appium.java_client.ios.IOSElement;
import io.appium.java_client.pagefactory.AndroidFindBy;
import io.appium.java_client.pagefactory.iOSFindBy;

import java.util.List;

import org.openqa.selenium.WebElement;
import org.openqa.selenium.remote.RemoteWebElement;
import org.openqa.selenium.support.FindBy;

import com.saucelabs.appium.page_object.android.ApiDemosListViewScreenByAllPossible;
import com.saucelabs.appium.page_object.android.ApiDemosListViewScreenChaided;
import com.saucelabs.appium.page_object.android.ApiDemosListViewScreenSimple;

import io.appium.java_client.pagefactory.AndroidFindBys;
import io.appium.java_client.pagefactory.iOSFindAll;;

/**
 * Here is the common sample shows how to use
 * Appium annotations against iOS. It is perfectly similar
 * as {@link ApiDemosListViewScreenSimple}, {@link ApiDemosListViewScreenChaided}
 * and {@link ApiDemosListViewScreenByAllPossible}
 * 
 * About Page Object design pattern read here:
 * https://code.google.com/p/selenium/wiki/PageObjects
 *
 */
public class TestAppScreenSimple {

	/**
	 * Page Object best practice is to describe interactions with target 
	 * elements by methods. This methods describe business logic of the page/screen.
	 * Here lazy instantiated elements are public.
	 * It was done so just for obviousness
	 */
	
	@FindBy(className = "UIAButton")
	public List<WebElement> uiButtons;

	@FindBy(className = "UIAButton")
	public List<WebElement> iosUIButtons;

	@iOSFindBy(uiAutomator = ".elements()[0]")
	public List<WebElement> iosUIAutomatorButtons;

	@iOSFindBy(uiAutomator = ".elements()[0]")
	@AndroidFindBy(className = "android.widget.TextView")
	public List<WebElement> androidOriOsTextViews;

	@AndroidFindBy(uiAutomator = "new UiSelector().resourceId(\"android:id/text1\")")
	public List<WebElement> androidUIAutomatorViews;

	@iOSFindBy(uiAutomator = ".elements()[0]")
	public List<MobileElement> mobileButtons;

	@FindBy(className = "UIAButton")
	public List<MobileElement> mobiletFindBy_Buttons;

	@iOSFindBy(uiAutomator = ".elements()[0]")
	public List<RemoteWebElement> remoteElementViews;

	@AndroidFindBys({
		@AndroidFindBy(uiAutomator = "new UiSelector().resourceId(\"android:id/list\")"),
		@AndroidFindBy(className = "android.widget.TextView")
		})
	public List<WebElement> chainElementViews;


	@FindBy(className = "UIAButton")
	public WebElement uiButton;

	@FindBy(className = "UIAButton")
	public WebElement iosUIButton;

	@iOSFindBy(uiAutomator = ".elements()[0]")
	public WebElement iosUIAutomatorButton;

	@AndroidFindBy(className = "android.widget.TextView")
	@iOSFindBy(uiAutomator = ".elements()[0]")
	public WebElement androidOriOsTextView;

	@AndroidFindBy(uiAutomator = "new UiSelector().resourceId(\"android:id/text1\")")
	public WebElement androidUIAutomatorView;

	@iOSFindBy(uiAutomator = ".elements()[0]")
	public MobileElement mobileButton;

	@FindBy(className = "UIAButton")
	public MobileElement mobiletFindBy_Button;

	@iOSFindBy(uiAutomator = ".elements()[0]")
	public RemoteWebElement remotetextVieW;

	@AndroidFindBys({
		@AndroidFindBy(uiAutomator = "new UiSelector().resourceId(\"android:id/list\")"),
		@AndroidFindBy(className = "android.widget.TextView")
		})
	public WebElement chainElementView;
	
	@iOSFindBy(uiAutomator = ".elements()[0]")
	public IOSElement iosButton;
	
	@iOSFindBy(uiAutomator = ".elements()[0]")
	public List<IOSElement> iosButtons;
	
	@iOSFindAll({
		@iOSFindBy(xpath = "ComputeSumButton_Test"),	
		@iOSFindBy(name = "ComputeSumButton")	//it is real locator
	})
	public WebElement findAllElement;
	
	@iOSFindAll({
		@iOSFindBy(xpath = "ComputeSumButton_Test"),	
		@iOSFindBy(name = "ComputeSumButton")	//it is real locator
	})
	public List<WebElement> findAllElements;

}
