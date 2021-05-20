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
        //推荐
        public ActionResult TuiJian(int id)
        {
            var model = this.AccountService.GetRole(id);

            var businessPermissionList = EnumHelper.GetItemValueList<EnumBusinessPermission>();
            //this.ViewBag.BusinessPermissionList = new SelectList(businessPermissionList, "Key", "Value", string.Join(",", model.BusinessPermissionList.Select(p => (int)p)));

            return View(model);
        }

        //
        // POST: /Account/Role/Edit/5
        //推荐
        [HttpPost]
        public ActionResult TuiJian(int id, FormCollection collection)
        {
            var model = this.AccountService.GetRole(id);
            this.TryUpdateModel<Role>(model);
            model.BusinessPermissionString = collection["BusinessPermissionList"];
            this.AccountService.SaveRole(model);

            return this.RefreshParent();
        }

        // GET: /Account/Role/Edit/5
        //点评
        public ActionResult DianPing(int id=1)
        {
            var model = this.AccountService.GetRole(id);

            var businessPermissionList = EnumHelper.GetItemValueList<EnumBusinessPermission>();
            //this.ViewBag.BusinessPermissionList = new SelectList(businessPermissionList, "Key", "Value", string.Join(",", model.BusinessPermissionList.Select(p => (int)p)));

            return View(model);
        }

        //
        // POST: /Account/Role/Edit/5
        //点评
        [HttpPost]
        public ActionResult DianPing(int id, FormCollection collection)
        {
            var model = this.AccountService.GetRole(id);
            this.TryUpdateModel<Role>(model);
            model.BusinessPermissionString = collection["BusinessPermissionList"];
            this.AccountService.SaveRole(model);

            return this.RefreshParent();
        }

        // GET: /Account/Role/Edit/5
        //详细信息
        public ActionResult XiangXi(int id)
        {
            var model = this.AccountService.GetRole(id);

            var businessPermissionList = EnumHelper.GetItemValueList<EnumBusinessPermission>();
            //this.ViewBag.BusinessPermissionList = new SelectList(businessPermissionList, "Key", "Value", string.Join(",", model.BusinessPermissionList.Select(p => (int)p)));

            return View(model);
        }

        //
        // POST: /Account/Role/Edit/5
        //详细信息
        [HttpPost]
        public ActionResult XiangXi(int id, FormCollection collection)
        {
            var model = this.AccountService.GetRole(id);
            this.TryUpdateModel<Role>(model);
            model.BusinessPermissionString = collection["BusinessPermissionList"];
            this.AccountService.SaveRole(model);

            return this.RefreshParent();
        }

        // GET: /Account/Role/Edit/5
        //编辑资料
        public ActionResult Bianji(int id)
        {
            var model = this.AccountService.GetRole(id);

            var businessPermissionList = EnumHelper.GetItemValueList<EnumBusinessPermission>();
            //this.ViewBag.BusinessPermissionList = new SelectList(businessPermissionList, "Key", "Value", string.Join(",", model.BusinessPermissionList.Select(p => (int)p)));

            return View(model);
        }

        //
        // POST: /Account/Role/Edit/5
        //编辑资料
        [HttpPost]
        public ActionResult Bianji(int id, FormCollection collection)
        {
            var model = this.AccountService.GetRole(id);
            this.TryUpdateModel<Role>(model);
            model.BusinessPermissionString = collection["BusinessPermissionList"];
            this.AccountService.SaveRole(model);

            return this.RefreshParent();
        }

        public ActionResult XinZeng()
        {
            var businessPermissionList = EnumHelper.GetItemValueList<EnumBusinessPermission>();
            this.ViewBag.BusinessPermissionList = new SelectList(businessPermissionList, "Key", "Value");

            var model = new Role();
            return View(model);
        }
    }
}
