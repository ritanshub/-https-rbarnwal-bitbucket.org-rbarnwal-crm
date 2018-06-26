using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TravelCRM.Models;
using System.Collections;

namespace TravelCRM.Controllers
{
    public class NavigationController : Controller
    {
        public IActionResult Menu()
        {
            List< MenuViewModel> menuViewModel = new List<MenuViewModel>();

            MenuViewModel menu = new MenuViewModel() { MenuID = 1, Action = "Index", Controller = "Dashboard", IsAction = true, Class = "class", SubMenu = null, Title = "Dashboard" };
            menuViewModel.Add(menu);

            menu = new MenuViewModel() { MenuID = 2, IsAction = false, Class = "class", Link = "javascript:void(0);", Title = "Application Setup" };

            menu.SubMenu = new List<MenuViewModel>();
            MenuViewModel subMenu = new MenuViewModel() { Action = "Register", Controller = "Account", IsAction = true, Class = "", SubMenu = null, Title = "User Manager" };
            menu.SubMenu.Add(subMenu);

            subMenu = new MenuViewModel() { Action = "Index", Controller = "Manage", IsAction = true, Class = "", SubMenu = null, Title = "Manage" };
            menu.SubMenu.Add(subMenu);

            subMenu = new MenuViewModel() { Action = "ChangePassword", Controller = "Manage", IsAction = true, Class = "", SubMenu = null, Title = "Change Password" };
            menu.SubMenu.Add(subMenu);

            subMenu = new MenuViewModel() { IsAction = false, Link = "javascript:document.getElementById('logoutForm').submit()", Class = "", SubMenu = null, Title = "Logoff" };
            menu.SubMenu.Add(subMenu);

            menuViewModel.Add(menu);

            return PartialView("_ThemeMenuPartial", menuViewModel);

        }
    }
}