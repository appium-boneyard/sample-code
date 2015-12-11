package com.saucelabs.appium.page_object.widgets;

import io.appium.java_client.pagefactory.Widget;
import org.openqa.selenium.WebElement;

public abstract class Movies extends Widget {

    protected Movies(WebElement element) {
        super(element);
    }

    public abstract int getMovieCount();

    public abstract Movie getMovie(int index);
}
