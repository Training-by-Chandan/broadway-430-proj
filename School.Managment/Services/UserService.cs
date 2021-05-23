using School.Managment.Common;
using School.Managment.Data;
using School.Managment.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Managment.Services
{
    public static class UserService
    {
        public static SchoolContext db = new SchoolContext();

        public static StudentUserResponseViewModel CreateStudentUser(StudentUserViewModel model)
        {
            var response = new StudentUserResponseViewModel();
            try
            {
                model.StudentId = Guid.NewGuid();
                model.UserId = Guid.NewGuid();

                var user = new User { Email=model.Email, Username= model.Username, Id=model.UserId, HashedPassword=Md5Hash.Create(model.Password), Status=true, UserType= UserType.Student };

                db.User.Add(user);

                var student = new Student() {
                    Id = model.StudentId,
                    UserId = model.UserId,
                    FName = model.FirstName,
                    LName = model.LastName,
                    Address = model.Address,
                    Gender = model.Gender,
                    IsActive = true,
                    MName = model.MiddleName
                         
                };

                db.Students.Add(student);
                db.SaveChanges();

                response.UserId = user.Id;
                response.StudentId = student.Id;
                response.Status = true;
                response.Message = "All Good";
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return response;
        }
    }
}
