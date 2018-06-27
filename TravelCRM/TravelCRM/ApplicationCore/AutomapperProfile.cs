using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelCRM.Models.AccountViewModel;
using TravelCRMEntities;

namespace TravelCRM.ApplicationCore
{
    public class AutomapperProfile:Profile
    {
        public AutomapperProfile()
        {
            CreateMap<ApplicationUser, LoginViewModel>();

        }

    }
}
