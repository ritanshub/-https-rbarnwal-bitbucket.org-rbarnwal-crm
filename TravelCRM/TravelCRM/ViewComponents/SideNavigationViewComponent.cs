using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelCRM.Models;

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
            List<MenuViewModel> menuViewModel = new List<MenuViewModel>();

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

            return menuViewModel;

        }


    }
}
