using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using TravelCRMEntities;
using TravelCRMRepo;

namespace TravelCRMServices
{
    public class AuthService : IAuthService
    {
        private IUnitOfWork unitOfWork;

        public AuthService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;

        }

        //Poor Implementation Should be removed but poor time poor implementation
        private string GetPermissionDetails(int RoleID, string ControllerName, string ActionName)
        {


            var entity = unitOfWork.PermissionRepository.GetAll();
            string permission = string.Empty;


            foreach (PermissionDetails per in entity)
            {
                 if(per.ControllerName == ControllerName && per.ActionName == ActionName && per.RoleID ==RoleID)
                {
                    permission = per.PermissionSet;

                }

            }




            return permission;
        }

        public bool HasPermission(int RoleID, string ControllerName, string ActionName,string Method)
        {
            if(Method == "Get")
            {
                Method = "ReadOnly";
            }
            else if (Method == "Post")
            {
                Method = "ReadWrite";

            }
          
            string Result = GetPermissionDetails(RoleID, ControllerName, ActionName);

            if (Result == Method)
                return true;
            else
                return false;

        }

        PermissionDetails IAuthService.GetPermissionDetails(int RoleID, string ControllerName, string ActionName)
        {
            throw new NotImplementedException();
        }
        //Code Quality Issue Will fixed Later on
        public Dictionary<string, List<string>> GetAllowedControllerActionForRole(int Role)
        {
            IEnumerable<PermissionDetails> resultset= unitOfWork.PermissionRepository.GetManyUsingFunc(r => r.RoleID == Role);
            Dictionary<string, List<string>> keyValue = new Dictionary<string, List<string>>();

            keyValue.Add("ab", new List<string>());

            foreach(PermissionDetails per in resultset)
            {
                if(!keyValue.ContainsKey(per.ControllerName))
                {
                  keyValue.Add(per.ControllerName, GetActionName(per.ControllerName, resultset));
                }
                
            }

            return null;
        }

       
        private List<string> GetActionName(string ControllerName,IEnumerable<PermissionDetails> details)
        {
            List<string> list = new List<string>();

            foreach(PermissionDetails pers in details)
            {
                if(pers.ControllerName == ControllerName)
                {
                    list.Add(pers.ActionName);
                }
            }
            return list;
        }
        
        //This should be removed


    }
}
