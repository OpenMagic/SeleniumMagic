using System;
using Microsoft.Practices.ServiceLocation;
using OpenQA.Selenium;
using SeleniumMagic.Extensions;

namespace SeleniumMagic.PageObjects
{
    // ReSharper disable once InconsistentNaming
    public static class IWebDriverExtensions
    {
        public static IWebDriver GoToPage<TPageObject>(this IWebDriver webDriver)
        {
            return webDriver.GoToPage<TPageObject>(ServiceLocator.Current.GetInstance<IUriFactory>());
        }

        public static IWebDriver GoToPage<TPageObject>(this IWebDriver webDriver, IUriFactory uriFactory)
        {
            return webDriver.GoToPage(typeof(TPageObject), uriFactory);
        }

        public static IWebDriver GoToPage(this IWebDriver webDriver, Type pageObjectType, IUriFactory uriFactory)
        {
            var currentUri = webDriver.Uri();
            var newUri = uriFactory.GetUri(pageObjectType, currentUri);

            webDriver.Navigate().GoToUrl(newUri);

            return webDriver;
        }
    }
}