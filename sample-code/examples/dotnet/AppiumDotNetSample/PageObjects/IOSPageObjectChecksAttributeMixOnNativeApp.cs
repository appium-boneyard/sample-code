using OpenQA.Selenium.Appium.Interfaces;
using OpenQA.Selenium.Appium.iOS;
using OpenQA.Selenium.Appium.PageObjects.Attributes;
using OpenQA.Selenium.Support.PageObjects;
using System.Collections.Generic;

namespace Appium.Samples.PageObjects
{
    public class IOSPageObjectChecksAttributeMixOnNativeApp
    {
        /////////////////////////////////////////////////////////////////
        [FindsBy(How = How.Id, Using = "FakeHTMLid", Priority = 1)]
        [FindsByIOSUIAutomation(IosUIAutomation = ".elements()[0]")]
        [FindsByAndroidUIAutomator(AndroidUIAutomator = "new UiSelector().resourceId(\"android:id/text1\")")]
        private IMobileElement<IOSElement> testMobileElement;

        [FindsBy(How = How.Id, Using = "FakeHTMLid", Priority = 1)]
        [FindsByIOSUIAutomation(IosUIAutomation = ".elements()[0]")]
        [FindsByAndroidUIAutomator(AndroidUIAutomator = "new UiSelector().resourceId(\"android:id/text1\")")]
        private IList<IOSElement> testMobileElements;

        [FindsBy(How = How.Id, Using = "FakeHTMLid", Priority = 1)]
        [FindsByIOSUIAutomation(IosUIAutomation = ".elements()[0]")]
        [FindsByAndroidUIAutomator(AndroidUIAutomator = "new UiSelector().resourceId(\"android:id/text1\")")]
        private IMobileElement<IOSElement> TestMobileElement
        {
            set; get;
        }

        [FindsBy(How = How.Id, Using = "FakeHTMLid", Priority = 1)]
        [FindsByIOSUIAutomation(IosUIAutomation = ".elements()[0]")]
        [FindsByAndroidUIAutomator(AndroidUIAutomator = "new UiSelector().resourceId(\"android:id/text1\")")]
        private IList<IOSElement> TestMobileElements
        {
            set; get;
        }

        [FindsBy(How = How.Id, Using = "FakeHTMLid", Priority = 1)]
        [FindsBy(How = How.ClassName, Using = "FakeHTMLClass", Priority = 2)]
        [FindsBy(How = How.XPath, Using = ".//fakeTag", Priority = 3)]

        [FindsByIOSUIAutomation(ClassName = "UIAUAIFakeClass", Priority = 1)]
        [FindsByIOSUIAutomation(ID = "FakeID", Priority = 2)]
        [FindsByIOSUIAutomation(IosUIAutomation = ".elements()[0]", Priority = 3)]

        [FindsByAndroidUIAutomator(AndroidUIAutomator = "new UiSelector().resourceId(\"android:id/fakeId\")", Priority = 1)]
        [FindsByAndroidUIAutomator(ID = "FakeId", Priority = 2)]
        [FindsByAndroidUIAutomator(ClassName = "android.widget.TextView", Priority = 3)]
        private IMobileElement<IOSElement> testMultipleElement;

        [FindsBy(How = How.Id, Using = "FakeHTMLid", Priority = 1)]
        [FindsBy(How = How.ClassName, Using = "FakeHTMLClass", Priority = 2)]
        [FindsBy(How = How.XPath, Using = ".//fakeTag", Priority = 3)]

        [FindsByIOSUIAutomation(ClassName = "UIAUAIFakeClass", Priority = 1)]
        [FindsByIOSUIAutomation(ID = "FakeID", Priority = 2)]
        [FindsByIOSUIAutomation(IosUIAutomation = ".elements()[0]", Priority = 3)]

        [FindsByAndroidUIAutomator(AndroidUIAutomator = "new UiSelector().resourceId(\"android:id/fakeId\")", Priority = 1)]
        [FindsByAndroidUIAutomator(ID = "FakeId", Priority = 2)]
        [FindsByAndroidUIAutomator(ClassName = "android.widget.TextView", Priority = 3)]
        private IList<IOSElement> testMultipleElements;


        /////////////////////////////////////////////////////////////////

        [FindsBy(How = How.Id, Using = "FakeHTMLid", Priority = 1)]
        [FindsBy(How = How.ClassName, Using = "FakeHTMLClass", Priority = 2)]
        [FindsBy(How = How.XPath, Using = ".//fakeTag", Priority = 3)]

        [FindsByIOSUIAutomation(ClassName = "UIAUAIFakeClass", Priority = 1)]
        [FindsByIOSUIAutomation(ID = "FakeID", Priority = 2)]
        [FindsByIOSUIAutomation(IosUIAutomation = ".elements()[0]", Priority = 3)]

        [FindsByAndroidUIAutomator(AndroidUIAutomator = "new UiSelector().resourceId(\"android:id/fakeId\")", Priority = 1)]
        [FindsByAndroidUIAutomator(ID = "FakeId", Priority = 2)]
        [FindsByAndroidUIAutomator(ClassName = "android.widget.TextView", Priority = 3)]
        private IMobileElement<IOSElement> TestMultipleFindByElementProperty
        {
            set; get;
        }

        [FindsBy(How = How.Id, Using = "FakeHTMLid", Priority = 1)]
        [FindsBy(How = How.ClassName, Using = "FakeHTMLClass", Priority = 2)]
        [FindsBy(How = How.XPath, Using = ".//fakeTag", Priority = 3)]

