using System.Linq;
using System.Web.Mvc;
using GMS.Account.Contract;
using GMS.Framework.Utility;
using GMS.Web.Admin.Common;

namespace GMS.Web.Admin.Areas.Account.Controllers
{
    [Permission(EnumBusinessPermission.AccountManage_Role)]
    public class SharesController : AdminControllerBase
    {

        // GET: /Account/Role/Edit/5
        //点评
        public ActionResult DianPing(int id,string Evaluate)
        {
            Popular_recipesEntities ee = new Popular_recipesEntities();

            var li = ee.Menu.Where(g => g.MenuId == id).FirstOrDefault();

            ViewData["CuisineName"] = ee.Cuisine.Where(p => p.CuisineId == id).FirstOrDefault().CuisineName;

            if(Evaluate!=null)
            {
                evaluate evaluate = new evaluate() { MenuId = id, Evaluate1 = Evaluate };
                ee.evaluate.Add(evaluate);
                ee.SaveChanges();
            }

            return View(li);
        }

        // GET: /Account/Role/Edit/5
        //详细信息
        public ActionResult XiangXi(int id)
        {
            Popular_recipesEntities ee = new Popular_recipesEntities();
            Menu m= ee.Menu.Where(g => g.MenuId == id).FirstOrDefault();

            var li = ee.Menu.Where(g => g.MenuId == id).FirstOrDefault();

            ViewData["CuisineName"] = ee.Cuisine.Where(p => p.CuisineId == m.CuisineId).FirstOrDefault().CuisineName;

            return View(li);
        }

        // GET: /Account/Role/Edit/5
        //编辑资料
        public ActionResult Bianji(int id,Menu mm,string cx)
        { 
            Popular_recipesEntities ee = new Popular_recipesEntities();
            Menu m = ee.Menu.Where(g => g.MenuId == id).FirstOrDefault();
            var li = ee.Menu.Where(g => g.MenuId == id).FirstOrDefault();

            ViewData["CuisineName"] = ee.Cuisine.Where(p => p.CuisineId == m.CuisineId).FirstOrDefault().CuisineName;

            if (mm.MenuName!=null)
            {
                m.Money = mm.Money;
                m.MenuName = mm.MenuName;
                m.CookingSteps = mm.CookingSteps;
                m.Kg = mm.Kg;
                m.trait = mm.trait;
                m.Money = mm.Money;

                m.CuisineId=ee.Cuisine.Where(p => p.CuisineName == cx).FirstOrDefault().CuisineId;
                
                ee.SaveChanges();
            }
            

            return View(li);
        }

        public ActionResult XinZengs(Menu m)
        {
            if (m != null)
            {
                Popular_recipesEntities popular = new Popular_recipesEntities();
                popular.Menu.Add(m);
                popular.SaveChanges();
            }

            Popular_recipesEntities entities = new Popular_recipesEntities();
            var li = (from g in entities.Cuisine select g).ToList();
            ViewData["CuisineList"] = li;
            return View();
        }

        public void TuiJian(int id)
        {
            Popular_recipesEntities m = new Popular_recipesEntities();
            Menu s=m.Menu.Where(p => p.MenuId == id).FirstOrDefault();
            int i = s.tuijian ?? 0;
            i++;
            s.tuijian = i;
            m.SaveChanges();
            XinZengs(null);
        }


    }
}
