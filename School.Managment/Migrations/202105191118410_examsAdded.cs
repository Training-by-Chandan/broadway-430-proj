namespace School.Managment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class examsAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ExamInfo",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ExamName = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Year = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ExamInfo");
        }
    }
}
