using System.Linq;
using System.Web.Mvc;
using GMS.Account.Contract;
using GMS.Framework.Utility;
using GMS.Web.Admin.Common;

namespace GMS.Web.Admin.Areas.Account.Controllers
{
    [Permission(EnumBusinessPermission.AccountManage_Role)]
    public class MinController : AdminControllerBase
    {
        //
        // GET: /Account/Hui/

        public ActionResult Index()
        {
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

    }
}
