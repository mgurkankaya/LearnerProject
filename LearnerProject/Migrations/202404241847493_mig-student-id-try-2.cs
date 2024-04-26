namespace LearnerProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migstudentidtry2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CourseRegisters", "StudentId", "dbo.Students");
            DropIndex("dbo.CourseRegisters", new[] { "StudentId" });
            AlterColumn("dbo.CourseRegisters", "StudentId", c => c.Int(nullable: false));
            CreateIndex("dbo.CourseRegisters", "StudentId");
            AddForeignKey("dbo.CourseRegisters", "StudentId", "dbo.Students", "StudentId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CourseRegisters", "StudentId", "dbo.Students");
            DropIndex("dbo.CourseRegisters", new[] { "StudentId" });
            AlterColumn("dbo.CourseRegisters", "StudentId", c => c.Int());
            CreateIndex("dbo.CourseRegisters", "StudentId");
            AddForeignKey("dbo.CourseRegisters", "StudentId", "dbo.Students", "StudentId");
        }
    }
}
