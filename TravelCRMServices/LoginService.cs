using TravelCRMEntities;
using TravelCRMRepo;

namespace TravelCRMServices
{
    public class LoginService : ILoginService
    {

        private IUnitOfWork unitOfWork;

        public LoginService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;

        }

        //Needs to be modified later on with Hashing and other checks
        public SingnInResult LoginUser(ApplicationUser User)
        {
            var Result = unitOfWork.LoginRepository.GetById(User.UserName);

            SingnInResult signinresult = new SingnInResult();
            signinresult.Result = false;

            if (Result!= null &&
                Result.UserName == User.UserName 
                && Result.Password == User.Password)
            {
 
                signinresult.Result = true;
                signinresult.AppUser = Result;
               
            }
               return signinresult;
        }




        public string GetRole(string UserID)
        {

            return string.Empty;
        }

        public ApplicationUser CreateAppUser(ApplicationUser user)
        {
            ApplicationUser LocalAppuser = null;

            if (user != null)
            {

                LocalAppuser= unitOfWork.LoginRepository.Add(user);
            }

            return LocalAppuser;
        }
    }
}
