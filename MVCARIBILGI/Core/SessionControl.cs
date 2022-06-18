using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCARIBILGI.Core
{
    public class SessionControl:ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (HttpContext.Current.Session["Kullanici"] != null)
            {
                
            }
            else
            {
                HttpContext.Current.Response.Redirect("/Home/Index");
            }
        }
    }
}