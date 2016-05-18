class CalculatorPage
	include PageObject

	XPATH_INTEGERA = '//UIAApplication[1]/UIAWindow[2]/UIATextField[1]'
	XPATH_INTEGERB = '//UIAApplication[1]/UIAWindow[2]/UIATextField[2]'
	XPATH_SUM_BUTTON = '//UIAApplication[1]/UIAWindow[2]/UIAButton[1]'
	XPATH_ANSWER = '//UIAApplication[1]/UIAWindow[2]/UIAStaticText[1]'

  XPATH_SHOW_BUTTON = '//UIAApplication[1]/UIAWindow[2]/UIAButton[2]'
  XPATH_ALERT_TITLE = '//UIAApplication[1]/UIAWindow[5]/UIAAlert[1]/UIAScrollView[1]/UIAStaticText[1]'
  XPATH_OK_BUTTON = '//UIAApplication[1]/UIAWindow[5]/UIAAlert[1]/UIACollectionView[1]/UIACollectionCell[2]/UIAButton[1]'
  # XPATH_OK_BUTTON = '//UIAApplication[1]/UIAWindow[7]/UIAAlert[1]/UIACollectionView[1]/UIACollectionCell[2]/UIAButton[1]'
  # XPATH_CONTACT_ALERT = '//UIAApplication[1]/UIAWindow[2]/UIAButton[3]'
  # XPATH_LOCATION_ALERT = '//UIAApplication[1]/UIAWindow[2]/UIAButton[4]'


  # DIALOG = '//UIAApplication[1]/UIAWindow[7]/UIAAlert[1]/UIAScrollView[1]/UIAStaticText[2]'

	text_field(:first_number, xpath: XPATH_INTEGERA)
	text_field(:second_number, xpath: XPATH_INTEGERB)
	button(:sum_button, xpath: XPATH_SUM_BUTTON)
	button(:show_button, xpath: XPATH_SHOW_BUTTON)
	button(:ok_button, xpath: XPATH_OK_BUTTON)

	def set_first_number (number)
		self.first_number = number
	end

	def set_second_number (number)
		self.second_number = number
	end

	def click_sum_button
		sum_button
	end

	def is_sum_correct? (number)
		return $driver.find_element(:xpath, XPATH_ANSWER).text == number
	end

	def click_show_alert_button
		show_button
	end

  def is_dialog_title_correct?
		return $driver.find_element(:xpath, XPATH_ALERT_TITLE).text == 'Cool title'
	end

  def click_ok_button
		ok_button
	end

end