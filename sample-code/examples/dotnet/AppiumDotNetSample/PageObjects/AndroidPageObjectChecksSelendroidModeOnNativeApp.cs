using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Interfaces;
using OpenQA.Selenium.Appium.PageObjects.Attributes;
using System.Collections.Generic;

namespace Appium.Samples.PageObjects
{
    public class AndroidPageObjectChecksSelendroidModeOnNativeApp
    {
        /////////////////////////////////////////////////////////////////

        [FindsBySelendroid(ID = "my_text_field")]
        private IWebElement testMobileElement;

        [FindsBySelendroid(ID = "my_text_field")]
        private IList<IWebElement> testMobileElements;

        [FindsBySelendroid(ID = "my_text_field")]
        private IWebElement TestMobileElement
        {
            set; get;
        }

        [FindsBySelendroid(ID = "my_text_field")]
        private IList<IWebElement> TestMobileElements
        {
            set; get;
        }

        [FindsBySelendroid(ID = "fake_content", Priority = 1)]
        [FindsBySelendroid(ClassName = "android.webkit.WebView", Priority = 2)] //There is no Webview at the screen
        [FindsBySelendroid(ID = "waitingButtonTest", Priority = 3)]

        [FindsByAndroidUIAutomator(AndroidUIAutomator = "new UiSelector().resourceId(\"android:id/fakeId\")", Priority = 1)]
        [FindsByAndroidUIAutomator(ID = "FakeId", Priority = 2)]
        [FindsByAndroidUIAutomator(ClassName = "FakeClass", Priority = 3)]
        private IWebElement testMultipleElement;

        [FindsBySelendroid(ID = "fake_content", Priority = 1)]
        [FindsBySelendroid(ClassName = "android.webkit.WebView", Priority = 2)] //There is no Webview at the screen
        [FindsBySelendroid(LinkText = "Press to throw unhandled exception", Priority = 3)]

        [FindsByAndroidUIAutomator(AndroidUIAutomator = "new UiSelector().resourceId(\"android:id/fakeId\")", Priority = 1)]
        [FindsByAndroidUIAutomator(ID = "FakeId", Priority = 2)]
        [FindsByAndroidUIAutomator(ClassName = "FakeClass", Priority = 3)]
        private IList<IWebElement> testMultipleElements;


        /////////////////////////////////////////////////////////////////

        [FindsBySelendroid(ID = "fake_content", Priority = 1)]
        [FindsBySelendroid(ClassName = "android.webkit.WebView", Priority = 2)] //There is no Webview at the screen
        [FindsBySelendroid(LinkText = "Press to throw unhandled exception", Priority = 3)]
        private IWebElement TestMultipleFindByElementProperty
        {
            set; get;
        }

        [FindsBySelendroid(ID = "fake_content", Priority = 1)]
        [FindsBySelendroid(ClassName = "android.webkit.WebView", Priority = 2)] //There is no Webview at the screen
        [FindsBySelendroid(LinkText = "Press to throw unhandled exception", Priority = 3)]
        private IList<IWebElement> MultipleFindByElementsProperty
        {
            set; get;
        }

        [MobileFindsBySequence(Android = true, Selendroid = true)]
        [FindsBySelendroid(ID = "content", Priority = 1)]
        [FindsBySelendroid(ClassName = "android.widget.FrameLayout", Priority = 2)]
        [FindsBySelendroid(LinkText = "Press to throw unhandled exception", Priority = 3)]

        [FindsByAndroidUIAutomator(AndroidUIAutomator = "new UiSelector().resourceId(\"android:id/content\")", Priority = 1)]
        [FindsByAndroidUIAutomator(AndroidUIAutomator = "new UiSelector().resourceId(\"android:id/list\")", Priority = 2)]
        [FindsByAndroidUIAutomator(ClassName = "android.widget.TextView", Priority = 3)]
        private IWebElement foundByChainedSearchElement;

        [MobileFindsBySequence(Android = true, Selendroid = true)]
        [FindsBySelendroid(ID = "content", Priority = 1)]
        [FindsBySelendroid(ClassName = "android.widget.FrameLayout", Priority = 2)]
        [FindsBySelendroid(LinkText = "Press to throw unhandled exception", Priority = 3)]

