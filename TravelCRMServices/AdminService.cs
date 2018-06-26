using System;
using System.Collections.Generic;
using System.Text;
using TravelCRMEntities;
using TravelCRMRepo;

namespace TravelCRMServices
{
    public class AdminService : IAdminOperationService
    {

        private IUnitOfWork unitOfWork;

        public AdminService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;

        }

        public LeadEmployeeMapper AssignLeadToManager(int LeadID, int ManagerID, int employeeID)
        {
           var mapper = new LeadEmployeeMapper() { LeadID = LeadID, EmployeeID = employeeID,Level=1 };
           var entity = unitOfWork.LeadEmployeeMapperRepository.Add(mapper);
            unitOfWork.Commit();
            return entity;
        }
    }
}
