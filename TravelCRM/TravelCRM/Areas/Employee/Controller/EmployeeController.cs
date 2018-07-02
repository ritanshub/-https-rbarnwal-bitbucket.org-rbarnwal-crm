using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TravelCRM.ApplicationCore;
using Microsoft.Extensions.Logging;
using AutoMapper;
using TravelCRM.Areas.Employee.Model;
using TravelCRM.Areas.Login.Model;

namespace TravelCRM.Areas.Employee
{
    [Area("Employee")]
    //[TravelCRMAuthorize]
    public class EmployeeController : BaseController<EmployeeController>
    {
        private readonly IMapper _mapper;

        private readonly ILogger<EmployeeController> m_logger;

        public EmployeeController(ILogger<EmployeeController> logger,
            IMapper mapper) :base()
        {

            this.m_logger = logger;
            this._mapper = mapper;
        }

        public IActionResult DashBoard()
        {
            return View();
        }

        public IActionResult Index()
        {
            List<LeadViewModel> model = new List<LeadViewModel>
                {
                new LeadViewModel{Budget=123,JourneyDestination="dest",JourneySource="source",LeadSource="lSource",LeadStatus="start",ModeOfTravel="train",StayPeriod="3",EditAction=new Models.GridAction{ActionText="Edit",Action_Action="AssignLeads",Action_Controller="Employee",Action_Area="Employee",Action_ID="1" } },
                new LeadViewModel{Budget=123,JourneyDestination="dest",JourneySource="source",LeadSource="lSource",LeadStatus="start",ModeOfTravel="train",StayPeriod="3",EditAction=new Models.GridAction{ActionText="Edit",Action_Action="",Action_Controller="",Action_Area="",Action_ID="" } },
                new LeadViewModel{Budget=123,JourneyDestination="dest",JourneySource="source",LeadSource="lSource",LeadStatus="start",ModeOfTravel="train",StayPeriod="3" ,EditAction=new Models.GridAction{ActionText="Edit",Action_Action="",Action_Controller="",Action_Area="",Action_ID="" } },
                new LeadViewModel{Budget=123,JourneyDestination="dest",JourneySource="source",LeadSource="lSource",LeadStatus="start",ModeOfTravel="train",StayPeriod="3" ,EditAction=new Models.GridAction{ActionText="Edit",Action_Action="",Action_Controller="",Action_Area="",Action_ID="" } },
                new LeadViewModel{Budget=123,JourneyDestination="dest",JourneySource="source",LeadSource="lSource",LeadStatus="start",ModeOfTravel="train",StayPeriod="3" ,EditAction=new Models.GridAction{ActionText="Edit",Action_Action="",Action_Controller="",Action_Area="",Action_ID="" } }
            }
            ;

            return View(model);
        }

        public IActionResult GetUserProfile(int customerid)
        {
            UserViewModel notifimodel = new UserViewModel { EmployeeID = 123, FirstName = "dest", LastName = "source", DOB =DateTime.Now, EmailID = "start@gmail.com", ManagerName = "svgcdhvshv", MobileNUmber = 12131232 };

            return View("Profile", notifimodel);
        }

        public IActionResult GetHelp()
        {
            return View("Help");
        }

        public IActionResult AssignLeads(int customerid)
        {
           
            UserViewModel notifimodel = new UserViewModel { EmployeeID = 123, FirstName = "dest", LastName = "source", DOB = DateTime.Now, EmailID = "start@gmail.com", ManagerName = "svgcdhvshv", MobileNUmber = 12131232 };
           

            return PartialView("ModalTag", notifimodel);
        }

    }
}