using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelCRM.ApplicationCore
{
    public enum PermissionItem
    {
        Admin,
        Manager,
        Employee,
        Operation,
        None
    }

    public enum PermissionAction
    {
        All,
        Read,
        Write,
        ReadWrite
    }


    public class TravelCRMAuthAttribute : TypeFilterAttribute
    {
        public TravelCRMAuthAttribute(PermissionItem item, PermissionAction action)
        : base(typeof(TravelCRMAuthActionFilter))
        {
            Arguments = new object[] { item, action };
        }
    }

    public class TravelCRMAuthActionFilter : IAsyncActionFilter
    {
        private readonly PermissionItem _item;
        private readonly PermissionAction _action;
        public TravelCRMAuthActionFilter(PermissionItem item, PermissionAction action)
        {
            _item = item;
            _action = action;
        }
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            // bool isAuthorized = Function(context.HttpContext.User, _item, _action); // :)
            bool isAuthorized = false;
            if (!isAuthorized)
            {
                context.Result = new UnauthorizedResult();

            }
            else
            {
                await next();
            }
        }
    }
}
