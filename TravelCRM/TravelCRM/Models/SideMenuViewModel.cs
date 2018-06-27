using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelCRM.Models
{
    //public class MenuViewModel
    //{
    //    public int MenuID { get; set; }
    //    public string Title { get; set; }
    //    public string Action { get; set; }
    //    public string Controller { get; set; }
    //    public bool IsAction { get; set; }
    //    public string Link { get; set; }
    //    public string Class { get; set; }
    //    public List<MenuViewModel> SubMenu { get; set; }

    //}

    public class MenuViewModel
    {
        public MenuViewModel()
        {
            ParentID = 0;
            Menus = new List<MenuViewModel>();
        }

        public int MenuID { get; set; }
        public int ParentID { get; set; }

        public string DisplayName { get; set; }
        public string ActionURL { get; set; }
        public string AllowedRole { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }

        public List<MenuViewModel> Menus { get; set; }
    }
}
