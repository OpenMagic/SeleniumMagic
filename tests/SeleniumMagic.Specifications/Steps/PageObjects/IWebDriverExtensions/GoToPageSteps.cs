using FluentAssertions;
using SeleniumMagic.PageObjects;
using SeleniumMagic.Specifications.Helpers;
using SeleniumMagic.Specifications.Helpers.PageObjects.Test;
using TechTalk.SpecFlow;

namespace SeleniumMagic.Specifications.Steps.PageObjects.IWebDriverExtensions
{
    [Binding]
    public class GoToPageSteps
    {
        private readonly CreateFake _createFake;
        private readonly GivenData _given;

        public GoToPageSteps(GivenData given, CreateFake createFake)
        {
            _given = given;
            _createFake = createFake;
        }

        [Given(@"I have a webDriver")]
        public void GivenIHaveAWebDriver()
        {
            _given.WebDriver = _createFake.WebDriver();
        }

        [Given(@"I have a uriFactory")]
        public void GivenIHaveAUriFactory()
        {
            _given.UriFactory = _createFake.UriFactory();
        }

        [When(@"I call GoToPage\<TTestPage\>\(webDriver, uriFactory\)")]
        public void WhenICallGoToPageWebDriverUriFactory()
        {
            _given.WebDriver.GoToPage<Index>(_given.UriFactory);
        }

        [When(@"I call GoToPage\<TTestPage\>\(webDriver\)")]
        public void WhenICallGoToPageIWebDriver()
        {
            _given.WebDriver.GoToPage<Index>();
        }

        [Then(@"webDriver\.Url should be /test")]
        public void ThenWebDriver_UrlShouldBeTest_Uri()
        {
            _given.WebDriver.Url.Should().Be($"{CreateFake.Url}test");
        }
    }
}