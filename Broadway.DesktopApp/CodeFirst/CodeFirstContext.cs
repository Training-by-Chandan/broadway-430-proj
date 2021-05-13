using Broadway.DesktopApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Broadway.DesktopApp.CodeFirst
{
    public class CodeFirstContext : DbContext
    {
        public CodeFirstContext() : base("name=CodeFirstConnection")
        {

        }

        public virtual DbSet<Subjects> Subjects { get; set; }
        public virtual DbSet<Classes> Class { get; set; }
        public virtual DbSet<Teacher> Teacher { get; set; }
    }
}
