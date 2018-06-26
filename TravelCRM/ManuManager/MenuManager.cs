using System;
using System.Collections.Generic;

namespace TravelCRM.MenuManager
{
   

    public class ManuManager
    {
        public ManuManager()
        {
            MenusList = new List<TravelCRMMenuItem>();
        }

        public List<TravelCRMMenuItem> MenusList { get; set; }


        public List<TravelCRMMenuItem> Load(string location)
        {


            return null;
        }



        public TravelCRMMenuItemList ReadMenuXML()
        {



            return null;
        }

        public void LoadMenuXML()
        {

            //Server.MapPath("/Xml/Menus.xml")

            TravelCRMMenuItem entity = new TravelCRMMenuItem();

            entity.Title = "Home";
            entity.Action = "/Home/Home";
            Menus.Add(entity);

            entity = new TravelCRMMenuItem();
            entity.Title = "Maintenance";
            entity.Action = "/Maintenance/Maintenance";
            Menus.Add(entity);

            entity = new TravelCRMMenuItem();
            entity.Title = "Reports";
            entity.Action = "/Reports/Reports";
            Menus.Add(entity);

            entity = new TravelCRMMenuItem();
            entity.Title = "Lookup";
            entity.Action = "/Lookup/Lookup";
            Menus.Add(entity);
        }
    }

}
