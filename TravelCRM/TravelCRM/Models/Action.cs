using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelCRM.Models
{
    public class GridAction
    {
        public GridAction()
        {

        }
        public GridAction(string text,string action,string controller,string area,object id)
        {
            ActionText = text;
            Action_Action = action;
            Action_Controller = controller;
            Action_Area = area;
            Action_ID = id;
        }

        public string ActionText { get; set; }

        public string Action_Action { get; set; }
        public string Action_Controller { get; set; }
        public string Action_Area { get; set; }

        public object Action_ID { get; set; }
    }
}
