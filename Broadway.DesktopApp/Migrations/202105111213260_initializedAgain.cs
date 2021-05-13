namespace Broadway.DesktopApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initializedAgain : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Classes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClassName = c.String(),
                        TeacherId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Teachers", t => t.TeacherId)
                .Index(t => t.TeacherId);
            
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Subjects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SubjectCode = c.String(maxLength: 5),
                        SubjectName = c.String(),
                        ClassId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Classes", t => t.ClassId, cascadeDelete: true)
                .Index(t => t.ClassId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Subjects", "ClassId", "dbo.Classes");
            DropForeignKey("dbo.Classes", "TeacherId", "dbo.Teachers");
            DropIndex("dbo.Subjects", new[] { "ClassId" });
            DropIndex("dbo.Classes", new[] { "TeacherId" });
            DropTable("dbo.Subjects");
            DropTable("dbo.Teachers");
            DropTable("dbo.Classes");
        }
    }
}
