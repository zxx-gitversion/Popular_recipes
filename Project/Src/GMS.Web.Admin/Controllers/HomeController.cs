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
        public ActionResult _Menu(){
            Popular_recipesEntities pop = new Popular_recipesEntities();
            var list = (from p in pop.Cuisine select p);
            return (list);
            }
    }
}
