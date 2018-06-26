using System;
using System.Collections.Generic;
using System.Text;
using TravelCRMData;
using TravelCRMEntities;

namespace TravelCRMRepo
{
    public class UnitOfWork : IUnitOfWork
    {
        private IRepository<Team> _TeamRepository;
        private IRepository<Employee> _EmployeeRepository;
        private IRepository<LeadEmployeeMapper> _LeadEmployeeMapperRepository;

        private IRepository<Lead> _LeadRepository;
        private IRepository<PermissionDetails> _PermissionRepository;
        private IRepository<ApplicationUser> _LoginRepository;

        public UnitOfWork(ApplicationContext context)
        {
            Context = context;
        }

        public ApplicationContext Context { get; }

        public IRepository<Lead> leadRepository => throw new NotImplementedException();

        public IRepository<LeadEmployeeMapper> LeadEmployeeMapperRepository
        {
            get
            {
                return _LeadEmployeeMapperRepository = LeadEmployeeMapperRepository ?? new Repository<LeadEmployeeMapper>(Context);
            }

        }

        public IRepository<ApplicationUser> LoginRepository
        {
            get
            {
                return _LoginRepository = _LoginRepository ?? new Repository<ApplicationUser>(Context);
            }
        }

        IRepository<Team> IUnitOfWork.TeamRepository
        {
            get
            {
                return _TeamRepository = _TeamRepository ?? new Repository<Team>(Context);
            }
        }
    
        IRepository<Lead> IUnitOfWork.LeadRepository
        {
            get
            {
                return _LeadRepository = _LeadRepository ?? new Repository<Lead>(Context);
            }
        }

        IRepository<Employee> IUnitOfWork.EmployeeRepository
        {
            get
            {
                return _EmployeeRepository = _EmployeeRepository ?? new Repository<Employee>(Context);
              
            }
        }



        IRepository<PermissionDetails> IUnitOfWork.PermissionRepository
        {
            get
            {
                return _PermissionRepository = _PermissionRepository ?? new Repository<PermissionDetails>(Context);

            }
        }


        void IUnitOfWork.Commit()
        {
            Context.SaveChanges();
        }
    }
}
