"""
//******************************************************************************

Copyright (c) 2016 Appium Committers. All rights reserved.

Licensed to you under the Apache License, Version 2.0 (the
"License"); you may not use this file except in compliance
with the License.  You may obtain a copy of the License at
http://www.apache.org/licenses/LICENSE-2.0 

Unless required by applicable law or agreed to in writing,
software distributed under the License is distributed on an
"AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
KIND, either express or implied.  See the License for the
specific language governing permissions and limitations
under the License.

//******************************************************************************
"""

import unittest
from appium import webdriver

class SimpleCalculatorTests(unittest.TestCase):

    def setUp(self):
        #set up appium
        desired_caps = {}  
        desired_caps["app"] = "Microsoft.WindowsCalculator_8wekyb3d8bbwe!App"
        desired_caps["platformName"] = "Windows"
        desired_caps["deviceName"] = "WindowsPC"
        self.driver = webdriver.Remote(
            command_executor='http://127.0.0.1:4723/wd/hub',
            desired_capabilities= desired_caps)

    def tearDown(self):
        self.driver.quit()

    def test_initialize(self):
        #Make sure we're in standard mode
        self.driver.find_element_by_xpath("//Button[starts-with(@Name, \"Menu\")]").click();
        self.driver.find_element_by_xpath("//ListItem[@Name=\"Standard Calculator\"]").click();

        self.driver.find_element_by_name("Clear").click()
        self.driver.find_element_by_name("Seven").click()

        result = self.driver.find_element_by_accessibility_id("CalculatorResults")
        self.assertEqual(str(result.text),"Display is 7")

    def test_addition(self):
        self.driver.find_element_by_name("One").click()
        self.driver.find_element_by_name("Plus").click()
        self.driver.find_element_by_name("Seven").click()
        self.driver.find_element_by_name("Equals").click()

        result = self.driver.find_element_by_accessibility_id("CalculatorResults")
        self.assertEqual(str(result.text), "Display is 8")

    def test_combination(self):
        self.driver.find_element_by_name("Seven").click()
        self.driver.find_element_by_name("Multiply by").click()
        self.driver.find_element_by_name("Nine").click()
        self.driver.find_element_by_name("Plus").click()
        self.driver.find_element_by_name("One").click()
        self.driver.find_element_by_name("Equals").click()
        self.driver.find_element_by_name("Divide by").click()
        self.driver.find_element_by_name("Eight").click()
        self.driver.find_element_by_name("Equals").click()

        result = self.driver.find_element_by_accessibility_id("CalculatorResults")
        self.assertEqual(str(result.text), "Display is 8")

    def test_division(self):
        self.driver.find_element_by_name("Eight").click()
        self.driver.find_element_by_name("Eight").click()
        self.driver.find_element_by_name("Divide by").click()
        self.driver.find_element_by_name("One").click()
        self.driver.find_element_by_name("One").click()
        self.driver.find_element_by_name("Equals").click()
        
        result = self.driver.find_element_by_accessibility_id("CalculatorResults")
        self.assertEqual(str(result.text), "Display is 8")

    def test_multiplication(self):
        self.driver.find_element_by_name("Nine").click()
        self.driver.find_element_by_name("Multiply by").click()
        self.driver.find_element_by_name("Nine").click()
        self.driver.find_element_by_name("Equals").click()

        result = self.driver.find_element_by_accessibility_id("CalculatorResults")
        self.assertEqual(str(result.text), "Display is 81")

    def test_subtraction(self):
        self.driver.find_element_by_name("Nine").click()
        self.driver.find_element_by_name("Minus").click()
        self.driver.find_element_by_name("One").click()
        self.driver.find_element_by_name("Equals").click()

        result = self.driver.find_element_by_accessibility_id("CalculatorResults")
        self.assertEqual(str(result.text), "Display is 8")



if __name__ == '__main__':
    suite = unittest.TestLoader().loadTestsFromTestCase(SimpleCalculatorTests)
    unittest.TextTestRunner(verbosity=2).run(suite)
