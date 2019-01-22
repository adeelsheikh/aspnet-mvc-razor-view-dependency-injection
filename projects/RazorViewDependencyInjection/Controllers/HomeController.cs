using RazorViewDependencyInjection.Contracts;
using System.Web.Mvc;

namespace RazorViewDependencyInjection.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITokenService _tokenService;

        public HomeController(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        public ActionResult Index()
        {
            ViewBag.Token = _tokenService.ApiToken;

            return View();
        }
    }
}