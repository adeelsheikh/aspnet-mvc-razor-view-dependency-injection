using RazorViewDependencyInjection.Factories;
using System.Linq;
using System.Web.Mvc;

using Unity.AspNet.Mvc;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(RazorViewDependencyInjection.UnityMvcActivator), nameof(RazorViewDependencyInjection.UnityMvcActivator.Start))]
[assembly: WebActivatorEx.ApplicationShutdownMethod(typeof(RazorViewDependencyInjection.UnityMvcActivator), nameof(RazorViewDependencyInjection.UnityMvcActivator.Shutdown))]

namespace RazorViewDependencyInjection
{
    /// <summary>
    /// Provides the bootstrapping for integrating Unity with ASP.NET MVC.
    /// </summary>
    public static class UnityMvcActivator
    {
        /// <summary>
        /// Integrates Unity when the application starts.
        /// </summary>
        public static void Start()
        {
            FilterProviders.Providers.Remove(FilterProviders.Providers.OfType<FilterAttributeFilterProvider>().First());
            FilterProviders.Providers.Add(new UnityFilterAttributeFilterProvider(UnityConfig.Container));

            DependencyResolver.SetResolver(new UnityDependencyResolver(UnityConfig.Container));

            var defaultResolver = DependencyResolver.Current;
            var customResolver = new CustomUnityDependencyResolver(UnityConfig.Container, defaultResolver);
            DependencyResolver.SetResolver(customResolver);
        }

        /// <summary>
        /// Disposes the Unity container when the application is shut down.
        /// </summary>
        public static void Shutdown()
        {
            UnityConfig.Container.Dispose();
        }
    }
}