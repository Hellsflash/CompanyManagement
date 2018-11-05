namespace CompanyManagement.Service
{
    using System.Web.Mvc;
    using Repository.Contracts;
    using Repository.Implementations;
    using Unity;
    using Unity.Mvc5;

    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            container.RegisterType<ICompanyRepository, CompanyRepository>();
            container.RegisterType<IEmployeeRepository, EmployeeRepository>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}