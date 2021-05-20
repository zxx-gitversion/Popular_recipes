using System;
using System.Web.Mvc;
using GMS.Account.Contract;
using GMS.OA.Contract;
using GMS.Web.Admin.Common;
using Newtonsoft.Json;

namespace GMS.Web.Admin.Areas.OA.Controllers
{
    [Permission(EnumBusinessPermission.OAManage_Org)]
    public class OrgController : AdminControllerBase
    {
        //
        // GET: /OA/Org/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetOrg()
        {
            var rootBranch = this.OAService.GetOrg();

            return Json(rootBranch, JsonRequestBehavior.AllowGet);
        }

        public ActionResult SaveOrg()
        {
            try
            {
                int bytelength = Request.ContentLength;
                byte[] inputbytes = Request.BinaryRead(bytelength);
                string message = System.Text.Encoding.UTF8.GetString(inputbytes);
                var branch = JsonConvert.DeserializeObject<Branch>(message);

                this.OAService.SaveOrg(branch);
            }
            catch (Exception e)
            {
                return Content(e.Message);
            }

            return Content("保存成功！");
        }
    }
}
