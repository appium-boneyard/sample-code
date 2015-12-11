package com.saucelabs.appium.page_object.widgets.html.simple;

import com.saucelabs.appium.page_object.widgets.Review;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.support.FindBy;

public class HtmlReview extends Review {

    @FindBy(id = "movie-title")
    private WebElement title;

    @FindBy(xpath = ".//*[@id=\"tomato_meter_link\"]//*[@itemprop=\"ratingValue\"]")
    private WebElement score;

    private WebElement movieSynopsis;

    @FindBy(className = "videoPic")
    private WebElement poster;


    protected HtmlReview(WebElement element) {
        super(element);
    }

    @Override
    public String title() {
        return title.getText();
    }

    @Override
    public String score() {
        return score.getText();
    }

    @Override
    public String info() {
        return movieSynopsis.getText();
    }

    @Override
    public Object getPoster() {
        return poster.getSize();
    }
}
