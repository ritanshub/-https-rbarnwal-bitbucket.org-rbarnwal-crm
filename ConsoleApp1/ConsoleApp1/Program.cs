using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            MenuManager manager = new MenuManager();
            Menus m =  manager.ReadMenuXML("Menu.xml");
            Menus parentmenu = manager.ParseParentMenu(m);
            List<Menu> FinalList = manager.ParseChildMenu(parentmenu, m);
            
            
            
            //manager.writeXML();
            Console.ReadLine();
        }
    }




    
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
            public string Controller{ get; set; }
            public string Action { get; set; }

        public List<Menu> Menus { get; set; }
    }

    [XmlRoot("Menus")]
    public class Menus :List<Menu>
    {

    }

    

    public class MenuManager
    {
        public MenuManager()
        {
           
        }


        public void writeXML()
        {

            XmlSerializer serializer = new XmlSerializer(typeof(Menus));
            Menus m = new Menus();
            m.Add(new Menu { MenuID = 1, DisplayName = "Sex", Action = "", Controller = "", ParentID = 0 });
            m.Add(new Menu { MenuID = 2, DisplayName = "NoSex", Action = "a", Controller = "c", ParentID = 0 });

            using (TextWriter writer = new StreamWriter(@"C:\XmlA.xml"))
            {
                serializer.Serialize(writer, m);
            }
        }

        public List<Menu> Load(string location)
        {


            return null;
        }

        public List<Menu> Load(string location, string Role)
        {


            return null;
        }


        public Menus ReadMenuXML(string FileName)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Menus));

            // A FileStream is needed to read the XML document.
            FileStream fs = new System.IO.FileStream(FileName, FileMode.Open);
            // Declare an object variable of the type to be deserialized.
            Menus MenuList;
            /* Use the Deserialize method to restore the object's state with
            data from the XML document. */
            MenuList = (Menus)serializer.Deserialize(fs);


            return MenuList;
        }


        public Menus ParseParentMenu(Menus MenuList)
        {

            Menus FilteredMenuList = new Menus();
            FilteredMenuList.AddRange(MenuList.FindAll(p => p.ParentID == 0));

            //foreach(Menu menu in FilteredMenuList)
            //{
            //    int id = menu.MenuID;
            //    menu.Menus.AddRange(MenuList.FindAll(p => p.ParentID == id));

            //}


            return FilteredMenuList;
        }

        public List<Menu> ParseChildMenu(List<Menu> ParentMenuList,Menus MenuList)
        {


            foreach (Menu menu in ParentMenuList)
            {
                menu.Menus.AddRange(MenuList.FindAll(p => p.ParentID == menu.MenuID));

                if(menu.Menus.Count > 0)
                {
                    ParseChildMenu(menu.Menus, MenuList);
                }
               

            }

            return ParentMenuList;
        }


        public void LoadMenuXML()
        {

            //Server.MapPath("/Xml/Menus.xml")

            Menu entity = new Menu();

            //entity.Title = "Home";
            //entity.Action = "/Home/Home";
            //Menus.Add(entity);

            //entity = new Menu();
            //entity.Title = "Maintenance";
            //entity.Action = "/Maintenance/Maintenance";
            //Menus.Add(entity);

            //entity = new Menu();
            //entity.Title = "Reports";
            //entity.Action = "/Reports/Reports";
            //Menus.Add(entity);

            //entity = new Menu();
            //entity.Title = "Lookup";
            //entity.Action = "/Lookup/Lookup";
            //Menus.Add(entity);
        }
    }

}
