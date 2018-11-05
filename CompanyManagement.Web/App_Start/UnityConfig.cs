namespace CompanyManagement.Web
{
    using System.Web.Mvc;
    using Service.Contracts;
    using Service.Implementations;
    using Unity;
    using Unity.Mvc5;

    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            container.RegisterType<ICompanyService, CompanyService>();
            container.RegisterType<IEmployeeService, EmployeeService>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}