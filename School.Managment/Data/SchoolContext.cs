using School.Managment.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
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

        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Exams> Exams { get; set; }
        public virtual DbSet<AcademicYear> AcademicYears { get; set; }
        public virtual DbSet<Attendance> Attendances { get; set; }
        public virtual DbSet<Classes> Classes { get; set; }
        public virtual DbSet<ClassSubject> ClassSubjects { get; set; }
        public virtual DbSet<ExamsStudents> ExamsStudents { get; set; }
        public virtual DbSet<Parents> Parents { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<StudentClass> StudentClasses { get; set; }
        public virtual DbSet<StudentParents> StudentParents { get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }
        public virtual DbSet<Teacher> Teachers { get; set; }
        public virtual DbSet<ClassSubjectTeacher> ClassSubjectTeachers { get; set; }
        public virtual DbSet<ExamClassSubject> ExamClassSubjects { get; set; }

        
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
           
            base.OnModelCreating(modelBuilder);
        }
    }
}
