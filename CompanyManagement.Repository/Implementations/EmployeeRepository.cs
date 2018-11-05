namespace CompanyManagement.Repository.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Common.Enums;
    using Contracts;
    using DataAccess.Contracts;
    using DataAccess.Data;
    using DataAccess.Implementations;
    using Dto.Employees;

    public class EmployeeRepository : IEmployeeRepository
    {
        private ICompanyManagementContext _context;

        public EmployeeRepository(CompanyManagementContext context)
        {
            _context = context;
        }

        public List<EmployeeDto> GetAllEmployeesByCompanyId(int id)
        {
            var employees = _context.Employees.Where(e => e.CompanyId == id).ToList();
            var company = _context.Companies.First(c => c.Id == id);
            var companyEmployees = employees.Select(e => new EmployeeDto()
            {
                Id = e.Id,
                FirstName = e.FirstName,
                LastName = e.LastName,
                StartDate = e.StartDate.ToLongDateString(),
                Salary = e.Salary,
                ExperienceLevel = e.ExperienceLevel,
                VacationDays = e.VacationDays,
                CompanyName = company.Name,
                CompanyId = company.Id
            });
            return companyEmployees.ToList();
        }

        public void AddEmployee(EmployeeAddDto dto)
        {
            var employee = new Employee()
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                StartDate = DateTime.Parse(dto.StartDate),
                CompanyId = dto.CompanyId,
                Salary = dto.Salary,
                VacationDays = dto.VacationDays,
                ExperienceLevel = dto.ExperienceLevel.ToString(),
            };
            _context.Employees.Add(employee);
            _context.SaveChanges();
        }

        public EmployeeEditDto GetEmployeeById(int id)
        {
            var employee = _context.Employees.FirstOrDefault(e => e.Id == id);

            return new EmployeeEditDto()
            {
                Id = employee.Id,
                CompanyId = employee.CompanyId,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                ExperienceLevel = (ExperianceEnum)Enum.Parse(typeof(ExperianceEnum), employee.ExperienceLevel),
                Salary = employee.Salary,
                StartDate = employee.StartDate.ToShortDateString(),
                VacationDays = employee.VacationDays
            };
        }

        public void EditEmployee(EmployeeEditDto dto)
        {
            var employee = _context.Employees.FirstOrDefault(e => e.Id == dto.Id);

            employee.FirstName = dto.FirstName;
            employee.LastName = dto.LastName;
            employee.ExperienceLevel = dto.ExperienceLevel.ToString();
            employee.Salary = dto.Salary;
            employee.VacationDays = dto.VacationDays;
            employee.StartDate = DateTime.Parse(dto.StartDate);

            _context.SaveChanges();
        }

        public void DeleteById(int id)
        {
            var employee = _context.Employees.FirstOrDefault(e => e.Id == id);
            _context.Employees.Remove(employee);
            _context.SaveChanges();
        }

        public EmployeeDeleteDto GetEmployeeForDeletion(int id)
        {
            var employee = _context.Employees.FirstOrDefault(e => e.Id == id);

            return new EmployeeDeleteDto()
            {
                Id = employee.Id,
                CompanyId = employee.CompanyId,
                FirstName = employee.FirstName,
                LastName = employee.LastName
            };
        }
    }
}