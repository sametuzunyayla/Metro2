using System;

using System.Collections.Generic;

using System.Linq;

using System.Text;

using System.Threading.Tasks;

using System.Web;

using System.Web.Mvc;



namespace Metro.Models

{

    public class SessionExpireAttribute : ActionFilterAttribute

    {

        public override void OnActionExecuting(ActionExecutingContext filterContext)

        {

            HttpContext ctx = HttpContext.Current;

            if (HttpContext.Current.Session["Email"] == null)

            {

                filterContext.Result = new RedirectResult("~/Login/Giris");

                return;

            }

            base.OnActionExecuting(filterContext);

        }

    }



}