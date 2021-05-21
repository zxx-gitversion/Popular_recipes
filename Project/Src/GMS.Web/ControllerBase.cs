using System;
using System.Collections.Generic;
using System.Web.Mvc;
using GMS.Account.Contract;
using GMS.Cms.Contract;
/*<<<<<<< HEAD
//using GMS.Core.Log;
=======

>>>>>>> 93678788e1a99322a002cc8fc5e3d09259ac6cf5*/
using GMS.Crm.Contract;
using GMS.Framework.Web;
using GMS.OA.Contract;

namespace GMS.Web
{
    public abstract class ControllerBase : GMS.Framework.Web.ControllerBase
    {
        public virtual IAccountService AccountService
        {
            get
            {
                return ServiceContext.Current.AccountService;
            }
        }

        public virtual ICmsService CmsService
        {
            get
            {
                return ServiceContext.Current.CmsService;
            }
        }

        public virtual ICrmService CrmService
        {
            get
            {
                return ServiceContext.Current.CrmService;
            }
        }

        public virtual IOAService OAService
        {
            get
            {
                return ServiceContext.Current.OAService;
            }
        }

        protected override void LogException(Exception exception,
            WebExceptionContext exceptionContext = null)
        {
            base.LogException(exception);

            var message = new
            {
                exception = exception.Message,
                exceptionContext = exceptionContext,
            };

            //Log4NetHelper.Error(LoggerType.WebExceptionLog, message, exception);
        }

        public IDictionary<string, object> CurrentActionParameters { get; set; }

        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
        }
    }
}
