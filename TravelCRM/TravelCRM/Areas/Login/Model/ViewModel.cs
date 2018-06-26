using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelCRMEntities;

namespace TravelCRM.Areas.Login.Model
{
    public class UserViewModel
    {
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailID { get; set; }
        public int MobileNUmber { get; set; }

        public DateTime DOB { get; set; }
        
        //public Role Role { get; set; }
    }



}
