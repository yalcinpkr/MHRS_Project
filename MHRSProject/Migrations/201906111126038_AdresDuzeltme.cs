namespace MHRSProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdresDuzeltme : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Hospitals", "Address", c => c.String(maxLength: 4000));
            DropColumn("dbo.Hospitals", "Adress");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Hospitals", "Adress", c => c.String(maxLength: 4000));
            DropColumn("dbo.Hospitals", "Address");
        }
    }
}
