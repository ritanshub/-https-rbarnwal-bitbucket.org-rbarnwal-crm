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
using AutoMapper;
using TravelCRM.Models;
using System.Collections.Generic;

namespace TravelCRM.Controllers.Login
{
    [Area("Login")]
    public class AccountController : BaseController<AccountController>
    {

        // _mapper.Map<TypeIWantToMapTo>(originalObject);

        private ILoginService m_loginService { get; set; }
        private readonly ILogger<AccountController> m_logger;
        private readonly IMapper _mapper;

        public AccountController(ILoginService loginservice, 
            ILogger<AccountController> logger,IMapper mapper) : base()
        {

            this.m_loginService = loginservice;
            this.m_logger = logger;
            this._mapper = mapper;
           
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

        public ActionResult GetUserProfile(string customerId)
        {
            List<UserNotification> lstnotifi = new List<UserNotification>();
            UserNotification notifimodel = new UserNotification { Title = "abc", Details = "Notification Accepted" };
            lstnotifi.Add(notifimodel);

            return PartialView("Details", lstnotifi);
        }
    }
}