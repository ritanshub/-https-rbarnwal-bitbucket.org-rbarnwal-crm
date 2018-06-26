﻿using System;
using System.Collections.Generic;
using System.Text;
using TravelCRMEntities;
using TravelCRMRepo;

namespace TravelCRMServices
{
    public class EmployeeService : IEmployeeOperationService
    {
       
        private IUnitOfWork unitOfWork;

        public EmployeeService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;

        }

        public LeadEmployeeMapper AssignLeadToEmployee(int LeadID,int ManagerID,int employeeID)
        {

            var mapper = new LeadEmployeeMapper() { LeadID = LeadID, EmployeeID = employeeID ,Level = 2};
            var entity =  unitOfWork.LeadEmployeeMapperRepository.Add(mapper);
            unitOfWork.Commit();
            return entity;
        }

        
    }
}
