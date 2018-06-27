using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TravelCRM.ApplicationCore;
using Microsoft.Extensions.Logging;
using AutoMapper;

namespace TravelCRM.Areas.Employee
{
    [Area("Employee")]
    [TravelCRMAuthorize]
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

    }
}