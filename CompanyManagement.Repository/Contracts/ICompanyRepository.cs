namespace CompanyManagement.Repository.Contracts
{
    using System.Collections.Generic;
    using Dto.Companies;

    public interface ICompanyRepository
    {
        List<CompanyDto> GetListOfCompanies();

        void CreateCompany(CompanyDto dto);

        CompanyEditDto GetCompanyById(int id);

        void EditCompany(CompanyEditDto dto);

        void DeleteCompanyById(int id);

        CompanyDeleteDto GetCompanyForDeletion(int id);
    }
}