using System;
using System.Collections.Generic;
using System.Text;

namespace TravelCRM.MenuManager
{
    public class TravelCRMMenuItem
    {
        public TravelCRMMenuItem()
        {
            ParentId = 0;
            Menus = new List<TravelCRMMenuItem>();
        }

        public int MenuId { get; set; }
        public int ParentId { get; set; }
        public string Title { get; set; }
        public int DisplayOrder { get; set; }
        public string Action { get; set; }
        public string AllowedRole { get; set; }

        public List<TravelCRMMenuItem> Menus { get; set; }
    }

}
