import pytest
from appium import webdriver

from selenium.webdriver.support.expected_conditions import staleness_of
from selenium.webdriver.support.ui import WebDriverWait
from selenium.webdriver.support import expected_conditions
from selenium.webdriver.common.by import By


def test_appium():
    desired_caps = {}
    desired_caps['platformName'] = 'iOS'
    desired_caps['platformVersion'] = '9.3'
    desired_caps['deviceName'] = 'iPhone 6s'
    desired_caps['app'] = 'safari'

    driver = webdriver.Remote('http://localhost:4723/wd/hub', desired_caps)
    driver.get('https://the-internet.herokuapp.com')
    ab_element = driver.find_element_by_link_text('A/B Testing')
    ab_element.click()
    WebDriverWait(driver, 10).until(staleness_of(ab_element))
    driver.close()


