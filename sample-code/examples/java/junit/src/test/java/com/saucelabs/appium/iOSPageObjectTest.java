package com.saucelabs.appium;

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
import com.saucelabs.appium.page_object.ios.UICatalogScreenSimple;

public class iOSPageObjectTest {
	
	private WebDriver driver;
	private UICatalogScreenSimple uiCatalog;
	
	@Before
	public void setUp() throws Exception {
	    File appDir = new File("src/test/java/io/appium/java_client");
	    File app = new File(appDir, "TestApp.app.zip");
	    DesiredCapabilities capabilities = new DesiredCapabilities();
	    capabilities.setCapability(MobileCapabilityType.BROWSER_NAME, "");
	    capabilities.setCapability(MobileCapabilityType.PLATFORM_VERSION, "7.1");
	    capabilities.setCapability(MobileCapabilityType.DEVICE_NAME, "iPhone Simulator");
	    capabilities.setCapability(MobileCapabilityType.APP, app.getAbsolutePath());
	    
	    uiCatalog = new UICatalogScreenSimple();
	    driver = new IOSDriver(new URL("http://127.0.0.1:4723/wd/hub"), capabilities);

		PageFactory.initElements(new AppiumFieldDecorator(driver), uiCatalog);
	}

	@After
	public void tearDown() throws Exception {
		driver.quit();
	}

	@Test
	public void findByElementsTest() {
		Assert.assertNotEquals(0, uiCatalog.uiButtons.size());
	}

	@Test
	public void findByElementTest() {
		Assert.assertNotEquals(null, uiCatalog.uiButton.getText());
	}


	@Test
	public void iOSFindByElementsTest(){
		Assert.assertNotEquals(0, uiCatalog.iosUIButtons.size());
	}

	@Test
	public void iosFindByElementTest(){
		Assert.assertNotEquals(null, uiCatalog.iosUIButton.getText());
	}

	@Test
	public void checkThatElementsWereNotFoundByAndroidUIAutomator(){
		Assert.assertEquals(0, uiCatalog.androidUIAutomatorViews.size());
	}

	@Test
	public void checkThatElementWasNotFoundByAndroidUIAutomator(){
		NoSuchElementException nsee = null;
		try{
			uiCatalog.androidUIAutomatorView.getText();
		}
		catch (Exception e){
			nsee = (NoSuchElementException) e;
		}
		Assert.assertNotNull(nsee);
	}

	@Test
	public void androidOrIOSFindByElementsTest(){
		Assert.assertNotEquals(0, uiCatalog.androidOriOsTextViews.size());
	}

	@Test
	public void androidOrIOSFindByElementTest(){
		Assert.assertNotEquals(null, uiCatalog.androidOriOsTextView.getText());
	}

	@Test
	public void iOSFindByUIAutomatorElementsTest(){
		Assert.assertNotEquals(0, uiCatalog.iosUIAutomatorButtons.size());
	}

	@Test
	public void iOSFindByUIAutomatorElementTest(){
		Assert.assertNotEquals(null, uiCatalog.iosUIAutomatorButton.getText());
	}

	@Test
	public void areMobileElementsTest(){
		Assert.assertNotEquals(0, uiCatalog.mobileButtons.size());
	}

	@Test
	public void isMobileElementTest(){
		Assert.assertNotEquals(null, uiCatalog.mobileButton.getText());
	}

	@Test
	public void areMobileElements_FindByTest(){
		Assert.assertNotEquals(0, uiCatalog.mobiletFindBy_Buttons.size());
	}

	@Test
	public void isMobileElement_FindByTest(){
		Assert.assertNotEquals(null, uiCatalog.mobiletFindBy_Button.getText());
	}

	@Test
	public void areRemoteElementsTest(){
		Assert.assertNotEquals(0, uiCatalog.remoteElementViews.size());
	}

	@Test
	public void isRemoteElementTest(){
		Assert.assertNotEquals(null, uiCatalog.remotetextVieW.getText());
	}

	@Test
	public void checkThatElementsWereNotFoundByAndroidUIAutomator_Chain(){
		Assert.assertEquals(0, uiCatalog.chainElementViews.size());
	}

	@Test
	public void checkThatElementWasNotFoundByAndroidUIAutomator_Chain(){
		NoSuchElementException nsee = null;
		try{
			uiCatalog.chainElementView.getText();
		}
		catch (Exception e){
			nsee = (NoSuchElementException) e;
		}
		Assert.assertNotNull(nsee);
	}
	
	@Test
	public void isIOSElementTest(){
		Assert.assertNotEquals(null, uiCatalog.iosButton.getText());
	}

	@Test
	public void areIOSElements_FindByTest(){
		Assert.assertNotEquals(0, uiCatalog.iosButtons.size());
	}

	@Test
	public void findAllElementsTest(){
		Assert.assertNotEquals(0, uiCatalog.findAllElements.size());
	}

	@Test
	public void findAllElementTest(){
		Assert.assertNotEquals(null, uiCatalog.findAllElement.getText());
	}

}
