using MenuManager;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelCRM.Models;
using TravelCRMServices;
using Microsoft.Extensions.DependencyInjection;
using static Microsoft.AspNetCore.Hosting.Internal.HostingApplication;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using AutoMapper;

namespace TravelCRM.ViewComponents
{
    public class SideNavigation: Microsoft.AspNetCore.Mvc.ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            

            return View("SideNavigation", await GetMenuAsync());
        }


        private async Task<List<MenuViewModel>> GetMenuAsync()
        {

            List<Menu> Menulist = GetMenuListForLoggedInUser();
            
            List<MenuViewModel> menuViewModel = new List<MenuViewModel>();


            var mapper = HttpContext.RequestServices.GetService<IMapper>();


            menuViewModel = mapper.Map<List<MenuViewModel>>(Menulist);

            //MenuViewModel menu = new MenuViewModel() { MenuID = 1, Action = "Index", Controller = "Dashboard", IsAction = true, Class = "class", SubMenu = null, Title = "Dashboard" };
            //menuViewModel.Add(menu);

            //menu = new MenuViewModel() { MenuID = 2, IsAction = false, Class = "class", Link = "javascript:void(0);", Title = "Application Setup" };

            //menu.SubMenu = new List<MenuViewModel>();
            //MenuViewModel subMenu = new MenuViewModel() { Action = "Register", Controller = "Account", IsAction = true, Class = "", SubMenu = null, Title = "User Manager" };
            //menu.SubMenu.Add(subMenu);

            //subMenu = new MenuViewModel() { Action = "Index", Controller = "Manage", IsAction = true, Class = "", SubMenu = null, Title = "Manage" };
            //menu.SubMenu.Add(subMenu);

            //subMenu = new MenuViewModel() { Action = "ChangePassword", Controller = "Manage", IsAction = true, Class = "", SubMenu = null, Title = "Change Password" };
            //menu.SubMenu.Add(subMenu);

            //subMenu = new MenuViewModel() { IsAction = false, Link = "javascript:document.getElementById('logoutForm').submit()", Class = "", SubMenu = null, Title = "Logoff" };
            //menu.SubMenu.Add(subMenu);

            //menuViewModel.Add(menu);

            return menuViewModel;

        }




        private List<Menu> GetMenuListForLoggedInUser()
        {
            MenuManager.MenuManager menuManager = new MenuManager.MenuManager();

            var AuthService = HttpContext.RequestServices.GetService<IAuthService>();

            var hostingEnvironment = HttpContext.RequestServices.GetService<IHostingEnvironment>();

            var MenuXmlPath = hostingEnvironment.ContentRootPath;
            MenuXmlPath = Path.Combine(MenuXmlPath, "MenuXml", "Menu");

            string RoleID = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "RoleID").Value;

            List<Menu> FullMenuList = menuManager.LoadRoleBaseMenu(MenuXmlPath, RoleID);
            

            return FullMenuList;

        }



        private List<Menus> GetMenuListForLoggedInUserNotUsed()
        {
            MenuManager.MenuManager menuManager = new MenuManager.MenuManager();

            var AuthService = HttpContext.RequestServices.GetService<IAuthService>();

            var hostingEnvironment = HttpContext.RequestServices.GetService<IHostingEnvironment>();

            var MenuXmlPath = hostingEnvironment.ContentRootPath;
            MenuXmlPath = Path.Combine(MenuXmlPath,"MenuXml", "Menu");

            List<Menu> FullMenuList = menuManager.Load(MenuXmlPath);
            //  RoleID
            string RoleID = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "RoleID").Value;
            var AllowedMenuList = AuthService.GetAllowedControllerActionForRole(int.Parse(RoleID));

            

            return null;

        }


        private List<Menu> FilterMenu(Dictionary<string,List<string>> details,List<Menu> menus)
        {


            return null;

        }


    }
}
