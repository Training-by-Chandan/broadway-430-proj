namespace School.Managment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AcademicYears",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        YearName = c.String(),
                        StartDate = c.String(),
                        EndDate = c.String(),
                        IsActive = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Attendances",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Date = c.String(),
                        StudentId = c.Guid(nullable: false),
                        TeacherId = c.Guid(nullable: false),
                        AcademicYearId = c.Guid(nullable: false),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AcademicYears", t => t.AcademicYearId)
                .ForeignKey("dbo.Students", t => t.StudentId)
                .ForeignKey("dbo.Teachers", t => t.TeacherId)
                .Index(t => t.StudentId)
                .Index(t => t.TeacherId)
                .Index(t => t.AcademicYearId);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FName = c.String(),
                        MName = c.String(),
                        LName = c.String(),
                        Address = c.String(),
                        Gender = c.String(),
                        UserId = c.Guid(nullable: false),
                        IsActive = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.ExamsStudents",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        StudentId = c.Guid(nullable: false),
                        ExamDetailsId = c.Guid(nullable: false),
                        MarksObtained = c.String(),
                        FullMarks = c.String(),
                        PassMarks = c.String(),
                        ExamType = c.String(),
                        AttendanceStatus = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ExamClassSubjects", t => t.ExamDetailsId)
                .ForeignKey("dbo.Students", t => t.StudentId)
                .Index(t => t.StudentId)
                .Index(t => t.ExamDetailsId);
            
            CreateTable(
                "dbo.ExamClassSubjects",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ExamId = c.Guid(nullable: false),
                        SubjectClassId = c.Guid(nullable: false),
                        ExamDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ClassSubjects", t => t.SubjectClassId)
                .ForeignKey("dbo.Exams", t => t.ExamId)
                .Index(t => t.ExamId)
                .Index(t => t.SubjectClassId);
            
            CreateTable(
                "dbo.ClassSubjects",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ClassId = c.Guid(nullable: false),
                        SubjectId = c.Guid(nullable: false),
                        AcademicYearId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AcademicYears", t => t.AcademicYearId)
                .ForeignKey("dbo.Classes", t => t.ClassId)
                .ForeignKey("dbo.Subjects", t => t.SubjectId)
                .Index(t => t.ClassId)
                .Index(t => t.SubjectId)
                .Index(t => t.AcademicYearId);
            
            CreateTable(
                "dbo.Classes",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ClassName = c.String(),
                        RoomNumber = c.String(),
                        ClassTeacherId = c.Guid(nullable: false),
                        AcademicYearId = c.Guid(nullable: false),
                        IsActive = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AcademicYears", t => t.AcademicYearId)
                .ForeignKey("dbo.Teachers", t => t.ClassTeacherId)
                .Index(t => t.ClassTeacherId)
                .Index(t => t.AcademicYearId);
            
            CreateTable(
                "dbo.StudentClasses",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        StudentId = c.Guid(nullable: false),
                        ClassId = c.Guid(nullable: false),
                        AcademicYearId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AcademicYears", t => t.AcademicYearId)
                .ForeignKey("dbo.Classes", t => t.ClassId)
                .ForeignKey("dbo.Students", t => t.StudentId)
                .Index(t => t.StudentId)
                .Index(t => t.ClassId)
                .Index(t => t.AcademicYearId);
            
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FName = c.String(),
                        MName = c.String(),
                        LName = c.String(),
                        Gender = c.String(),
                        UserId = c.Guid(nullable: false),
                        Address = c.String(),
                        Phone = c.String(),
                        IsActive = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.ClassSubjectTeachers",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        TeacherId = c.Guid(nullable: false),
                        ClassSubjectId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ClassSubjects", t => t.ClassSubjectId)
                .ForeignKey("dbo.Teachers", t => t.TeacherId)
                .Index(t => t.TeacherId)
                .Index(t => t.ClassSubjectId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Username = c.String(),
                        HashedPassword = c.String(),
                        Email = c.String(),
                        UserType = c.Int(nullable: false),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Subjects",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        SubjectName = c.String(),
                        SubjectCode = c.String(),
                        IsActive = c.String(),
                        AcademicYearId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AcademicYears", t => t.AcademicYearId)
                .Index(t => t.AcademicYearId);
            
            CreateTable(
                "dbo.Exams",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ExamName = c.String(),
                        AcademicYearId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AcademicYears", t => t.AcademicYearId)
                .Index(t => t.AcademicYearId);
            
            CreateTable(
                "dbo.StudentParents",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        StudentId = c.Guid(nullable: false),
                        ParentId = c.Guid(nullable: false),
                        ParentType = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Parents", t => t.StudentId)
                .ForeignKey("dbo.Students", t => t.ParentId)
                .Index(t => t.StudentId)
                .Index(t => t.ParentId);
            
            CreateTable(
                "dbo.Parents",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FName = c.String(),
                        MName = c.String(),
                        LName = c.String(),
                        Gender = c.String(),
                        PhoneNumber = c.String(),
                        IsActive = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "UserId", "dbo.Users");
            DropForeignKey("dbo.StudentParents", "ParentId", "dbo.Students");
            DropForeignKey("dbo.StudentParents", "StudentId", "dbo.Parents");
            DropForeignKey("dbo.ExamsStudents", "StudentId", "dbo.Students");
            DropForeignKey("dbo.ExamsStudents", "ExamDetailsId", "dbo.ExamClassSubjects");
            DropForeignKey("dbo.ExamClassSubjects", "ExamId", "dbo.Exams");
            DropForeignKey("dbo.Exams", "AcademicYearId", "dbo.AcademicYears");
            DropForeignKey("dbo.ClassSubjects", "SubjectId", "dbo.Subjects");
            DropForeignKey("dbo.Subjects", "AcademicYearId", "dbo.AcademicYears");
            DropForeignKey("dbo.ExamClassSubjects", "SubjectClassId", "dbo.ClassSubjects");
            DropForeignKey("dbo.Teachers", "UserId", "dbo.Users");
            DropForeignKey("dbo.ClassSubjectTeachers", "TeacherId", "dbo.Teachers");
            DropForeignKey("dbo.ClassSubjectTeachers", "ClassSubjectId", "dbo.ClassSubjects");
            DropForeignKey("dbo.Classes", "ClassTeacherId", "dbo.Teachers");
            DropForeignKey("dbo.Attendances", "TeacherId", "dbo.Teachers");
            DropForeignKey("dbo.StudentClasses", "StudentId", "dbo.Students");
            DropForeignKey("dbo.StudentClasses", "ClassId", "dbo.Classes");
            DropForeignKey("dbo.StudentClasses", "AcademicYearId", "dbo.AcademicYears");
            DropForeignKey("dbo.ClassSubjects", "ClassId", "dbo.Classes");
            DropForeignKey("dbo.Classes", "AcademicYearId", "dbo.AcademicYears");
            DropForeignKey("dbo.ClassSubjects", "AcademicYearId", "dbo.AcademicYears");
            DropForeignKey("dbo.Attendances", "StudentId", "dbo.Students");
            DropForeignKey("dbo.Attendances", "AcademicYearId", "dbo.AcademicYears");
            DropIndex("dbo.StudentParents", new[] { "ParentId" });
            DropIndex("dbo.StudentParents", new[] { "StudentId" });
            DropIndex("dbo.Exams", new[] { "AcademicYearId" });
            DropIndex("dbo.Subjects", new[] { "AcademicYearId" });
            DropIndex("dbo.ClassSubjectTeachers", new[] { "ClassSubjectId" });
            DropIndex("dbo.ClassSubjectTeachers", new[] { "TeacherId" });
            DropIndex("dbo.Teachers", new[] { "UserId" });
            DropIndex("dbo.StudentClasses", new[] { "AcademicYearId" });
            DropIndex("dbo.StudentClasses", new[] { "ClassId" });
            DropIndex("dbo.StudentClasses", new[] { "StudentId" });
            DropIndex("dbo.Classes", new[] { "AcademicYearId" });
            DropIndex("dbo.Classes", new[] { "ClassTeacherId" });
            DropIndex("dbo.ClassSubjects", new[] { "AcademicYearId" });
            DropIndex("dbo.ClassSubjects", new[] { "SubjectId" });
            DropIndex("dbo.ClassSubjects", new[] { "ClassId" });
            DropIndex("dbo.ExamClassSubjects", new[] { "SubjectClassId" });
            DropIndex("dbo.ExamClassSubjects", new[] { "ExamId" });
            DropIndex("dbo.ExamsStudents", new[] { "ExamDetailsId" });
            DropIndex("dbo.ExamsStudents", new[] { "StudentId" });
            DropIndex("dbo.Students", new[] { "UserId" });
            DropIndex("dbo.Attendances", new[] { "AcademicYearId" });
            DropIndex("dbo.Attendances", new[] { "TeacherId" });
            DropIndex("dbo.Attendances", new[] { "StudentId" });
            DropTable("dbo.Parents");
            DropTable("dbo.StudentParents");
            DropTable("dbo.Exams");
            DropTable("dbo.Subjects");
            DropTable("dbo.Users");
            DropTable("dbo.ClassSubjectTeachers");
            DropTable("dbo.Teachers");
            DropTable("dbo.StudentClasses");
            DropTable("dbo.Classes");
            DropTable("dbo.ClassSubjects");
            DropTable("dbo.ExamClassSubjects");
            DropTable("dbo.ExamsStudents");
            DropTable("dbo.Students");
            DropTable("dbo.Attendances");
            DropTable("dbo.AcademicYears");
        }
    }
}
