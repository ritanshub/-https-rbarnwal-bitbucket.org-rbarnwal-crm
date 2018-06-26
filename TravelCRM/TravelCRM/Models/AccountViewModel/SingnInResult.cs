using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelCRMEntities;

namespace TravelCRM.Models.AccountViewModel
{
    public class SingnInResult
    {

        public bool Result { get; set; }
        public ApplicationUser AppUser { get; set; }
    }
}
