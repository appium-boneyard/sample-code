using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Interfaces;
using OpenQA.Selenium.Appium.PageObjects.Attributes;
using System.Collections.Generic;

namespace Appium.Samples.PageObjects
{
    public class AndroidPageObjectChecksAttributesForNativeAndroidApp
    {
        [FindsByAndroidUIAutomator(AndroidUIAutomator = "new UiSelector().resourceId(\"android:id/text1\")")]
        private IMobileElement<AndroidElement> testMobileElement;

        [FindsByAndroidUIAutomator(AndroidUIAutomator = "new UiSelector().resourceId(\"android:id/text1\")")]
        private IList<AndroidElement> testMobileElements;

        [FindsByAndroidUIAutomator(AndroidUIAutomator = "new UiSelector().resourceId(\"android:id/text1\")")]
        private IMobileElement<AndroidElement> TestMobileElement
        {
            set;get;
        }

        [FindsByAndroidUIAutomator(AndroidUIAutomator = "new UiSelector().resourceId(\"android:id/text1\")")]
        private IList<AndroidElement> TestMobileElements
        {
            set;get;
        }

        [FindsByAndroidUIAutomator(AndroidUIAutomator = "new UiSelector().resourceId(\"android:id/fakeId\")", Priority = 1)]
        [FindsByAndroidUIAutomator(ID = "FakeId", Priority = 2)]
        [FindsByAndroidUIAutomator(ClassName = "android.widget.TextView", Priority = 3)]
        private IMobileElement<AndroidElement> testMultipleElement;

        [FindsByAndroidUIAutomator(AndroidUIAutomator = "new UiSelector().resourceId(\"android:id/fakeId\")", Priority = 1)]
        [FindsByAndroidUIAutomator(ID = "FakeId", Priority = 2)]
        [FindsByAndroidUIAutomator(ClassName = "android.widget.TextView", Priority = 3)]
        private IList<AndroidElement> testMultipleElements;


        /////////////////////////////////////////////////////////////////
        private object testMultipleFindByElementProperty;
        private object testMultipleFindByElementsProperty;
        /////////////////////////////////////////////////////////////////

        [FindsByAndroidUIAutomator(AndroidUIAutomator = "new UiSelector().resourceId(\"android:id/fakeId\")", Priority = 1)]
        [FindsByAndroidUIAutomator(ID = "FakeId", Priority = 2)]
        [FindsByAndroidUIAutomator(ClassName = "android.widget.TextView", Priority = 3)]
        private IMobileElement<AndroidElement> TestMultipleFindByElementProperty
        {
            set
            {
                testMultipleFindByElementProperty = value;
            }
            get
            {
                return (IMobileElement<AndroidElement>) testMultipleFindByElementProperty;
            }
        }

        [FindsByAndroidUIAutomator(AndroidUIAutomator = "new UiSelector().resourceId(\"android:id/fakeId\")", Priority = 1)]
        [FindsByAndroidUIAutomator(ID = "FakeId", Priority = 2)]
        [FindsByAndroidUIAutomator(ClassName = "android.widget.TextView", Priority = 3)]
        private IList<AndroidElement> MultipleFindByElementsProperty
        {
            set
            {
                testMultipleFindByElementsProperty = value;
            }
            get
            {
                return (IList<AndroidElement>) testMultipleFindByElementsProperty;
            }
        }

        [MobileFindsBySequence(Android = true)]
        [FindsByAndroidUIAutomator(AndroidUIAutomator = "new UiSelector().resourceId(\"android:id/content\")", Priority = 1)]
        [FindsByAndroidUIAutomator(AndroidUIAutomator = "new UiSelector().resourceId(\"android:id/list\")", Priority = 2)]
        [FindsByAndroidUIAutomator(ClassName = "android.widget.TextView", Priority = 3)]
        private IMobileElement<AndroidElement> foundByChainedSearchElement;

        [MobileFindsBySequence(Android = true)]
        [FindsByAndroidUIAutomator(AndroidUIAutomator = "new UiSelector().resourceId(\"android:id/content\")", Priority = 1)]
        [FindsByAndroidUIAutomator(AndroidUIAutomator = "new UiSelector().resourceId(\"android:id/list\")", Priority = 2)]
        [FindsByAndroidUIAutomator(ClassName = "android.widget.TextView", Priority = 3)]
        private IList<AndroidElement> foundByChainedSearchElements;

