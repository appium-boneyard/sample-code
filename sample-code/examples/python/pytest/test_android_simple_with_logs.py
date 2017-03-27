import os
import pytest

from appium import webdriver
from helpers import take_screenhot_and_logcat

# Returns abs path relative to this file and not cwd
PATH = lambda p: os.path.abspath(
    os.path.join(os.path.dirname(__file__), p)
)
APPIUM_LOCAL_HOST_URL = 'http://localhost:4723/wd/hub'


class TestSimpleAndroid():
    @pytest.fixture(scope="function")
    def driver(self, request, device_logger):
        desired_caps = {
            'platformName': 'Android',
            'platformVersion': '6.0',
            'deviceName': 'Android Emulator',
            'app': PATH('../../../../sample-code/apps/ApiDemos/bin/ApiDemos-debug.apk')
        }
        calling_request = request._pyfuncitem.name
        driver = webdriver.Remote(APPIUM_LOCAL_HOST_URL, desired_caps)

        def fin():
            take_screenhot_and_logcat(driver, device_logger, calling_request)
            driver.quit()

        request.addfinalizer(fin)
        return driver  # provide the fixture value

    def test_find_elements(self, driver):
        el = driver.find_element_by_accessibility_id('Graphics')
        el.click()
        el = driver.find_element_by_accessibility_id('Arcs')
        assert el is not None
        driver.back()

        el = driver.find_element_by_accessibility_id("App")
        assert el is not None

        els = driver.find_elements_by_android_uiautomator("new UiSelector().clickable(true)")
        assert len(els) >= 12
        driver.find_element_by_android_uiautomator('text("API Demos")')

    def test_simple_actions(self, driver):
        el = driver.find_element_by_accessibility_id('Graphics')
        el.click()

        el = driver.find_element_by_accessibility_id('Arcs')
        el.click()

        driver.find_element_by_android_uiautomator('new UiSelector().text("Graphics/Arcs")')
