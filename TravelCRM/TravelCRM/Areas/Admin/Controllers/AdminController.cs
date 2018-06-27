using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TravelCRM.ApplicationCore;
using TravelCRMServices;
using TravelCRMEntities;
using Microsoft.Extensions.Logging;
using AutoMapper;

namespace TravelCRM.Controllers.Admin
{
    [Area("Admin")]
    [TravelCRMAuthorize]
    public class AdminController : BaseController<AdminController>
    {
        private IAdminOperationService m_adminOperationService { get; set; }
        private ILeadService m_leadService { get; set; }

        private ITeam m_teamService { get; set; }
        private readonly IMapper _mapper;

        private readonly ILogger<AdminController> _logger;

        public AdminController(IAdminOperationService adminService,
            ILeadService leadservice,
            ITeam teamservice,
            IMapper mapper,
            ILogger<AdminController> logger) :base()
        {
            this.m_adminOperationService = adminService;
            this._logger = logger;
            this.m_leadService = leadservice;
            this.m_teamService = teamservice;
            this._mapper = mapper;
            
        }



       
        public IActionResult DasBoard()
        {
            return View();
        }
        [TravelCRMAuth(PermissionItem.Admin, PermissionAction.ReadWrite)]
        public IActionResult Leads()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AssignLeadToTeamManager(Lead lead)
        {
            return View();
        }

        [HttpPost]
        public IActionResult AssignLeadToTeamMember(Lead lead)
        {
            return View();
        }
    }
}