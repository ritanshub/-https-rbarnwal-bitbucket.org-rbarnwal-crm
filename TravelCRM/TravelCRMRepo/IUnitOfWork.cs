using System;
using System.Collections.Generic;
using System.Text;
using TravelCRMEntities;

namespace TravelCRMRepo
{
   public interface IUnitOfWork
    {
        void Commit();
        IRepository<Lead> LeadRepository { get; }
        IRepository<Team> TeamRepository { get; }
        IRepository<Employee> EmployeeRepository { get; }
        IRepository<LeadEmployeeMapper> LeadEmployeeMapperRepository { get; }
        IRepository<PermissionDetails> PermissionRepository { get; }
        IRepository<ApplicationUser> LoginRepository { get; }
    }
}
