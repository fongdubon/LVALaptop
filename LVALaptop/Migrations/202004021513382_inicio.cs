namespace LVALaptop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inicio : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EmployeePortables",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AssingmentDate = c.DateTime(nullable: false),
                        TerminationDate = c.DateTime(nullable: false),
                        Employee_Id = c.Int(),
                        Portable_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.Employee_Id)
                .ForeignKey("dbo.Portables", t => t.Portable_Id)
                .Index(t => t.Employee_Id)
                .Index(t => t.Portable_Id);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Portables",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SerialNumber = c.String(),
                        Model = c.String(),
                        PurchaseDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EmployeePortables", "Portable_Id", "dbo.Portables");
            DropForeignKey("dbo.EmployeePortables", "Employee_Id", "dbo.Employees");
            DropIndex("dbo.EmployeePortables", new[] { "Portable_Id" });
            DropIndex("dbo.EmployeePortables", new[] { "Employee_Id" });
            DropTable("dbo.Portables");
            DropTable("dbo.Employees");
            DropTable("dbo.EmployeePortables");
        }
    }
}
