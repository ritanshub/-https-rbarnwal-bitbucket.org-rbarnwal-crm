using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Security.Claims;
using TravelCRM.Controllers.Admin;
using TravelCRM.Areas.Employee;
using AutoMapper;

namespace TravelCRM.ApplicationCore
{
    public class BaseController<T> : Controller where T : class
    {
       

        public BaseController(ILogger<T> logger)
        {

        }

        public BaseController()
        {
        }

        protected RedirectToActionResult RedirectToLandingPage(string returnUrl=null)
        {

            string Role = GetLoggedInUserRole();

            if(Role == "Admin")
                return RedirectToAction(nameof(AdminController.DasBoard), "Admin", new { area = "Admin" });

            if (Role == "Employee")
                return RedirectToAction(nameof(EmployeeController.DashBoard), "Employee", new { area = "Employee" });


            return RedirectToAction("", "Home");

        }


        protected string GetLoggedInUserID()
        {
            string UserId = string.Empty;
            if (User.Identity.IsAuthenticated)
                UserId = User.Identity.Name;


            return UserId;

        }


        protected string GetLoggedInUserRole()
        {

            return User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value;

            //string Role = string.Empty;

            //if (User.Identity.IsAuthenticated)
            //{
            //    IEnumerable<Claim> claim = User.Claims;

            //    foreach (Claim c in claim)
            //    {
            //        if (c.Type == ClaimTypes.Role)
            //        {

            //            Role = c.Value;
            //            break;
            //        }

            //    }
            //}

            //return Role;
        }
    }
}