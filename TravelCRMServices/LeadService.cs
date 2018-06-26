using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using TravelCRMEntities;
using TravelCRMRepo;

namespace TravelCRMServices
{
    public class LeadService : ILeadService
    {
        private IUnitOfWork unitOfWork;

        public LeadService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;

        }

        public void AssignLead(Lead lead)
        {
            unitOfWork.LeadRepository.Update(lead,lead.LeadID);
            unitOfWork.Commit();
        }

        public Lead GetLeadByID(int ID)
        {
           return unitOfWork.LeadRepository.GetById(ID);
        }

        public IEnumerable<Lead> GetLeads()
        {
            return unitOfWork.LeadRepository.GetAll();
        }

        public IEnumerable<Lead> GetMany(Expression<Func<Lead, bool>> where)
        {
           return unitOfWork.LeadRepository.GetMany(where);
        }

        public void SaveLead(Lead Lead)
        {
            throw new NotImplementedException();
        }
    }
}
