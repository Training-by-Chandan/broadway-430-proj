using School.Managment.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Managment.Data
{
    public class SchoolContext : DbContext
    {
        public SchoolContext() : base("name=SchoolConnection")
        {

        }

        public virtual DbSet<Users> User { get; set; }
        public virtual DbSet<Exams> Exams { get; set; }
    }
}
