using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace GMS.Web.Admin.Controllers
{
    public class HomeController : Controller
    {
        // GET: /Home/

        public ActionResult Index()
        {
            string sql = string.Format("select * from Cuisine");
            Popular_recipesEntities pop = new Popular_recipesEntities();
            List<Cuisine> list = pop.Cuisine.SqlQuery(sql).ToList();
            Session.Add("caixi", list);
            return RedirectToAction("Index", "Auth", new { Area = "Account" });
        }
        
    }
}
