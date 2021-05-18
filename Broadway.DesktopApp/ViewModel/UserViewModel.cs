using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Broadway.DesktopApp.ViewModel
{
    public class UserViewModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }

    public class ForgetUserPasswordViewModel
    {
        public string Username { get; set; }
    }
}
