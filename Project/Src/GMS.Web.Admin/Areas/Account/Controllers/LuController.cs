using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using GMS.Account.Contract;
using GMS.Framework.Utility;
using GMS.Web.Admin.Common;


namespace GMS.Web.Admin.Areas.Account.Controllers
{
    [Permission(EnumBusinessPermission.AccountManage_Role)]
    public class LuController : AdminControllerBase
    {
        //
        // GET: /Account/Hui/

        public ActionResult Index(int id)
        {
            Popular_recipesEntities s = new Popular_recipesEntities();
            //if (name == null || name.Equals(""))
            //{
            //    var list = s.Menu.Where(g => g.CuisineId == id).ToList();
            //    ViewData["MenuList"] = list;
            //}
            //else
            //{
            //    List<Menu> li = s.Menu.SqlQuery("select * from Menu where Menu.MenuName like '%" + name.Trim() + "%'").ToList();
            //    ViewData["MenuList"] = li;
            //}
            var list = s.Menu.Where(g => g.CuisineId == id).ToList();
            Session["MenuList"] = list;
            Session["MenuId"] = id;
            return View();
        }
        // GET: /Account/Role/Edit/5

        public ActionResult Edit(int id)
        {
            var model = this.AccountService.GetRole(id);

            var businessPermissionList = EnumHelper.GetItemValueList<EnumBusinessPermission>();
            //this.ViewBag.BusinessPermissionList = new SelectList(businessPermissionList, "Key", "Value", string.Join(",", model.BusinessPermissionList.Select(p => (int)p)));

            return View(model);
        }

        //
        // POST: /Account/Role/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var model = this.AccountService.GetRole(id);
            this.TryUpdateModel<Role>(model);
            model.BusinessPermissionString = collection["BusinessPermissionList"];
            this.AccountService.SaveRole(model);

            return this.RefreshParent();
        }

        public ActionResult Delete(int[]ids)
        {
            Popular_recipesEntities s = new Popular_recipesEntities();

            if(ids!=null)
            {
                foreach (int item in ids)
                    s.Menu.Remove(s.Menu.Where(j => j.MenuId == item).FirstOrDefault());

                s.SaveChanges();
            }

            int id = (int)Session["MenuId"];
            var list = s.Menu.Where(g => g.CuisineId == id).ToList();
            Session["MenuList"] = list;

            return Redirect("Index?id="+id);

        }
    }
}
