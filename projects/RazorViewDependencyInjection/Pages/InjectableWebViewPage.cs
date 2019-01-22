using RazorViewDependencyInjection.Contracts;
using System.Web.Mvc;
using Unity.Attributes;

namespace RazorViewDependencyInjection.Pages
{
    public abstract class InjectableWebViewPage : WebViewPage
    {
        [Dependency]
        public ITokenService TokenService { get; set; }
    }
}