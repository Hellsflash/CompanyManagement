namespace CompanyManagement.Service.Contracts
{
    using System.Collections.Generic;
    using Common.ViewModels;

    public interface ICompanyService
    {
        List<CompanyViewModel> GetAllCompanies();

        void CreateCompany(CompanyViewModel model);

        CompanyEditViewModel GetCompanyById(int id);

        void EditComapny(CompanyEditViewModel model);

        void DeleteCompanyById(int id);

        CompanyDeleteViewModel GetCompnyForDeletion(int id);
    }
}