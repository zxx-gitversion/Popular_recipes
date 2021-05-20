using System.Web.Mvc;

namespace GMS.Web.Admin.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return RedirectToAction("Index", "Auth", new { Area = "Account" });
        }
    }
}
