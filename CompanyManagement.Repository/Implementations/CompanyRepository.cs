namespace CompanyManagement.Repository.Implementations
{
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using DataAccess.Contracts;
    using DataAccess.Data;
    using DataAccess.Implementations;
    using Dto.Companies;

    public class CompanyRepository : ICompanyRepository
    {
        private ICompanyManagementContext _context;

        public CompanyRepository(CompanyManagementContext context)
        {
            _context = context;
        }

        public List<CompanyDto> GetListOfCompanies()
        {
            var companies = _context.Companies.ToList();

            var companyListDto = companies.Select(c => new CompanyDto()
            {
                Id = c.Id,
                Address = c.Address,
                Info = c.Info,
                Name = c.Name
            }).ToList();

            return companyListDto;
        }

        public void CreateCompany(CompanyDto dto)
        {
            var company = new Company
            {
                Name = dto.Name,
                Address = dto.Address,
                Info = dto.Info
            };

            _context.Companies.Add(company);
            _context.SaveChanges();
        }

        public CompanyEditDto GetCompanyById(int id)
        {
            var company = _context.Companies.FirstOrDefault(c => c.Id == id);
            return new CompanyEditDto()
            {
                Id = company.Id,
                Name = company.Name,
                Address = company.Address,
                Info = company.Info
            };
        }

        public void EditCompany(CompanyEditDto dto)
        {
            if (_context.Companies.Any(c => c.Id == dto.Id))
            {
                var company = _context.Companies.FirstOrDefault(c => c.Id == dto.Id);
                company.Address = dto.Address;
                company.Info = dto.Info;
                company.Name = dto.Name;
                _context.SaveChanges();
            }
        }

        public void DeleteCompanyById(int id)
        {
            if (_context.Companies.Any(c => c.Id == id))
            {
                var company = _context.Companies.FirstOrDefault(c => c.Id == id);
                _context.Companies.Remove(company);
                _context.SaveChanges();
            }
        }

        public CompanyDeleteDto GetCompanyForDeletion(int id)
        {
            var company = _context.Companies.FirstOrDefault(c => c.Id == id);

            return new CompanyDeleteDto()
            {
                Id = company.Id,
                CompanyName = company.Name,
            };
        }
    }
}