using School.Managment.Data;
using School.Managment.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Managment.Services
{
    public static class LoginService
    {
        private static SchoolContext db = new SchoolContext();

        public static LoginResponseViewModel Login(LoginRequestViewModel model)
        {
            var result = new LoginResponseViewModel();
            try
            {
                var existingUser = db.User.FirstOrDefault(p => p.Username == model.UserName);
                if (existingUser==null)
                {
                    result.Message = "Username not found";
                    return result;
                }

                if (model.HashedPassword==existingUser.HashedPassword)
                {
                    result.Status = true;
                    result.Userid = existingUser.Id;
                    result.UserType = existingUser.UserType;
                    result.Message = "All Good";
                }
                else
                {
                    result.Message = "Password not matched";
                }

            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                return result;
            }
            return result;
        }
    }
}
