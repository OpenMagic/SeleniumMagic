using Microsoft.Practices.ServiceLocation;
using TechTalk.SpecFlow;

namespace SeleniumMagic.Specifications
{
    [Binding]
    public class IoC
    {
        [BeforeScenario]
        public void Initialize()
        {
            ServiceLocator.SetLocatorProvider(() => new ServiceLocatorProvider());
        }
    }
}