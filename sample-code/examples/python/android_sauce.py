from appium import webdriver
from appium import SauceTestCase, on_platforms


app = "http://appium.s3.amazonaws.com/NotesList.apk"
platforms = [{
                "platformName": "Android",
                "platformVersion": "4.4",
                "deviceName": "Android Emulator",
                "appPackage": "com.example.android.notepad",
                "appActivity": ".NotesList",
                "app": app,
                "appiumVersion": "1.3.4"
            }]

@on_platforms(platforms)
class SimpleAndroidSauceTests(SauceTestCase):

    def test_create_note(self):
        el = self.driver.find_element_by_accessibility_id("New note")
        el.click()

        el = self.driver.find_element_by_class_name("android.widget.EditText")
        el.send_keys("This is a new note!")

        el = self.driver.find_element_by_accessibility_id("Save")
        el.click()

        els = self.driver.find_elements_by_class_name("android.widget.TextView")
        self.assertEqual(els[2].text, "This is a new note!")

        els[2].click()
