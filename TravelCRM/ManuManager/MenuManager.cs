using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using System.Linq;

namespace MenuManager
{
    public class MenuManager
    {
        public MenuManager()
        {

        }


        

        public List<Menu> Load(string location)
        {
            Menus FullMenuList = ReadMenuXML("Menu.xml");
            Menus parentmenu = ParseParentMenu(FullMenuList);
            List<Menu> FinalList = ParseChildMenu(parentmenu, FullMenuList);

            return FinalList;
        }

        public List<Menu> LoadRoleBaseMenu(string location,string Role)
        {
            Menus FullMenuList = ReadMenuXML("Menu.xml");
            Menus parentmenu = ParseParentMenu(FullMenuList);
            List<Menu> FinalList = ParseChildMenu(parentmenu, FullMenuList);
            List<Menu> AuthMenuList = FilterMenuOnRole(FinalList,Role);
            return AuthMenuList;
        }

        public List<Menu> Load(string location, string Role)
        {


            return null;
        }

        


        private Menus ReadMenuXML(string FileName)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Menus));

            // A FileStream is needed to read the XML document.
            FileStream fs = new System.IO.FileStream(FileName, FileMode.Open);
           
            Menus MenuList;
            /* Use the Deserialize method to restore the object's state with
            data from the XML document. */
            return MenuList = (Menus)serializer.Deserialize(fs);

        }


        private Menus ParseParentMenu(Menus MenuList)
        {

            Menus FilteredMenuList = new Menus();
            FilteredMenuList.AddRange(MenuList.FindAll(p => p.ParentID == 0));
            return FilteredMenuList;
        }
        private List<Menu> ParseChildMenu(List<Menu> ParentMenuList, Menus MenuList)
        {


            foreach (Menu menu in ParentMenuList)
            {
                menu.Menus.AddRange(MenuList.FindAll(p => p.ParentID == menu.MenuID));

                if (menu.Menus.Count > 0)
                {
                    ParseChildMenu(menu.Menus, MenuList);
                }


            }

            return ParentMenuList;
        }

        private List<Menu> FilterMenuOnRole(List<Menu> MenuList,string Role)
        {
            List<Menu> AuthMenuList = new List<Menu>();
            foreach(Menu menu in MenuList)
            {
                if (menu.AllowedRole == "All")

                {
                    AuthMenuList.Add(menu);

                }  
                else if(menu.AllowedRole.Split(new char[] { ',' }).Contains<string>(Role))
                {
                    AuthMenuList.Add(menu);

                }

                FilterMenuOnRole(menu.Menus, Role);

            }
            return AuthMenuList;

        }
       
    }
}
