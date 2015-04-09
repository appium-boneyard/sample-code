# This file provides setup and common functionality across all features.  It's
# included first before every test run, and the methods provided here can be 
# used in any of the step definitions used in a test.  This is a great place to
# put shared data like the location of your app, the capabilities you want to
# test with, and the setup of selenium.

require 'rspec/expectations'
require 'appium_lib'
require 'cucumber/ast'
require 'selenium-webdriver'

# Create a custom World class so we don't pollute `Object` with Appium methods
class AppiumWorld
end

# Load the desired configuration from appium.txt, create a driver then
# Add the methods to the world
caps = Appium.load_appium_txt file: File.expand_path('./', __FILE__), verbose: true
Appium::Driver.new(caps)

World do
  AppiumWorld.new
end

Before {

  @driver = $driver.start_driver
  @driver.get('http://saucelabs.com/test/guinea-pig')
  wait(timout:3).until { @driver.title.start_with?'I am a page title'  }

}
After { $driver.driver_quit }

def wait(opts={})
  Selenium::WebDriver::Wait.new(opts)
end
