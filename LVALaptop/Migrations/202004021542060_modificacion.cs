namespace LVALaptop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modificacion : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "ImageUrl", c => c.String(maxLength: 200));
            AlterColumn("dbo.Employees", "FirstName", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Employees", "LastName", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Portables", "SerialNumber", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Portables", "Model", c => c.String(nullable: false, maxLength: 20));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Portables", "Model", c => c.String());
            AlterColumn("dbo.Portables", "SerialNumber", c => c.String());
            AlterColumn("dbo.Employees", "LastName", c => c.String());
            AlterColumn("dbo.Employees", "FirstName", c => c.String());
            DropColumn("dbo.Employees", "ImageUrl");
        }
    }
}
