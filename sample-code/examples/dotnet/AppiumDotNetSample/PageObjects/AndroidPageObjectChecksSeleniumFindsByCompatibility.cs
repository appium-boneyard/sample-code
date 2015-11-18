using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Interfaces;
using OpenQA.Selenium.Support.PageObjects;
using System.Collections.Generic;

namespace Appium.Samples.PageObjects
{
    public class AndroidPageObjectChecksSeleniumFindsByCompatibility
    {
        [FindsBy(How = How.ClassName, Using = "android.widget.TextView")]
        private IWebElement testElement;

        /////////////////////////////////////////////////////////////////

        [FindsBy(How = How.ClassName, Using = "android.widget.TextView")]
        private IWebElement TestElement
        {
            set; get;
        }

        [FindsBy(How = How.ClassName, Using = "android.widget.TextView")]
        private IList<IWebElement> testElements;

        [FindsBy(How = How.ClassName, Using = "android.widget.TextView")]
        private IList<IWebElement> TestElements
        {
            set; get;
        }

        /////////////////////////////////////////////////////////////////

        [FindsBy(How = How.ClassName, Using = "android.widget.TextView")]
        private IMobileElement<AndroidElement> testMobileElement;

        [FindsBy(How = How.ClassName, Using = "android.widget.TextView")]
        private IList<AndroidElement> testMobileElements;

        [FindsBy(How = How.ClassName, Using = "android.widget.TextView")]
        private IMobileElement<AndroidElement> TestMobileElement
        {
            set; get;
        }

        [FindsBy(How = How.ClassName, Using = "android.widget.TextView")]
        private IList<AndroidElement> TestMobileElements
        {
            set; get;
        }

        [FindsBy(How = How.Name, Using = "FakeName", Priority = 1)]
        [FindsBy(How = How.Id, Using = "FakeId", Priority = 2)]
        [FindsBy(How = How.ClassName, Using = "android.widget.TextView", Priority = 3)]
        private IMobileElement<AndroidElement> testMultipleElement;

        [FindsBy(How = How.Name, Using = "FakeName", Priority = 1)]
        [FindsBy(How = How.Id, Using = "FakeId", Priority = 2)]
        [FindsBy(How = How.ClassName, Using = "android.widget.TextView", Priority = 3)]
        private IList<AndroidElement> testMultipleElements;


        /////////////////////////////////////////////////////////////////

        [FindsBy(How = How.Name, Using = "FakeName", Priority = 1)]
        [FindsBy(How = How.Id, Using = "FakeId", Priority = 2)]
        [FindsBy(How = How.ClassName, Using = "android.widget.TextView", Priority = 3)]
        private IMobileElement<AndroidElement> TestMultipleFindByElementProperty
        {
            set; get;
        }

        [FindsBy(How = How.Name, Using = "FakeName", Priority = 1)]
        [FindsBy(How = How.Id, Using = "FakeId", Priority = 2)]
        [FindsBy(How = How.ClassName, Using = "android.widget.TextView", Priority = 3)]
        private IList<AndroidElement> MultipleFindByElementsProperty
        {
            set; get;
        }

        [FindsBySequence]
        [FindsBy(How = How.Id, Using = "android:id/content", Priority = 1)]
        [FindsBy(How = How.Id, Using = "android:id/list", Priority = 2)]
        [FindsBy(How = How.ClassName, Using = "android.widget.TextView", Priority = 3)]
        private IMobileElement<AndroidElement> foundByChainedSearchElement;

        [FindsBySequence]
        [FindsBy(How = How.Id, Using = "android:id/content", Priority = 1)]
        [FindsBy(How = How.Id, Using = "android:id/list", Priority = 2)]
        [FindsBy(How = How.ClassName, Using = "android.widget.TextView", Priority = 3)]
        private IList<AndroidElement> foundByChainedSearchElements;

        /////////////////////////////////////////////////////////////////

        [FindsBySequence]
        [FindsBy(How = How.Id, Using = "android:id/content", Priority = 1)]
        [FindsBy(How = How.Id, Using = "android:id/list", Priority = 2)]
        [FindsBy(How = How.ClassName, Using = "android.widget.TextView", Priority = 3)]
        private IMobileElement<AndroidElement> TestFoundByChainedSearchElementProperty
        {
            set; get;
        }

        [FindsBySequence]
        [FindsBy(How = How.Id, Using = "android:id/content", Priority = 1)]
        [FindsBy(How = How.Id, Using = "android:id/list", Priority = 2)]
        [FindsBy(How = How.ClassName, Using = "android.widget.TextView", Priority = 3)]
        private IList<AndroidElement> TestFoundByChainedSearchElementsProperty
        {
            set; get;
        }

        [FindsByAll]
        [FindsBy(How = How.Id, Using = "android:id/text1", Priority = 1)]
        //[FindsBy(How = How.ClassName, Using = "android.widget.TextView", Priority = 2)]
        //Equals method of RemoteWebElement is not consistent for mobile apps
        //The second selector will be commented till the problem is worked out
        private IMobileElement<AndroidElement> matchedToAllLocatorsElement;

        [FindsByAll]
        [FindsBy(How = How.Id, Using = "android:id/text1", Priority = 1)]
        //[FindsBy(How = How.ClassName, Using = "android.widget.TextView", Priority = 2)]
        //Equals method of RemoteWebElement is not consistent for mobile apps
        //The second selector will be commented till the problem is worked out
        private IList<AndroidElement> matchedToAllLocatorsElements;

        /////////////////////////////////////////////////////////////////
        [FindsByAll]
        [FindsBy(How = How.Id, Using = "android:id/text1", Priority = 1)]
        //[FindsBy(How = How.ClassName, Using = "android.widget.TextView", Priority = 2)]
        //Equals method of RemoteWebElement is not consistent for mobile apps
        //The second selector will be commented till the problem is worked out
        private IMobileElement<AndroidElement> TestMatchedToAllLocatorsElementProperty
        {
            set;get;
        }

        [FindsByAll]
        [FindsBy(How = How.Id, Using = "android:id/text1", Priority = 1)]
        //[FindsBy(How = How.ClassName, Using = "android.widget.TextView", Priority = 2)]
        //Equals method of RemoteWebElement is not consistent for mobile apps
        //The second selector will be commented till the problem is worked out
        private IList<AndroidElement> TestMatchedToAllLocatorsElementsProperty
        {
            set;get;
        }

        public string GetElementText()
        {
            return testElement.Text;
        }

        public int GetElementSize()
        {
            return testElements.Count;
        }

        public string GetElementPropertyText()
        {
            return TestElement.Text;
        }

        public int GetElementPropertySize()
        {
            return TestElements.Count;
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
