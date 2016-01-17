using System;

namespace SeleniumMagic.PageObjects
{
    public interface IUriFactory
    {
        Uri GetUri<TPageObject>(Uri currentUri);
    }
}