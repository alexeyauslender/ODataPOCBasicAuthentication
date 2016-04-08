
using System.Web.Mvc;

namespace ODataPOC.Controllers
{
    [Authorize] 
    public class HomeController : Controller
    {
       //[Route]
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
    }
}
    