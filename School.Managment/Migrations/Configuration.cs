namespace School.Managment.Migrations
{
    using School.Managment.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using School.Managment.Common;

    internal sealed class Configuration : DbMigrationsConfiguration<School.Managment.Data.SchoolContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(School.Managment.Data.SchoolContext db)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            #region Admin
            var admin = new Users() {
                Id = Guid.Parse("f000991c-12bc-44ea-9fef-0f62a938c1d8"),
                Email = "admin@admin.com",
                Password = Md5Hash.Create("Admin@123"),
                Username = "admin",
                UserType = Common.UserType.Admin
                  
            };

            var existingAdmin = db.User.Find(admin.Id);
            if (existingAdmin==null)
            {
                db.User.Add(admin);
                db.SaveChanges();
            }
            else
            {
                existingAdmin.Email=admin.Email;
                existingAdmin.Password = admin.Password;
                db.Entry(existingAdmin).State = EntityState.Modified;
                db.SaveChanges();
            }
            #endregion

            #region Student
            var student = new Users()
            {
                Id = Guid.Parse("f000991c-12bc-44ea-9fef-0f62a938c1d9"),
                Email = "student@student.com",
                Password = Md5Hash.Create("Student@123"),
                Username = "student",
                UserType = Common.UserType.Student

            };

            var exitingStudent = db.User.Find(student.Id);
            if (exitingStudent == null)
            {
                db.User.Add(student);
                db.SaveChanges();
            }
            else
            {
                exitingStudent.Email = student.Email;
                exitingStudent.Password = student.Password;
                db.Entry(exitingStudent).State = EntityState.Modified;
                db.SaveChanges();
            }
            #endregion

            #region Teacher

            var teacher = new Users()
            {
                Id = Guid.Parse("f000991c-12bc-44ea-9fef-0f62a938c1d0"),
                Email = "teacher@teacher.com",
                Password = Md5Hash.Create("Teacher@123"),
                Username = "teacher",
                UserType = Common.UserType.Teacher

            };
            var exitingTeacher = db.User.Find(teacher.Id);
            if (exitingTeacher == null)
            {
                db.User.Add(teacher);
                db.SaveChanges();
            }
            else
            {
                exitingTeacher.Email = teacher.Email;
                exitingTeacher.Password = teacher.Password;
                db.Entry(exitingTeacher).State = EntityState.Modified;
                db.SaveChanges();
            }
            #endregion

        }
    }
}
