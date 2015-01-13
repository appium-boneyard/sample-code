from appium import webdriver
from appium import SauceTestCase, on_platforms
from appium.webdriver.common.touch_action import TouchAction
from appium.webdriver.common.multi_action import MultiAction

from time import sleep

app = "http://appium.github.io/appium/assets/ApiDemos-debug.apk"
platforms = [{
                "platformName": "Android",
                "platformVersion": "4.4",
                "deviceName": "Android Emulator",
                "appActivity": ".graphics.TouchPaint",
                "app": app,
                "appiumVersion": "1.3.4"
            }]


@on_platforms(platforms)
class AndroidGesturesSauceTests(SauceTestCase):

    def test_drag_and_drop(self):
        # first get to the right activity
        self.driver.start_activity("io.appium.android.apis", ".view.DragAndDropDemo")

        start = self.driver.find_element_by_id("io.appium.android.apis:id/drag_dot_3")
        end = self.driver.find_element_by_id("io.appium.android.apis:id/drag_dot_2")

        action = TouchAction(self.driver);
        action.long_press(start).move_to(end).release().perform()

        sleep(.5)

        text = self.driver.find_element_by_id("io.appium.android.apis:id/drag_result_text").text
        self.assertEqual(text, "Dropped!")


    def test_smiley_face(self):
        # just for the fun of it.
        # this doesn't really assert anything.
        # paint
        eye1 = TouchAction()
        eye1.press(x=150, y=100).release()

        eye2 = TouchAction()
        eye2.press(x=250, y=100).release()

        smile = TouchAction()
        smile.press(x=110, y=200) \
            .move_to(x=1, y=1) \
            .move_to(x=1, y=1) \
            .move_to(x=1, y=1) \
            .move_to(x=1, y=1) \
            .move_to(x=1, y=1) \
            .move_to(x=2, y=1) \
            .move_to(x=2, y=1) \
            .move_to(x=2, y=1) \
            .move_to(x=2, y=1) \
            .move_to(x=2, y=1) \
            .move_to(x=3, y=1) \
            .move_to(x=3, y=1) \
            .move_to(x=3, y=1) \
            .move_to(x=3, y=1) \
            .move_to(x=3, y=1) \
            .move_to(x=4, y=1) \
            .move_to(x=4, y=1) \
            .move_to(x=4, y=1) \
            .move_to(x=4, y=1) \
            .move_to(x=4, y=1) \
            .move_to(x=5, y=1) \
            .move_to(x=5, y=1) \
            .move_to(x=5, y=1) \
            .move_to(x=5, y=1) \
            .move_to(x=5, y=1) \
            .move_to(x=5, y=0) \
            .move_to(x=5, y=0) \
            .move_to(x=5, y=0) \
            .move_to(x=5, y=0) \
            .move_to(x=5, y=0) \
            .move_to(x=5, y=0) \
            .move_to(x=5, y=0) \
            .move_to(x=5, y=0) \
            .move_to(x=5, y=-1) \
            .move_to(x=5, y=-1) \
            .move_to(x=5, y=-1) \
            .move_to(x=5, y=-1) \
            .move_to(x=5, y=-1) \
            .move_to(x=4, y=-1) \
            .move_to(x=4, y=-1) \
            .move_to(x=4, y=-1) \
            .move_to(x=4, y=-1) \
            .move_to(x=4, y=-1) \
            .move_to(x=3, y=-1) \
            .move_to(x=3, y=-1) \
            .move_to(x=3, y=-1) \
            .move_to(x=3, y=-1) \
            .move_to(x=3, y=-1) \
            .move_to(x=2, y=-1) \
            .move_to(x=2, y=-1) \
            .move_to(x=2, y=-1) \
            .move_to(x=2, y=-1) \
            .move_to(x=2, y=-1) \
            .move_to(x=1, y=-1) \
            .move_to(x=1, y=-1) \
            .move_to(x=1, y=-1) \
            .move_to(x=1, y=-1) \
            .move_to(x=1, y=-1)
        smile.release()

        ma = MultiAction(self.driver)
        ma.add(eye1, eye2, smile)
        ma.perform()

        # so you can see it
        sleep(10)
