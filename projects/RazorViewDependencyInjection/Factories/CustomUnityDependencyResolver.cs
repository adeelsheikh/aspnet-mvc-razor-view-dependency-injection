using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Unity;

namespace RazorViewDependencyInjection.Factories
{
    public class CustomUnityDependencyResolver : IDependencyResolver
    {
        private IUnityContainer _container;
        private IDependencyResolver _resolver;

        public CustomUnityDependencyResolver(IUnityContainer container, IDependencyResolver resolver)
        {
            _container = container;
            _resolver = resolver;
        }

        public object GetService(Type serviceType)
        {
            try
            {
                return _container.Resolve(serviceType);
            }
            catch
            {
                return _resolver.GetService(serviceType);
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            try
            {
                return _container.ResolveAll(serviceType);
            }
            catch
            {
                return _resolver.GetServices(serviceType);
            }
        }
    }
}
