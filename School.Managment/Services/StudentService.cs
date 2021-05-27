using School.Managment.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Managment.Services
{
    public static class StudentService
    {
        private static SchoolContext db = new SchoolContext();

        public static List<ViewModels.Admin.StudentDashboardViewModel> GetAllStudents()
        {
            var data = db.Students.ToList().Select(p => new ViewModels.Admin.StudentDashboardViewModel()
            {
                //StudentId = p.Id,
                StudentFullName = string.IsNullOrWhiteSpace(p.MName) ? $"{p.FName} {p.LName}" : $"{p.FName} {p.MName} {p.LName}",
                Address = p.Address,
                Email=p.User.Email,
                Username=p.User.Username
            }) ;

            //var userdata = db.User.ToList().Select(p => new ViewModels.Admin.StudentDashboardViewModel()
            //{
            //    Email = p.Email,
            //    Username = p.Username
            //}) ;

            return data.ToList();
            
        }
    }
}
