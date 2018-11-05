namespace CompanyManagement.DataAccess.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddedCompanytoEmployee : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Employees", "Company_Id", "dbo.Companies");
            DropIndex("dbo.Employees", new[] { "Company_Id" });
            AddColumn("dbo.Employees", "CompanyId", c => c.Int(nullable: false));
            CreateIndex("dbo.Employees", "CompanyId");
            AddForeignKey("dbo.Employees", "CompanyId", "dbo.Companies", "Id", cascadeDelete: true);
            DropColumn("dbo.Employees", "Company_Id");
        }

        public override void Down()
        {
            AddColumn("dbo.Employees", "Company_Id", c => c.Int());
            DropForeignKey("dbo.Employees", "CompanyId", "dbo.Companies");
            DropIndex("dbo.Employees", new[] { "CompanyId" });
            DropColumn("dbo.Employees", "CompanyId");
            CreateIndex("dbo.Employees", "Company_Id");
            AddForeignKey("dbo.Employees", "Company_Id", "dbo.Companies", "Id");
        }
    }
}