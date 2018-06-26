using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TravelCRM.ApplicationCore;
using TravelCRM.Models.AccountViewModel;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using TravelCRMServices;
using TravelCRMEntities;
using Microsoft.Extensions.Logging;
using TravelCRM.Areas.Login.Model;
using System.Collections.Generic;
using System;

namespace TravelCRM.Controllers.Login
{
    [Area("Login")]
    public class AccountController : BaseController<AccountController>
    {
        private ILoginService m_loginService { get; set; }
        private readonly ILogger<AccountController> m_logger;

        public AccountController(ILoginService loginservice, ILogger<AccountController> logger) : base()
        {

            this.m_loginService = loginservice;
            this.m_logger = logger;

        }



        public IActionResult Login(string returnUrl = null)
        {
            TempData["returnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel user, string returnUrl = null)
        {
            const string badUserNameOrPasswordMessage = "Username or password is incorrect.";

            if (user == null)
            {
                return BadRequest(badUserNameOrPasswordMessage);
            }


            var Result = m_loginService.LoginUser(new ApplicationUser { UserName = user.UserID, Password = user.Password });


            if (Result.Result)
            {

                var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
                identity.AddClaim(new Claim(ClaimTypes.Name, ""));
                identity.AddClaim(new Claim(ClaimTypes.Role, m_loginService.GetRole(user.UserID)));
                identity.AddClaim(new Claim("RoleID", Result.AppUser.RoleID.ToString()));

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));
                return RedirectToLandingPage(returnUrl);
            }
            

            if(!Result.Result)
            {

                return BadRequest(badUserNameOrPasswordMessage);
            }

          

            if(returnUrl != null)
            {
                return Redirect(returnUrl);
            }


            // If we got this far, something failed, redisplay form
            return View(user);
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction(nameof(AccountController.Login), "Account", new { area = "Login" });
        }

        List<UserViewModel> _user = new List<UserViewModel> {
               new UserViewModel { EmployeeID = 1, FirstName = "Ankur", LastName = "barnwal",EmailID="ashishbzz05@gmail.com",MobileNUmber=34,Active=1,DOB=DateTime.Now,RoleID=1},
                     new UserViewModel { EmployeeID = 2, FirstName = "Ashish", LastName = "barnwal", EmailID = "ashishbzz05@gmail.com", MobileNUmber = 34,Active=1,DOB=DateTime.Now,RoleID=1},
               new UserViewModel { EmployeeID = 3, FirstName = "Rajesh", LastName = "barnwal", EmailID = "ashishbzz05@gmail.com", MobileNUmber =43,Active=1,DOB=DateTime.Now,RoleID=1},
               new UserViewModel { EmployeeID = 4, FirstName = "Tanya", LastName = "barnwal", EmailID = "ashishbzz05@gmail.com", MobileNUmber = 43,Active=1,DOB=DateTime.Now,RoleID=1},
               new UserViewModel { EmployeeID = 5, FirstName = "Akash", LastName = "barnwal", EmailID = "ashishbzz05@gmail.com", MobileNUmber = 5,Active=1,DOB=DateTime.Now,RoleID=1},
               new UserViewModel { EmployeeID = 6, FirstName = "Golu", LastName = "barnwal", EmailID = "ashishbzz05@gmail.com",MobileNUmber = 4,Active=1,DOB=DateTime.Now,RoleID=1},
               new UserViewModel { EmployeeID = 7, FirstName = "Ramesh", LastName = "barnwal", EmailID = "ashishbzz05@gmail.com",MobileNUmber =6,Active=1,DOB=DateTime.Now,RoleID=1}
        };

        public IActionResult GetUserProfile(int empid)
        {
           
            return View("Profile");
        }
    }
}