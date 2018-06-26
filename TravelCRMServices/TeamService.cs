using System;
using System.Collections.Generic;
using System.Text;
using TravelCRMEntities;
using TravelCRMRepo;

namespace TravelCRMServices
{

    public class TeamService : ITeam
    {
       


        private IUnitOfWork unitOfWork;

        public TeamService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;

        }

        public IEnumerable<Team> GetTeam()
        {
            return unitOfWork.TeamRepository.GetAll();  
        }
    }
}
