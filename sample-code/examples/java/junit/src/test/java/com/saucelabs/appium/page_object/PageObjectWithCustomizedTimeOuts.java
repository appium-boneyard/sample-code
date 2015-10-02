package com.saucelabs.appium.page_object;

import io.appium.java_client.MobileElement;
import io.appium.java_client.pagefactory.WithTimeout;
import org.openqa.selenium.support.FindBy;

import java.util.List;
import java.util.concurrent.TimeUnit;

public class PageObjectWithCustomizedTimeOuts {

    /**
     * Page Object best practice is to describe interactions with target
     * elements by methods. This methods describe business logic of the page/screen.
     * Here lazy instantiated elements are public.
     * It was done so just for obviousness
     */

    @FindBy(className = "OneClassWhichDoesNotExist")
    public List<MobileElement> stubElements;

    /*Any timeout of the waiting for element/list of elements
      can be customized if the general time duration is
      not suitable. E.g. the element is rendered for a long time
      or the element is used just for instant checkings/assertions
     */
    @WithTimeout(time = 5, unit = TimeUnit.SECONDS)
    @FindBy(className = "OneAnotherClassWhichDoesNotExist")
    public List<MobileElement> stubElements2;
}
