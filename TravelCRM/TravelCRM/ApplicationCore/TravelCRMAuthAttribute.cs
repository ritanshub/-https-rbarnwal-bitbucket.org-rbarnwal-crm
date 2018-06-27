using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelCRMServices;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace TravelCRM.ApplicationCore
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public class TravelCRMAuthorizeAttribute : AuthorizeAttribute, IAuthorizationFilter
    {
        private readonly string _someFilterParameter;

        public TravelCRMAuthorizeAttribute(string someFilterParameter)
        {
            _someFilterParameter = someFilterParameter;
        }


        public TravelCRMAuthorizeAttribute()
        {

        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = context.HttpContext.User;

            if (!user.Identity.IsAuthenticated)
            {
                // it isn't needed to set unauthorized result 
                // as the base class already requires the user to be authenticated
                // this also makes redirect to a login page work properly
                // context.Result = new UnauthorizedResult();
                return;
            }

            int RoleID = GetRole(context.HttpContext);

            // you can also use registered services
            var AuthService = context.HttpContext.RequestServices.GetService<IAuthService>();

            var isAllowed = AuthService.HasPermission(RoleID, context.ActionDescriptor.RouteValues["Controller"], context.ActionDescriptor.RouteValues["action"], context.HttpContext.Request.Method);
            //var isAuthorized = someService.IsUserAuthorized(user.Identity.Name, _someFilterParameter);


            // context.Result = new StatusCodeResult((int)System.Net.HttpStatusCode.Forbidden);
             //The custom “401 Unauthorized” access error will be returned to the browser in response to the initial request.
            if (!isAllowed)
            {
               context.Result = new RedirectToRouteResult(new RouteValueDictionary { { "action", "Index" }, { "controller", "Unauthorised" } });

                return;
            }
        }


        private int GetRole(HttpContext httpcontext)
        {

            var User = httpcontext.User;
            string RoleID = User.Claims.FirstOrDefault(c => c.Type == "RoleID").Value;
            return int.Parse(RoleID);

            //string Role=string.Empty; 
            //if (User.Identity.IsAuthenticated)
            //{
            //    IEnumerable<Claim> claim = User.Claims;

            //    foreach (Claim c in claim)
            //    {
            //        if (c.Type == "RoleID")
            //        {

            //            Role = c.Value;
            //            break;
            //        }

            //    }
            //}

            //return int.Parse(Role);
        }

    }
}
