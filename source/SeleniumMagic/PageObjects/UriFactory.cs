using System;
using OpenMagic.Extensions;

namespace SeleniumMagic.PageObjects
{
    public class UriFactory : IUriFactory
    {
        public Uri GetUri<TPageObject>(Uri currentUri)
        {
            return GetUri(typeof(TPageObject), currentUri);
        }

        public Uri GetUri(Type pageObjectType, Uri currentUri)
        {
            var fullName = pageObjectType.FullName;
            var pageObjectsIndex = fullName.IndexOf(".PageObjects.", StringComparison.Ordinal);

            if (pageObjectsIndex < 0)
            {
                throw new ArgumentException("TPageObject must by in *.PageObjects namespace.");
            }

            var baseUri = new Uri($"{currentUri.Scheme}://{currentUri.Authority}/");
            var relativeUri = $"/{fullName.Substring(pageObjectsIndex + 13).ToLower().Replace(".", "/")}";

            if (relativeUri.EndsWith("/index"))
            {
                relativeUri = relativeUri.TextBeforeLast("/index");
            }

            var uri = new Uri(baseUri, relativeUri);

            return uri;
        }
    }
}