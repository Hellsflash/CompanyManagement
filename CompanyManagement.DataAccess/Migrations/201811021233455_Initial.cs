namespace CompanyManagement.DataAccess.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Companies",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(nullable: false),
                    Address = c.String(nullable: false),
                    Info = c.String(nullable: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Employees",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    FirstName = c.String(nullable: false),
                    LastName = c.String(nullable: false),
                    ExperienceLevel = c.String(nullable: false),
                    StartDate = c.DateTime(nullable: false),
                    Salary = c.Decimal(nullable: false, precision: 18, scale: 2),
                    VacationDays = c.Int(nullable: false),
                    Company_Id = c.Int(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Companies", t => t.Company_Id)
                .Index(t => t.Company_Id);
        }

        public override void Down()
        {
            DropForeignKey("dbo.Employees", "Company_Id", "dbo.Companies");
            DropIndex("dbo.Employees", new[] { "Company_Id" });
            DropTable("dbo.Employees");
            DropTable("dbo.Companies");
        }
    }
}