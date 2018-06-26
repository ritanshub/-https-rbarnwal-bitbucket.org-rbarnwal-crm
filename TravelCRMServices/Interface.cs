using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TravelCRMEntities;

namespace TravelCRMServices
{
    public interface IAdminOperationService
    {
        LeadEmployeeMapper AssignLeadToManager(int LeadID, int ManagerID, int employeeID);

    }

    public interface ITeam
    {

        IEnumerable<Team> GetTeam();

    }


    public interface ISalesOperation
    {
           
    }



    public interface ILeadService
    {
        IEnumerable<Lead> GetLeads();
        Lead GetLeadByID(int ID);
        IEnumerable<Lead> GetMany(System.Linq.Expressions.Expression<Func<Lead, bool>> where);
        void AssignLead(Lead lead);
        void SaveLead(Lead Lead);

    }


   public interface ILoginService
    {

        SingnInResult LoginUser(ApplicationUser User);
        string GetRole(string UserID);
    }

   public interface IEmailSender
        {
            Task SendEmailAsync(string email, string subject, string message);
        }


    public interface IEmployeeOperationService
    {
        LeadEmployeeMapper AssignLeadToEmployee(int LeadID,int ManagerID, int employeeID);

    }

    public interface IAuthService
    {
        PermissionDetails GetPermissionDetails(int RoleID, string ControllerName, string ActionName);

       bool HasPermission(int RoleID, string ControllerName, string ActionName,string Method);


    }

}
