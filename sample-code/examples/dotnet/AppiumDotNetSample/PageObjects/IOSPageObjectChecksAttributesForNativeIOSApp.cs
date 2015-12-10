using OpenQA.Selenium.Appium.Interfaces;
using OpenQA.Selenium.Appium.iOS;
using OpenQA.Selenium.Appium.PageObjects.Attributes;
using System.Collections.Generic;

namespace Appium.Samples.PageObjects
{
    public class IOSPageObjectChecksAttributesForNativeIOSApp
    {
        /////////////////////////////////////////////////////////////////

        [FindsByIOSUIAutomation(IosUIAutomation = ".elements()[0]")]
        private IMobileElement<IOSElement> testMobileElement;

        [FindsByIOSUIAutomation(IosUIAutomation = ".elements()[0]")]
        private IList<IOSElement> testMobileElements;

        [FindsByIOSUIAutomation(IosUIAutomation = ".elements()[0]")]
        private IMobileElement<IOSElement> TestMobileElement
        {
            set; get;
        }

        [FindsByIOSUIAutomation(IosUIAutomation = ".elements()[0]")]
        private IList<IOSElement> TestMobileElements
        {
            set; get;
        }

        [FindsByIOSUIAutomation(ID = "FakeID", Priority = 1)]
        [FindsByIOSUIAutomation(ClassName = "UIAUAIFakeClass", Priority = 2)]
        [FindsByIOSUIAutomation(ClassName = "UIAButton", Priority = 3)]
        private IMobileElement<IOSElement> testMultipleElement;

        [FindsByIOSUIAutomation(ID = "FakeID", Priority = 1)]
        [FindsByIOSUIAutomation(ClassName = "UIAUAIFakeClass", Priority = 2)]
        [FindsByIOSUIAutomation(ClassName = "UIAButton", Priority = 3)]
        private IList<IOSElement> testMultipleElements;


        /////////////////////////////////////////////////////////////////

        [FindsByIOSUIAutomation(ID = "FakeID", Priority = 1)]
        [FindsByIOSUIAutomation(ClassName = "UIAUAIFakeClass", Priority = 2)]
        [FindsByIOSUIAutomation(ClassName = "UIAButton", Priority = 3)]
        private IMobileElement<IOSElement> TestMultipleFindByElementProperty
        {
            set; get;
        }

        [FindsByIOSUIAutomation(ID = "FakeID", Priority = 1)]
        [FindsByIOSUIAutomation(ClassName = "UIAUAIFakeClass", Priority = 2)]
        [FindsByIOSUIAutomation(ClassName = "UIAButton", Priority = 3)]
        private IList<IOSElement> MultipleFindByElementsProperty
        {
            set; get;
        }

        [MobileFindsByAll(IOS = true)]
        [FindsByIOSUIAutomation(ClassName = "UIAButton", Priority = 1)]
        //Equals method of RemoteWebElement is not consistent for mobile apps
        //The second selector won't be added till the problem is worked out
        private IMobileElement<IOSElement> matchedToAllLocatorsElement;

        [MobileFindsByAll(IOS = true)]
        [FindsByIOSUIAutomation(ClassName = "UIAButton", Priority = 1)]
        //Equals method of RemoteWebElement is not consistent for mobile apps
        //The second selector won't be added till the problem is worked out
        private IList<IOSElement> matchedToAllLocatorsElements;

        /////////////////////////////////////////////////////////////////

        [MobileFindsByAll(IOS = true)]
        [FindsByIOSUIAutomation(ClassName = "UIAButton", Priority = 1)]
        //Equals method of RemoteWebElement is not consistent for mobile apps
        //The second selector won't be added till the problem is worked out
        private IMobileElement<IOSElement> TestMatchedToAllLocatorsElementProperty
        {
            set; get;
        }

        [MobileFindsByAll(IOS = true)]
        [FindsByIOSUIAutomation(ClassName = "UIAButton", Priority = 1)]
        //Equals method of RemoteWebElement is not consistent for mobile apps
        //The second selector won't be added till the problem is worked out
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
