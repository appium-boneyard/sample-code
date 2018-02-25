import com.saucelabs.common.SauceOnDemandAuthentication;
import com.saucelabs.common.SauceOnDemandSessionIdProvider;
import com.saucelabs.junit.SauceOnDemandTestWatcher;
import io.appium.java_client.MobileElement;
import io.appium.java_client.ios.IOSDriver;
import io.appium.java_client.remote.MobileCapabilityType;
import junit.framework.TestCase;
import org.junit.After;
import org.junit.Before;
import org.junit.Rule;
import org.junit.Test;
import org.junit.rules.TestName;
import org.openqa.selenium.remote.DesiredCapabilities;

import java.net.MalformedURLException;
import java.net.URL;
import java.util.concurrent.TimeUnit;

import static junit.framework.Assert.assertEquals;
import static junit.framework.TestCase.assertTrue;

public class SimpleIOSSauceTests implements SauceOnDemandSessionIdProvider {
  final private String USERNAME = System.getenv("SAUCE_USERNAME");
  final private String ACCESS_KEY = System.getenv("SAUCE_ACCESS_KEY");
  private SauceOnDemandAuthentication authentication = new SauceOnDemandAuthentication(USERNAME, ACCESS_KEY);

  private IOSDriver<MobileElement> driver;
  private String sessionId;

  @Rule
  public SauceOnDemandTestWatcher resultReportingTestWatcher = new SauceOnDemandTestWatcher(this, authentication);

  public String getSessionId() {
    return sessionId;
  }

  public @Rule TestName name = new TestName();

  @Before
  public void setUp() throws MalformedURLException {
    DesiredCapabilities desiredCapabilities = new DesiredCapabilities();
    desiredCapabilities.setCapability(MobileCapabilityType.PLATFORM_NAME, "iOS");
    desiredCapabilities.setCapability(MobileCapabilityType.PLATFORM_VERSION, "11.2");
    desiredCapabilities.setCapability(MobileCapabilityType.DEVICE_NAME, "iPhone Simulator");
    desiredCapabilities.setCapability(MobileCapabilityType.APP, "http://appium.s3.amazonaws.com/TestApp6.0.app.zip");
    desiredCapabilities.setCapability("name", name.getMethodName());

    URL sauceUrl = new URL("https://" + authentication.getUsername() + ":"+ authentication.getAccessKey() + "@ondemand.saucelabs.com:443/wd/hub");

    driver = new IOSDriver<MobileElement>(sauceUrl, desiredCapabilities);
    driver.manage().timeouts().implicitlyWait(30, TimeUnit.SECONDS);
    sessionId = driver.getSessionId().toString();
  }

  @After
  public void tearDown() {
    System.out.println("Link to your job: https://saucelabs.com/jobs/" + this.getSessionId());
    driver.quit();
  }

  @Test
  public void testUIComputation() {

    // populate text fields with values
    MobileElement fieldOne = driver.findElementByAccessibilityId("TextField1");
    fieldOne.sendKeys("12");

    MobileElement fieldTwo = driver.findElementsByClassName("UIATextField").get(1);
    fieldTwo.sendKeys("8");

    // they should be the same size, and the first should be above the second
    assertTrue(fieldOne.getLocation().getY() < fieldTwo.getLocation().getY());
    assertEquals(fieldOne.getSize(), fieldTwo.getSize());

    // trigger computation by using the button
    driver.findElementByAccessibilityId("ComputeSumButton").click();

    // is sum equal?
    String sum = driver.findElementsByClassName("UIAStaticText").get(0).getText();
    TestCase.assertEquals(Integer.parseInt(sum), 20);
  }

}
