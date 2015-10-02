package com.saucelabs.appium;

import io.appium.java_client.MobileElement;
import io.appium.java_client.ios.IOSDriver;
import io.appium.java_client.pagefactory.AppiumFieldDecorator;
import io.appium.java_client.remote.MobileCapabilityType;

import java.io.File;
import java.net.URL;

import org.junit.After;
import org.junit.Assert;
import org.junit.Before;
import org.junit.Test;
import org.openqa.selenium.NoSuchElementException;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.remote.DesiredCapabilities;
import org.openqa.selenium.support.PageFactory;

import com.saucelabs.appium.page_object.android.ApiDemosListViewScreenByAllPossible;
import com.saucelabs.appium.page_object.android.ApiDemosListViewScreenChaided;
import com.saucelabs.appium.page_object.android.ApiDemosListViewScreenSimple;
import com.saucelabs.appium.page_object.ios.TestAppScreenSimple;

/**
 * Please read about Page Object design pattern here:
 *  https://code.google.com/p/selenium/wiki/PageObjects
 *  
 *  Please look at:
 *  {@link ApiDemosListViewScreenSimple}
 *  {@link ApiDemosListViewScreenChaided}
 *  {@link ApiDemosListViewScreenByAllPossible}
 *  {@link TestAppScreenSimple}
 *
 */
public class iOSPageObjectTest {
	
	private WebDriver driver;
	private TestAppScreenSimple uiTestApp;
	
	@Before
	public void setUp() throws Exception {
        File appDir = new File(System.getProperty("user.dir"), 
        		"../../../apps/TestApp/build/release-iphonesimulator");
        File app = new File(appDir, "TestApp.app");
	    DesiredCapabilities capabilities = new DesiredCapabilities();
	    capabilities.setCapability(MobileCapabilityType.BROWSER_NAME, "");
	    capabilities.setCapability(MobileCapabilityType.PLATFORM_VERSION, "7.1");
	    capabilities.setCapability(MobileCapabilityType.DEVICE_NAME, "iPhone Simulator");
	    capabilities.setCapability(MobileCapabilityType.APP, app.getAbsolutePath());
	    
	    uiTestApp = new TestAppScreenSimple();
	    driver = new IOSDriver<MobileElement>(new URL("http://127.0.0.1:4723/wd/hub"), capabilities);

		PageFactory.initElements(new AppiumFieldDecorator(driver), uiTestApp);
	}

	@After
	public void tearDown() throws Exception {
		driver.quit();
	}
	
	/**
	 * Page Object best practice is to describe interactions with target 
	 * elements by methods. These methods describe business logic of the page/screen.
	 * Here test interacts with lazy instantiated elements directly.
	 * It was done so just for obviousness
	 */

	@Test
	public void findByElementsTest() {
		Assert.assertNotEquals(0, uiTestApp.uiButtons.size());
	}

	@Test
	public void findByElementTest() {
		Assert.assertNotEquals(null, uiTestApp.uiButton.getText());
	}


	@Test
	public void iOSFindByElementsTest(){
		Assert.assertNotEquals(0, uiTestApp.iosUIButtons.size());
	}

	@Test
	public void iosFindByElementTest(){
		Assert.assertNotEquals(null, uiTestApp.iosUIButton.getText());
	}

	@Test
	public void checkThatElementsWereNotFoundByAndroidUIAutomator(){
		Assert.assertEquals(0, uiTestApp.androidUIAutomatorViews.size());
	}

	@Test
	public void checkThatElementWasNotFoundByAndroidUIAutomator(){
		NoSuchElementException nsee = null;
		try{
			uiTestApp.androidUIAutomatorView.getText();
		}
		catch (Exception e){
			nsee = (NoSuchElementException) e;
		}
		Assert.assertNotNull(nsee);
	}

	@Test
	public void androidOrIOSFindByElementsTest(){
		Assert.assertNotEquals(0, uiTestApp.androidOriOsTextViews.size());
	}

	@Test
	public void androidOrIOSFindByElementTest(){
		Assert.assertNotEquals(null, uiTestApp.androidOriOsTextView.getText());
	}

	@Test
	public void iOSFindByUIAutomatorElementsTest(){
		Assert.assertNotEquals(0, uiTestApp.iosUIAutomatorButtons.size());
	}

	@Test
	public void iOSFindByUIAutomatorElementTest(){
		Assert.assertNotEquals(null, uiTestApp.iosUIAutomatorButton.getText());
	}

	@Test
	public void areMobileElementsTest(){
		Assert.assertNotEquals(0, uiTestApp.mobileButtons.size());
	}

	@Test
	public void isMobileElementTest(){
		Assert.assertNotEquals(null, uiTestApp.mobileButton.getText());
	}

	@Test
	public void areMobileElements_FindByTest(){
		Assert.assertNotEquals(0, uiTestApp.mobiletFindBy_Buttons.size());
	}

	@Test
	public void isMobileElement_FindByTest(){
		Assert.assertNotEquals(null, uiTestApp.mobiletFindBy_Button.getText());
	}

	@Test
	public void areRemoteElementsTest(){
		Assert.assertNotEquals(0, uiTestApp.remoteElementViews.size());
	}

	@Test
	public void isRemoteElementTest(){
		Assert.assertNotEquals(null, uiTestApp.remotetextVieW.getText());
	}

	@Test
	public void checkThatElementsWereNotFoundByAndroidUIAutomator_Chain(){
		Assert.assertEquals(0, uiTestApp.chainElementViews.size());
	}

	@Test
	public void checkThatElementWasNotFoundByAndroidUIAutomator_Chain(){
		NoSuchElementException nsee = null;
		try{
			uiTestApp.chainElementView.getText();
		}
		catch (Exception e){
			nsee = (NoSuchElementException) e;
		}
		Assert.assertNotNull(nsee);
	}
	
	@Test
	public void isIOSElementTest(){
		Assert.assertNotEquals(null, uiTestApp.iosButton.getText());
	}

	@Test
	public void areIOSElements_FindByTest(){
		Assert.assertNotEquals(0, uiTestApp.iosButtons.size());
	}

	@Test
	public void findAllElementsTest(){
		Assert.assertNotEquals(0, uiTestApp.findAllElements.size());
	}

	@Test
	public void findAllElementTest(){
		Assert.assertNotEquals(null, uiTestApp.findAllElement.getText());
	}

}
