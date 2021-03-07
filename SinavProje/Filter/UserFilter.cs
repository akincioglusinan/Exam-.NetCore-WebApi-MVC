using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using SinavProje.Entities.Concrete.Entities;
using SinavProje.Extensions;

namespace SinavProje.Filter
{
    public class UserFilter: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.HttpContext.Session.GetObject<User>("user") == null)
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary
                {
                    {"action", "Index"},
                    {"controller", "Auth"}
                });
            }
            base.OnActionExecuting(context);
        }
    }
}
