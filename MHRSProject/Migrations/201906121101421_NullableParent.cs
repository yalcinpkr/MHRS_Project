namespace MHRSProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NullableParent : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Departments", new[] { "ParentDepartmentId" });
            AlterColumn("dbo.Departments", "ParentDepartmentId", c => c.Int());
            CreateIndex("dbo.Departments", "ParentDepartmentId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Departments", new[] { "ParentDepartmentId" });
            AlterColumn("dbo.Departments", "ParentDepartmentId", c => c.Int(nullable: false));
            CreateIndex("dbo.Departments", "ParentDepartmentId");
        }
    }
}
