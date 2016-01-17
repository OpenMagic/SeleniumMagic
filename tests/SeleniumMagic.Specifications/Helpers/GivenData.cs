using System;
using OpenQA.Selenium;
using SeleniumMagic.PageObjects;

namespace SeleniumMagic.Specifications.Helpers
{
    public class GivenData
    {
        // ReSharper disable once InconsistentNaming
        public Type TPageObject;
        public string Uri;
        public IUriFactory UriFactory;
        public IWebDriver WebDriver;
    }
}