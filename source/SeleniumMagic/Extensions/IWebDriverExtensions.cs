using System;
using OpenQA.Selenium;

namespace SeleniumMagic.Extensions
{
    // ReSharper disable once InconsistentNaming
    public static class IWebDriverExtensions
    {
        public static Uri Uri(this IWebDriver webDriver)
        {
            return new Uri(webDriver.Url);
        }
    }
}