        [FindsByIOSUIAutomation(ClassName = "UIAUAIFakeClass", Priority = 1)]
        [FindsByIOSUIAutomation(ID = "FakeID", Priority = 2)]
        [FindsByIOSUIAutomation(IosUIAutomation = ".elements()[0]", Priority = 3)]

        [FindsByAndroidUIAutomator(AndroidUIAutomator = "new UiSelector().resourceId(\"android:id/fakeId\")", Priority = 1)]
        [FindsByAndroidUIAutomator(ID = "FakeId", Priority = 2)]
        [FindsByAndroidUIAutomator(ClassName = "android.widget.TextView", Priority = 3)]
        private IList<IOSElement> MultipleFindByElementsProperty
        {
            set; get;
        }

        [FindsByAll]
        [MobileFindsByAll(Android = true, IOS = true)]
        [FindsBy(How = How.Id, Using = "FakeHTMLid", Priority = 1)]
        [FindsBy(How = How.ClassName, Using = "FakeHTMLClass", Priority = 2)]
        [FindsBy(How = How.XPath, Using = ".//fakeTag", Priority = 3)]

        [FindsByIOSUIAutomation(ClassName = "UIAButton", Priority = 1)]
        //Equals method of RemoteWebElement is not consistent for mobile apps
        //The second selector won't be added till the problem is worked out

        [FindsByAndroidUIAutomator(ID = "android:id/text1", Priority = 1)]
        [FindsByAndroidUIAutomator(ClassName = "android.widget.TextView", Priority = 1)]
        private IMobileElement<IOSElement> matchedToAllLocatorsElement;

        [FindsByAll]
        [MobileFindsByAll(Android = true, IOS = true)]
        [FindsBy(How = How.Id, Using = "FakeHTMLid", Priority = 1)]
        [FindsBy(How = How.ClassName, Using = "FakeHTMLClass", Priority = 2)]
        [FindsBy(How = How.XPath, Using = ".//fakeTag", Priority = 3)]

        [FindsByIOSUIAutomation(ClassName = "UIAButton", Priority = 1)]
        //Equals method of RemoteWebElement is not consistent for mobile apps
        //The second selector won't be added till the problem is worked out

        [FindsByAndroidUIAutomator(ID = "android:id/text1", Priority = 1)]
        [FindsByAndroidUIAutomator(ClassName = "android.widget.TextView", Priority = 1)]
        private IList<IOSElement> matchedToAllLocatorsElements;

        /////////////////////////////////////////////////////////////////
        [FindsByAll]
        [MobileFindsByAll(Android = true, IOS = true)]
        [FindsBy(How = How.Id, Using = "FakeHTMLid", Priority = 1)]
        [FindsBy(How = How.ClassName, Using = "FakeHTMLClass", Priority = 2)]
        [FindsBy(How = How.XPath, Using = ".//fakeTag", Priority = 3)]

        [FindsByIOSUIAutomation(ClassName = "UIAButton", Priority = 1)]
        //Equals method of RemoteWebElement is not consistent for mobile apps
        //The second selector won't be added till the problem is worked out

        [FindsByAndroidUIAutomator(ID = "android:id/text1", Priority = 1)]
        [FindsByAndroidUIAutomator(ClassName = "android.widget.TextView", Priority = 1)]
        private IMobileElement<IOSElement> TestMatchedToAllLocatorsElementProperty
        {
            set; get;
        }

        [FindsByAll]
        [MobileFindsByAll(Android = true, IOS = true)]
        [FindsBy(How = How.Id, Using = "FakeHTMLid", Priority = 1)]
        [FindsBy(How = How.ClassName, Using = "FakeHTMLClass", Priority = 2)]
        [FindsBy(How = How.XPath, Using = ".//fakeTag", Priority = 3)]

        [FindsByIOSUIAutomation(ClassName = "UIAButton", Priority = 1)]
        //Equals method of RemoteWebElement is not consistent for mobile apps
        //The second selector won't be added till the problem is worked out

        [FindsByAndroidUIAutomator(ID = "android:id/text1", Priority = 1)]
        [FindsByAndroidUIAutomator(ClassName = "android.widget.TextView", Priority = 1)]
        private IList<IOSElement> TestMatchedToAllLocatorsElementsProperty
        {
            set; get;
        }

        //////////////////////////////////////////////////////////////////////////
        public string GetMobileElementText()
        {
            return testMobileElement.Text;
        }

        public int GetMobileElementSize()
        {
            return testMobileElements.Count;
        }

        public string GetMobileElementPropertyText()
        {
            return TestMobileElement.Text;
        }

        public int GetMobileElementPropertySize()
        {
            return TestMobileElements.Count;
        }

        //////////////////////////////////////////////////////////////////////////
        public string GetMultipleFindByElementText()
        {
            return testMultipleElement.Text;
        }

        public int GetMultipleFindByElementSize()
        {
            return testMultipleElements.Count;
        }

        public string GetMultipleFindByElementPropertyText()
        {
            return TestMultipleFindByElementProperty.Text;
        }

        public int GetMultipleFindByElementPropertySize()
        {
            return MultipleFindByElementsProperty.Count;
        }

        //////////////////////////////////////////////////////////////////////////
        public string GetMatchedToAllLocatorsElementText()
        {
            return matchedToAllLocatorsElement.Text;
        }

        public int GetMatchedToAllLocatorsElementSize()
        {
            return matchedToAllLocatorsElements.Count;
        }

        public string GetMatchedToAllLocatorsElementPropertyText()
        {
            return TestMatchedToAllLocatorsElementProperty.Text;
        }

        public int GetMatchedToAllLocatorsElementPropertySize()
        {
            return TestMatchedToAllLocatorsElementsProperty.Count;
        }

    }
}
