namespace School.Managment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class gender : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Students", "Gender", c => c.Int(nullable: false));
            AlterColumn("dbo.Teachers", "Gender", c => c.Int(nullable: false));
            AlterColumn("dbo.Parents", "Gender", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Parents", "Gender", c => c.String());
            AlterColumn("dbo.Teachers", "Gender", c => c.String());
            AlterColumn("dbo.Students", "Gender", c => c.String());
        }
    }
}
