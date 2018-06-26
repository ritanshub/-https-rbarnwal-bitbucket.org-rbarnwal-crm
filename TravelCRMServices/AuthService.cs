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

        //This should be removed


    }
}
