using School.Managment.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Managment.ViewModels
{
    public class LoginRequestViewModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string HashedPassword
        {
            get
            {
                return Md5Hash.Create(Password);
            }
        }
    }
}
