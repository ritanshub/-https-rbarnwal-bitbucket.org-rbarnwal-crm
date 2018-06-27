using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace MenuManager
{
    [XmlRoot("Menus")]
    public class Menus : List<Menu>
    {

    }
}
