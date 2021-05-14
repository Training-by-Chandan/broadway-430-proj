using Broadway.DesktopApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Broadway.DesktopApp.Services
{
    public class UserService
    {
        public static CodeFirst.CodeFirstContext db = new CodeFirst.CodeFirstContext();

        public static (bool,string) Login(UserLoginViewModel viewModel)
        {
            var existingUser = db.Users.FirstOrDefault(p => p.UserName == viewModel.UserName);
            if (existingUser==null)
            {
                return (false, "Username not found");
            }
            if (existingUser.Password==viewModel.Password)
            {
                return (true, "All good");
            }
            else
            {
                return (false, "Password doesnot match");
            }
        }

        public static (bool, string) ChangePassword(UserViewModel viewModel)
        {
            var existingUser = db.Users.FirstOrDefault(p => p.UserName == viewModel.UserName);
            if (existingUser == null)
            {
                return (false, "Username not found");
            }
            if (viewModel.Password!=viewModel.ConfirmPassword)
            {
                return (false, "Password doesnot match");
            }
            else
            {
                existingUser.Password = viewModel.Password;
                db.Entry(existingUser).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return (true, "All good");
            }

        }

        
    }
}
