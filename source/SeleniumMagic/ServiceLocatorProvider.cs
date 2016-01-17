using System;
using System.Collections.Generic;
using Microsoft.Practices.ServiceLocation;
using SeleniumMagic.PageObjects;

namespace SeleniumMagic
{
    public class ServiceLocatorProvider : ServiceLocatorImplBase
    {
        private readonly Dictionary<Type, Func<object>> _services;

        public ServiceLocatorProvider()
        {
            _services = new Dictionary<Type, Func<object>>
            {
                {typeof(IUriFactory), () => new UriFactory()}
            };
        }

        protected override object DoGetInstance(Type serviceType, string key)
        {
            if (!string.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentException($"{nameof(ServiceLocatorProvider)} does not support {nameof(key)} parameter having a value.", nameof(key));
            }

            Func<object> valueFactory;

            if (!_services.TryGetValue(serviceType, out valueFactory))
            {
                return null;
            }

            var value = valueFactory.Invoke();
            return value;
        }

        protected override IEnumerable<object> DoGetAllInstances(Type serviceType)
        {
            throw new NotSupportedException();
        }
    }
}