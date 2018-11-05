namespace CompanyManagement.DataAccess.Implementations
{
    using System.Data.Entity;
    using Contracts;
    using Data;

    public class CompanyManagementContext : DbContext, ICompanyManagementContext
    {
        public CompanyManagementContext() : base("CompanyManagementContext")
        {
        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}