using System;
using FakeItEasy;
using OpenQA.Selenium;
using SeleniumMagic.PageObjects;
using SeleniumMagic.Specifications.Helpers.PageObjects.Test;

namespace SeleniumMagic.Specifications.Helpers
{
    public class CreateFake
    {
        public const string Url = "http://fake:3000/";

        public IWebDriver WebDriver()
        {
            var webDriver = A.Fake<IWebDriver>();
            var fakeUrl = Url;
            var fakeNavigation = A.Fake<INavigation>();

            A.CallTo(() => webDriver.Url)
                .ReturnsLazily(() => fakeUrl); // Must use ReturnsLazily for fakeNavigation.GoToUrl(url) to work

            A.CallTo(() => webDriver.Navigate())
                .Returns(fakeNavigation);

            A.CallTo(() => fakeNavigation.GoToUrl(A<string>.Ignored))
                .Invokes((string newUrl) => { fakeUrl = newUrl; });

            A.CallTo(() => fakeNavigation.GoToUrl(A<Uri>.Ignored))
                .Invokes((Uri newUrl) => { fakeNavigation.GoToUrl(newUrl.ToString()); });

            return webDriver;
        }

        public IUriFactory UriFactory()
        {
            var uriFactory = A.Fake<IUriFactory>();

            A.CallTo(() => uriFactory.GetUri<Index>(A<Uri>.Ignored))
                .ReturnsLazily((Uri currentUri) => new Uri($"{currentUri.Scheme}://{currentUri.Authority}/test"));

            A.CallTo(() => uriFactory.GetUri(A<Type>.Ignored, A<Uri>.Ignored))
                .ReturnsLazily((Type pageObjectType, Uri currentUri) => new Uri($"{currentUri.Scheme}://{currentUri.Authority}/test"));

            return uriFactory;
        }
    }
}