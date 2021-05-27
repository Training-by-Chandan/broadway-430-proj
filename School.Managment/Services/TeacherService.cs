using School.Managment.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Managment.Services
{
    public static class TeacherService
    {
        private static SchoolContext db = new SchoolContext();

        public static List<ViewModels.Admin.TeacherDashboardViewModel> GetAllTeachers()
        {
            var data = db.Teachers.ToList().Select(p => new ViewModels.Admin.TeacherDashboardViewModel()
            {
                //TeacherId = p.Id,
                TeacherFullName = string.IsNullOrWhiteSpace(p.MName) ? $"{p.FName} {p.LName}" : $"{p.FName} {p.MName} {p.LName}",
                Address = p.Address

            }); ;

            return data.ToList();
        }

        public static Teacher GetTeacherByUserId(Guid id)
        {
            return db.Teachers.FirstOrDefault(p => p.UserId == id);
        }
    }
}
