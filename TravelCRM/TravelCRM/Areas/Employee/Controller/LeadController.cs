using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TravelCRM.ApplicationCore;
using Microsoft.Extensions.Logging;
using TravelCRM.Areas.Employee.Model;

namespace TravelCRM.Areas.Employee
{
    [Area("Employee")]
    //[TravelCRMAuthorize]
    public class LeadController : BaseController<LeadController>
    {


        private readonly ILogger<LeadController> m_logger;

        public LeadController(ILogger<LeadController> logger) :base()
        {

            this.m_logger = logger;
        }

        public IActionResult DashBoard()
        {
            return View();
        }

        public IActionResult Index()
        {
            List<LeadViewModel> model = new List<LeadViewModel>
                {
                new LeadViewModel{Budget=123,JourneyDestination="dest",JourneySource="source",LeadSource="lSource",LeadStatus="start",ModeOfTravel="train",StayPeriod="3" },
                new LeadViewModel{Budget=123,JourneyDestination="dest",JourneySource="source",LeadSource="lSource",LeadStatus="start",ModeOfTravel="train",StayPeriod="3" },
                new LeadViewModel{Budget=123,JourneyDestination="dest",JourneySource="source",LeadSource="lSource",LeadStatus="start",ModeOfTravel="train",StayPeriod="3" },
                new LeadViewModel{Budget=123,JourneyDestination="dest",JourneySource="source",LeadSource="lSource",LeadStatus="start",ModeOfTravel="train",StayPeriod="3" },
                new LeadViewModel{Budget=123,JourneyDestination="dest",JourneySource="source",LeadSource="lSource",LeadStatus="start",ModeOfTravel="train",StayPeriod="3" }

            }
            ;

            return View(model);
        }

    }
}