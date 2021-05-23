using School.Managment.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Managment.ViewModels
{
    public class StudentUserViewModel
    {
        public Guid StudentId { get; set; }
        public Guid UserId { get; set; }

        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public Gender Gender { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Email { get; set; }
    }

    public class StudentUserResponseViewModel : ResponseViewModel
    {
        public Guid UserId { get; set; }
        public Guid StudentId { get; set; }
    }
}
