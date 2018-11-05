namespace CompanyManagement.Repository
{
    using System.Web.Mvc;
    using DataAccess.Contracts;
    using DataAccess.Implementations;
    using Unity;
    using Unity.Mvc5;

    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            container.RegisterType<ICompanyManagementContext, CompanyManagementContext>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}