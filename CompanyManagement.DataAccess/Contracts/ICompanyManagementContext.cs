namespace CompanyManagement.DataAccess.Contracts
{
    using System.Data.Entity;
    using Data;

    public interface ICompanyManagementContext
    {
        DbSet<Company> Companies { get; set; }

        DbSet<Employee> Employees { get; set; }

        int SaveChanges();
    }
}