# ******************************************************************************
#
# Copyright (c) 2016 Appium Committers. All rights reserved.
#
#Licensed to you under the Apache License, Version 2.0 (the
#"License"); you may not use this file except in compliance
#with the License.  You may obtain a copy of the License at
#http://www.apache.org/licenses/LICENSE-2.0 
#
#Unless required by applicable law or agreed to in writing,
#software distributed under the License is distributed on an
#"AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
#KIND, either express or implied.  See the License for the
#specific language governing permissions and limitations
#under the License.
#
#
#******************************************************************************
require 'selenium-webdriver'
require "test/unit"

$CalculatorSession
$CalculatorResult

class CalculatorTest < Test::Unit::TestCase
    def caps 
        {
            platformName: "WINDOWS", platform: "WINDOWS", deviceName: "mydevice", app: "Microsoft.WindowsCalculator_8wekyb3d8bbwe!App" 
        }
    end

    def assert &block
        raise AssertionError unless yield
    end

    def setup
        $CalculatorSession = Selenium::WebDriver.for(:remote, :url => "http://127.0.0.1:4723/wd/hub", :desired_capabilities => caps )
        
        $CalculatorSession.find_elements(:xpath, "//Button[starts-with(@Name, \"Menu\")]")[0].click;
        $CalculatorSession.find_elements(:xpath, "//ListItem[@Name=\"Standard Calculator\"]")[0].click;

        $CalculatorSession.find_elements(:name, "Clear")[0].click;
        $CalculatorSession.find_elements(:name, "Seven")[0].click;
        $CalculatorResult = $CalculatorSession.find_elements(:name, "Display is  7 ")[0];
        assert{$CalculatorResult != nil}
        $CalculatorSession.find_elements(:name, "Clear")[0].click;
    end

    def test_combination
        $CalculatorSession.find_elements(:name, "Seven")[0].click;
        $CalculatorSession.find_elements(:name, "Multiply by")[0].click;
        $CalculatorSession.find_elements(:name, "Nine")[0].click;
        $CalculatorSession.find_elements(:name, "Plus")[0].click;
        $CalculatorSession.find_elements(:name, "One")[0].click;
        $CalculatorSession.find_elements(:name, "Equals")[0].click;
        $CalculatorSession.find_elements(:name, "Divide by")[0].click;
        $CalculatorSession.find_elements(:name, "Eight")[0].click;
        $CalculatorSession.find_elements(:name, "Equals")[0].click;
        assert{$CalculatorResult.text == "Display is  8 "};
    end

    def teardown
        $CalculatorSession.quit
    end
end
