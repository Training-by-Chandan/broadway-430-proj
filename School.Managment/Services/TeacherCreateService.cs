using School.Managment.Common;
using School.Managment.Data;
using School.Managment.ViewModels;
using School.Managment.ViewModels.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Managment.Services
{
    public static class TeacherCreateService
    {
        private static SchoolContext db = new SchoolContext();

        public static TeacherUserResponseViewModel CreateTeacherUser(TeacherUserViewModel model)
        {
            var response = new TeacherUserResponseViewModel();
            try
            {
                model.TeacherId = Guid.NewGuid();
                model.UserId = Guid.NewGuid();

                var user = new User
                {
                    Email = model.Email,
                    Username = model.Username,
                    Id = model.UserId,
                    HashedPassword = Md5Hash.Create(model.Password),
                    Status = true,
                    UserType = UserType.Teacher
                };

                db.User.Add(user);

                var teacher = new Teacher()
                {
                    Id = model.TeacherId,
                    UserId = model.UserId,
                    FName = model.FirstName,
                    LName = model.LastName,
                    Address = model.Address,
                    Gender = model.Gender,
                    IsActive = true,
                    MName = model.MiddleName

                };

                db.Teachers.Add(teacher);
                db.SaveChanges();

                response.UserId = user.Id;
                response.TeacherId = teacher.Id;
                response.Status = true;
                response.Message = "Teacher and User Created";
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return response;
        }
    }
}
