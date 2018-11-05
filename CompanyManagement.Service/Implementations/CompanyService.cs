namespace CompanyManagement.Service.Implementations
{
    using System.Collections.Generic;
    using System.Linq;
    using Common.ViewModels;
    using Contracts;
    using Dto.Companies;
    using Repository.Contracts;
    using Repository.Implementations;

    public class CompanyService : ICompanyService
    {
        private ICompanyRepository _companyRepository;

        public CompanyService(CompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public List<CompanyViewModel> GetAllCompanies()
        {
            var companies = _companyRepository.GetListOfCompanies();
            var companyListViewModels = companies
                .Select(c => new CompanyViewModel()
                {
                    Id = c.Id,
                    Address = c.Address,
                    Name = c.Name,
                    Info = c.Info
                })
                .ToList();

            return companyListViewModels;
        }

        public void CreateCompany(CompanyViewModel model)
        {
            var company = new CompanyDto
            {
                Name = model.Name,
                Address = model.Address,
                Info = model.Info
            };

            _companyRepository.CreateCompany(company);
        }

        public CompanyEditViewModel GetCompanyById(int id)
        {
            var company = _companyRepository.GetCompanyById(id);
            return new CompanyEditViewModel()
            {
                Id = company.Id,
                Name = company.Name,
                Address = company.Address,
                Info = company.Info
            };
        }

        public void EditComapny(CompanyEditViewModel model)
        {
            var comapny = new CompanyEditDto()
            {
                Id = model.Id,
                Address = model.Address,
                Info = model.Info,
                Name = model.Name,
            };
            _companyRepository.EditCompany(comapny);
        }

        public void DeleteCompanyById(int id)
        {
            _companyRepository.DeleteCompanyById(id);
        }

        public CompanyDeleteViewModel GetCompnyForDeletion(int id)
        {
            var company = _companyRepository.GetCompanyForDeletion(id);

            return new CompanyDeleteViewModel()
            {
                Id = company.Id,
                CompanyName = company.CompanyName
            };
        }
    }
}