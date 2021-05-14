namespace Broadway.DesktopApp.Migrations
{
    using Broadway.DesktopApp.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Broadway.DesktopApp.CodeFirst.CodeFirstContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            //AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(Broadway.DesktopApp.CodeFirst.CodeFirstContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            var user = new User() { UserName = "Admin", Password = "Admin@123" };

            var userFromDB = context.Users.FirstOrDefault(p => p.UserName == user.UserName);
            if (userFromDB==null)
            {
                context.Users.Add(user);
                context.SaveChanges();
            }
            else
            {
                userFromDB.Password = user.Password;
                
                context.Entry(userFromDB).State = EntityState.Modified;
                context.SaveChanges();
            }

        }
    }
}