        [FindsByAndroidUIAutomator(AndroidUIAutomator = "new UiSelector().resourceId(\"android:id/content\")", Priority = 1)]
        [FindsByAndroidUIAutomator(AndroidUIAutomator = "new UiSelector().resourceId(\"android:id/list\")", Priority = 2)]
        [FindsByAndroidUIAutomator(ClassName = "android.widget.TextView", Priority = 3)]
        private IList<IWebElement> foundByChainedSearchElements;

        /////////////////////////////////////////////////////////////////

        [MobileFindsBySequence(Android = true, Selendroid = true)]
        [FindsBySelendroid(ID = "content", Priority = 1)]
        [FindsBySelendroid(ClassName = "android.widget.FrameLayout", Priority = 2)]
        [FindsBySelendroid(PartialLinkText = "Press to throw unhandled exception", Priority = 3)]

        [FindsByAndroidUIAutomator(AndroidUIAutomator = "new UiSelector().resourceId(\"android:id/content\")", Priority = 1)]
        [FindsByAndroidUIAutomator(AndroidUIAutomator = "new UiSelector().resourceId(\"android:id/list\")", Priority = 2)]
        [FindsByAndroidUIAutomator(ClassName = "android.widget.TextView", Priority = 3)]
        private IWebElement TestFoundByChainedSearchElementProperty
        {
            set; get;
        }

        [MobileFindsBySequence(Android = true, Selendroid = true)]
        [FindsBySelendroid(ID = "content", Priority = 1)]
        [FindsBySelendroid(ClassName = "android.widget.FrameLayout", Priority = 2)]
        [FindsBySelendroid(PartialLinkText = "Press to throw unhandled exception", Priority = 3)]

        [FindsByAndroidUIAutomator(AndroidUIAutomator = "new UiSelector().resourceId(\"android:id/content\")", Priority = 1)]
        [FindsByAndroidUIAutomator(AndroidUIAutomator = "new UiSelector().resourceId(\"android:id/list\")", Priority = 2)]
        [FindsByAndroidUIAutomator(ClassName = "android.widget.TextView", Priority = 3)]
        private IList<IWebElement> TestFoundByChainedSearchElementsProperty
        {
            set; get;
        }

        [MobileFindsByAll(Selendroid = true)]
        [FindsBySelendroid(LinkText = "Press to throw unhandled exception", Priority = 1)]
        //[FindsByAndroidUIAutomator(ID = "waitingButtonTest", Priority = 2)]
        //Equals method of RemoteWebElement is not consistent for mobile apps
        //The second selector will be commented till the problem is worked out
        private IMobileElement<IWebElement> matchedToAllLocatorsElement;

        [MobileFindsByAll(Selendroid = true)]
        [FindsBySelendroid(LinkText = "Press to throw unhandled exception", Priority = 1)]
        //[FindsByAndroidUIAutomator(ID = "waitingButtonTest", Priority = 2)]
        //Equals method of RemoteWebElement is not consistent for mobile apps
        //The second selector will be commented till the problem is worked out
        private IList<IWebElement> matchedToAllLocatorsElements;

        /////////////////////////////////////////////////////////////////

        [MobileFindsByAll(Selendroid = true)]
        [FindsBySelendroid(LinkText = "Press to throw unhandled exception", Priority = 1)]
        //[FindsByAndroidUIAutomator(ID = "waitingButtonTest", Priority = 2)]
        //Equals method of RemoteWebElement is not consistent for mobile apps
        //The second selector will be commented till the problem is worked out
        private IWebElement TestMatchedToAllLocatorsElementProperty
        {
            set; get;
        }

        [MobileFindsByAll(Selendroid = true)]
        [FindsBySelendroid(LinkText = "Press to throw unhandled exception", Priority = 1)]
        //[FindsByAndroidUIAutomator(ID = "waitingButtonTest", Priority = 2)]
        //Equals method of RemoteWebElement is not consistent for mobile apps
        //The second selector will be commented till the problem is worked out
        private IList<IWebElement> TestMatchedToAllLocatorsElementsProperty
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
        public string GetFoundByChainedSearchElementText()
        {
            return foundByChainedSearchElement.Text;
        }

        public int GetFoundByChainedSearchElementSize()
        {
            return foundByChainedSearchElements.Count;
        }

        public string GetFoundByChainedSearchElementPropertyText()
        {
            return TestFoundByChainedSearchElementProperty.Text;
        }

        public int GetFoundByChainedSearchElementPropertySize()
        {
            return TestFoundByChainedSearchElementsProperty.Count;
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
