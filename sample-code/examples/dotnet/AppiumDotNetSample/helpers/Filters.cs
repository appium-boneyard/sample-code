using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using System.Collections;

namespace Appium.Samples.Helpers
{
    public class Filters
    {
        public static IWebElement FirstWithName<W>(IList<W> els, string name) where W : IWebElement
        {
            for (int i = 0; i < els.Count; i++)
            {
                if (els[i].GetAttribute("name") == name)
                {
                    return (W)els[i];
                }
            }
            return null;
        }

        public static IList<IWebElement> FilterWithName<W>(IList<W> els, string name) where W : IWebElement
        {
            var res = new List<IWebElement>();
            for (int i = 0; i < els.Count; i++)
            {
                if (els[i].GetAttribute("name") == name)
                {
                    res.Add(els[i]);
                }
            }
            return res;

        }

        public static IList<IWebElement> FilterDisplayed<W>(IList<W> els) where W : IWebElement
        {
            var res = new List<IWebElement>();
            for (int i = 0; i < els.Count; i++)
            {
                IWebElement el = els[i];
                if (els[i].Displayed)
                {
                    res.Add(els[i]);
                }
            }
            return res;
        }

    }
}
