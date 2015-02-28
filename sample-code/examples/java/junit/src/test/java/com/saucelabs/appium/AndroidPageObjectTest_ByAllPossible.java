package com.saucelabs.appium;

import io.appium.java_client.android.AndroidDriver;
import io.appium.java_client.pagefactory.AppiumFieldDecorator;
import io.appium.java_client.remote.MobileCapabilityType;

import java.io.File;
import java.net.URL;
import java.util.concurrent.TimeUnit;

import org.junit.After;
import org.junit.Assert;
import org.junit.Before;
import org.junit.Test;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.remote.DesiredCapabilities;
import org.openqa.selenium.support.PageFactory;

import com.saucelabs.appium.page_object.android.ApiDemosListViewScreenByAllPossible;

public class AndroidPageObjectTest_ByAllPossible {

	private WebDriver driver;
	private ApiDemosListViewScreenByAllPossible apiDemosPageObject;
	
	@Before
	public void setUp() throws Exception {
	    File appDir = new File("src/test/java/io/appium/java_client");
	    File app = new File(appDir, "ApiDemos-debug.apk");
	    DesiredCapabilities capabilities = new DesiredCapabilities();
	    capabilities.setCapability(MobileCapabilityType.DEVICE_NAME, "Android Emulator");
	    capabilities.setCapability(MobileCapabilityType.APP, app.getAbsolutePath());
	    driver = new AndroidDriver(new URL("http://127.0.0.1:4723/wd/hub"), capabilities);
        
	    apiDemosPageObject = new ApiDemosListViewScreenByAllPossible();
	    //This time out is set because test can be run on slow Android SDK emulator
		PageFactory.initElements(new AppiumFieldDecorator(driver, 5, TimeUnit.SECONDS), 
				apiDemosPageObject);
	}
	
	@After
	public void tearDown() throws Exception {
		driver.quit();
	}
	
	@Test
	public void findAllElementTest(){
		Assert.assertNotEquals(null, apiDemosPageObject.findAllElementView.getAttribute("text"));
	}	
	
	@Test
	public void findAllElementsTest(){
		Assert.assertNotEquals(0, apiDemosPageObject.findAllElementViews.size());
	}	
}
