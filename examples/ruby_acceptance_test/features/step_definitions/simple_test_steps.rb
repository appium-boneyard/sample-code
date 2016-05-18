Given(/^I open the app$/) do
end

Given(/^I wants to add number (\d+) and (\d+)$/) do |arg1, arg2|
  	@driver.wait {
  		on(CalculatorPage).set_first_number arg1
  		on(CalculatorPage).set_second_number arg2
  	}
end

Then(/^I should see the result is (\d+)$/) do |arg1|
	@driver.wait {
		on(CalculatorPage).click_sum_button
		assert (on(CalculatorPage).is_sum_correct? arg1), 'Answer is not correct'
	}
end

When(/^I check the alert dialog$/) do
	@driver.wait {
    on(CalculatorPage).click_show_alert_button

  }
end

Then(/^I should see its content$/) do
		@driver.wait {
			assert (on(CalculatorPage).is_dialog_title_correct?), 'Dialog displayed is not correct'
      on(CalculatorPage).click_ok_button
    }
end
