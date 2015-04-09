"""An example of Appium running on Sauce, with a webview.

This test assumes SAUCE_USERNAME and SAUCE_ACCESS_KEY are environment variables
set to your Sauce Labs username and access key."""

from random import randint
from appium import webdriver
from appium import SauceTestCase, on_platforms
from time import sleep

from selenium.webdriver.common.keys import Keys

app = 'http://appium.s3.amazonaws.com/WebViewApp6.0.app.zip'
platforms = [{
        'platformName': 'iOS',
        'platformVersion': '7.1',
        'deviceName': 'iPhone Simulator',
        'appiumVersion': '1.3.4',
        'app': app
    }]

@on_platforms(platforms)
class WebViewIOSSauceTests(SauceTestCase):

    def test_get_url(self):
        url_el = self.driver.find_element_by_xpath('//UIAApplication[1]/UIAWindow[1]/UIATextField[1]')
        url_el.send_keys('http://www.google.com')

        go_el = self.driver.find_element_by_accessibility_id('Go')
        go_el.click()

        self.driver.switch_to.context('WEBVIEW')

        search = self.driver.find_element_by_name('q')
        search.send_keys('sauce labs')
        search.send_keys(Keys.RETURN)

        # allow the page to load
        sleep(1)

        self.assertEquals('sauce labs', self.driver.title[:10])

