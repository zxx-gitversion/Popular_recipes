using System.Web.Mvc;
using System.Linq;

namespace GMS.Web.Admin.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            Popular_recipesEntities pop = new Popular_recipesEntities();
            var list = (from p in pop.Cuisine select p);
            ViewData["list"] = list;
            return RedirectToAction("Index", "Auth", new { Area = "Account" });
        }
        public ActionResult _Menu(){
            Popular_recipesEntities pop = new Popular_recipesEntities();
            var list = (from p in pop.Cuisine select p);
            return View(list);
         }
    }
}
