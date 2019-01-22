using RazorViewDependencyInjection.Contracts;
using System.Web.Mvc;

namespace RazorViewDependencyInjection.Pages
{
    public abstract class InjectableWebViewLayoutPage<T> : WebViewPage<T>
    {
        public ITokenService TokenService { get; set; }

        public override void InitHelpers()
        {
            TokenService = DependencyResolver.Current.GetService<ITokenService>();

            base.InitHelpers();
        }
    }
}
