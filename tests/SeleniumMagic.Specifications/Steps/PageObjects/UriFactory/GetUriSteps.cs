using System;
using System.Reflection;
using FluentAssertions;
using OpenMagic.Extensions;
using SeleniumMagic.Specifications.Helpers;
using SeleniumMagic.Specifications.Helpers.PageObjects.Test;
using TechTalk.SpecFlow;

namespace SeleniumMagic.Specifications.Steps.PageObjects.UriFactory
{
    [Binding]
    public class GetUriSteps
    {
        private readonly ActualData _actual;
        private readonly GivenData _given;

        public GetUriSteps(GivenData given, ActualData actual)
        {
            _given = given;
            _actual = actual;
        }

        [Given(@"TPageObject is in PageObjects namespace")]
        public void GivenTPageObjectIsInPageObjectsNamespace()
        {
            // nothing to do. step helps reading specification
        }

        [Given(@"TPageObject is \*\.PageObjects\.(.*)")]
        public void GivenTPageObjectIs_PageObjects(string pageObjectName)
        {
            var pageObjectsNamespace = typeof(Index).Namespace.TextBeforeLast(".Test");
            var fullPageObjectName = $"{pageObjectsNamespace}.{pageObjectName}";

            _given.TPageObject = Assembly.GetExecutingAssembly().GetType(fullPageObjectName);

            if (_given.TPageObject == null)
            {
                throw new Exception($"Cannot find TPageObject '{fullPageObjectName}'.");
            }
        }

        [Given(@"currentUri is (.*)")]
        public void GivenCurrentUri(string currentUri)
        {
            _given.Uri = currentUri;
        }

        [When(@"I call GetUri\<TPageObject\>\(Uri currentUri\)")]
        public void WhenICall_GetUri_TPageObject_Uri_currentUri()
        {
            var uriFactory = new SeleniumMagic.PageObjects.UriFactory();
            var method = uriFactory.GetType().GetMethod("GetUri");
            var genericMethod = method.MakeGenericMethod(_given.TPageObject);

            _actual.Uri = genericMethod.Invoke(uriFactory, new object[] {new Uri(_given.Uri)}).ToString();
        }

        [Then(@"the Uri should be (.*)")]
        public void ThenTheResultShouldBe(string expectedUri)
        {
            _actual.Uri.Should().Be(expectedUri);
        }
    }
}