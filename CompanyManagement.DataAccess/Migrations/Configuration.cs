namespace CompanyManagement.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using Data;

    internal sealed class Configuration : DbMigrationsConfiguration<CompanyManagement.DataAccess.Implementations.CompanyManagementContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Implementations.CompanyManagementContext context)
        {
            var fistCompany = new Company()
            {
                Id = 1,
                Name = "Microsoft",
                Address = "One Microsoft Way, Redmond, Washington, U.S",
                Info = "Microsoft is an American multinational technology company with headquarters in Redmond, Washington. It develops, manufactures, licenses, supports and sells computer software, consumer electronics, personal computers, and related services."
            };
            var secondCompany = new Company()
            {
                Id = 2,
                Name = "Google",
                Address = "1600 Amphitheatre Parkway in Mountain View, California, United States",
                Info = "Google is an American multinational technology company that specializes in Internet-related services and products, which include online advertising technologies, search engine, cloud computing, software, and hardware."
            };

            var firstEmployeee = new Employee()
            {
                FirstName = "Bill",
                LastName = "Gates",
                CompanyId = 1,
                ExperienceLevel = "D",
                Salary = 1000000,
                StartDate = DateTime.Parse("4/4/1975"),
                VacationDays = 20,
            };

            context.Companies.AddOrUpdate(fistCompany);
            context.Companies.AddOrUpdate(secondCompany);
            context.Employees.AddOrUpdate(firstEmployeee);
        }
    }
}