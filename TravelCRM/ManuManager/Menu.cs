using System;
using System.Collections.Generic;
using System.Text;

namespace MenuManager
{
    public class Menu
    {
        public Menu()
        {
            ParentID = 0;
            Menus = new List<Menu>();
        }

        public int MenuID { get; set; }
        public int ParentID { get; set; }

        public string DisplayName { get; set; }
        public string ActionURL { get; set; }
        public string AllowedRole { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }

        public List<Menu> Menus { get; set; }
    }
}
