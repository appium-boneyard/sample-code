# These are the 'step definitions' which Cucumber uses to implement features.
#
# Each step starts with a regular expression matching the step you write in
# your feature description.  Any variables are parsed out and passed to the
# step block.
#
# The instructions in the step are then executed with those variables.
#
# The '$driver' object is the appium_lib driver, set up in the cucumber/support/env.rb
# file, which is a convenient place to put it as we're likely to use it often.
# For more on step definitions, check out the documentation at
# https://github.com/cucumber/cucumber/wiki/Step-Definitions
#
# For more on rspec assertions, check out
# https://www.relishapp.com/rspec/rspec-expectations/docs
Given(/^I have entered ([^"]*) into Email field$/) do |value|
  @driver.find_element(id:'fbemail').send_keys(value)
  wait(timeout:2,message:'Text not entered into email').until { @driver.find_element(id:'fbemail').attribute('value').eql?value }
end

And(/^I have entered ([^"]*) into Comments field$/) do |value|
  @driver.find_element(id:'comments').send_keys(value)
  wait(timeout:2,message:'Text not entered into comments').until { @driver.find_element(id:'comments').attribute('value').eql?value }
end

When(/^I click on ([^"]*)$/) do |va|
  element = @driver.find_element(id:va)
  raise 'No link found' unless element.displayed?
  element.click
  wait.until { @driver.title.start_with?'I am another page title' }
end

Then(/^I am on other page$/) do
  element = @driver.find_element(id:'i_am_an_id')
  element.displayed?
  raise "Doesn't open next page" unless element.text.eql?'I am another div'
end