        /////////////////////////////////////////////////////////////////
        private object foundByChainedSearchElementProperty;
        private object foundByChainedSearchElementsProperty;
        /////////////////////////////////////////////////////////////////

        [MobileFindsBySequence(Android = true)]
        [FindsByAndroidUIAutomator(AndroidUIAutomator = "new UiSelector().resourceId(\"android:id/content\")", Priority = 1)]
        [FindsByAndroidUIAutomator(AndroidUIAutomator = "new UiSelector().resourceId(\"android:id/list\")", Priority = 2)]
        [FindsByAndroidUIAutomator(ClassName = "android.widget.TextView", Priority = 3)]
        private IMobileElement<AndroidElement> TestFoundByChainedSearchElementProperty
        {
            set
            {
                foundByChainedSearchElementProperty = value;
            }
            get
            {
                return (IMobileElement<AndroidElement>) foundByChainedSearchElementProperty;
            }
        }

        [MobileFindsBySequence(Android = true)]
        [FindsByAndroidUIAutomator(AndroidUIAutomator = "new UiSelector().resourceId(\"android:id/content\")", Priority = 1)]
        [FindsByAndroidUIAutomator(AndroidUIAutomator = "new UiSelector().resourceId(\"android:id/list\")", Priority = 2)]
        [FindsByAndroidUIAutomator(ClassName = "android.widget.TextView", Priority = 3)]
        private IList<AndroidElement> TestFoundByChainedSearchElementsProperty
        {
            set
            {
                foundByChainedSearchElementsProperty = value;
            }
            get
            {
                return (IList<AndroidElement>) foundByChainedSearchElementsProperty;
            }
        }

        [MobileFindsByAll(Android = true)]
        [FindsByAndroidUIAutomator(ID = "android:id/text1", Priority = 1)]
        //[FindsByAndroidUIAutomator(ClassName = "android.widget.TextView", Priority = 2)]
        //Equals method of RemoteWebElement is not consistent for mobile apps
        //The second selector will be commented till the problem is worked out
        private IMobileElement<AndroidElement> matchedToAllLocatorsElement;

        [MobileFindsByAll(Android = true)]
        [FindsByAndroidUIAutomator(ID = "android:id/text1", Priority = 1)]
        //[FindsByAndroidUIAutomator(ClassName = "android.widget.TextView", Priority = 2)]
        //Equals method of RemoteWebElement is not consistent for mobile apps
        //The second selector will be commented till the problem is worked out
        private IList<AndroidElement> matchedToAllLocatorsElements;

        /////////////////////////////////////////////////////////////////
        private object matchedToAllLocatorsElementProperty;
        private object matchedToAllLocatorsElementsProperty;
        /////////////////////////////////////////////////////////////////

        [MobileFindsByAll(Android = true)]
        [FindsByAndroidUIAutomator(ID = "android:id/text1", Priority = 1)]
        //[FindsByAndroidUIAutomator(ClassName = "android.widget.TextView", Priority = 2)]
        //Equals method of RemoteWebElement is not consistent for mobile apps
        //The second selector will be commented till the problem is worked out
        private IMobileElement<AndroidElement> TestMatchedToAllLocatorsElementProperty
        {
            set
            {
                matchedToAllLocatorsElementProperty = value;
            }
            get
            {
                return (IMobileElement<AndroidElement>) matchedToAllLocatorsElementProperty;
            }
        }

        [MobileFindsByAll(Android = true)]
        [FindsByAndroidUIAutomator(ID = "android:id/text1", Priority = 1)]
        //[FindsByAndroidUIAutomator(ClassName = "android.widget.TextView", Priority = 2)]
        //Equals method of RemoteWebElement is not consistent for mobile apps
        //The second selector will be commented till the problem is worked out
        private IList<AndroidElement> TestMatchedToAllLocatorsElementsProperty
        {
            set
            {
                matchedToAllLocatorsElementsProperty = value;
            }
            get
            {
                return (IList<AndroidElement>) matchedToAllLocatorsElementsProperty;
            }
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
