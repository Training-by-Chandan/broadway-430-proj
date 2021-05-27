using School.Managment.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Managment.ViewModels
{
    public class ResponseViewModel
    {
        public bool Status { get; set; } = false;
        public string Message { get; set; }
    }

    public class LoginResponseViewModel : ResponseViewModel
    {
        public UserType UserType { get; set; }
        public Guid Userid { get; set; }
    }
}
