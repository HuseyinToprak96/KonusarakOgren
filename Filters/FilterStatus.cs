using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KonusarakOgren.Filters
{
    public class FilterStatus : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            string yetki = context.HttpContext.Session.GetString("status");
            if (yetki != "Admin")
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary{
                    {"action","Index" },
                    { "controller","Page"}
                });
            }
            base.OnActionExecuting(context);
        }
    }
}
