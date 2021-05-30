namespace School.Managment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class boolean : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AcademicYears", "IsActive", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Attendances", "Status", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Students", "IsActive", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Classes", "IsActive", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Teachers", "IsActive", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Users", "Status", c => c.Boolean());
            AlterColumn("dbo.Subjects", "IsActive", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Parents", "IsActive", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Parents", "IsActive", c => c.String());
            AlterColumn("dbo.Subjects", "IsActive", c => c.String());
            AlterColumn("dbo.Users", "Status", c => c.String());
            AlterColumn("dbo.Teachers", "IsActive", c => c.String());
            AlterColumn("dbo.Classes", "IsActive", c => c.String());
            AlterColumn("dbo.Students", "IsActive", c => c.String());
            AlterColumn("dbo.Attendances", "Status", c => c.String());
            AlterColumn("dbo.AcademicYears", "IsActive", c => c.String());
        }
    }
}
