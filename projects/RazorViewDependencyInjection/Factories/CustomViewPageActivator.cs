using System;
using System.Web.Mvc;
using Unity;

namespace RazorViewDependencyInjection.Factories
{
    public class CustomViewPageActivator : IViewPageActivator
    {
        private IUnityContainer container;

        public CustomViewPageActivator(IUnityContainer container)
        {
            this.container = container;
        }

        public object Create(ControllerContext controllerContext, Type type)
        {
            return container.Resolve(type);
        }
    }
}
