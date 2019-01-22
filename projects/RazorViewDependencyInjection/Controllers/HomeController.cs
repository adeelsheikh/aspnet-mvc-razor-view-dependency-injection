using System.Web.Mvc;

namespace RazorViewDependencyInjection.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}