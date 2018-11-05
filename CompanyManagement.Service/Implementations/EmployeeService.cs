namespace CompanyManagement.Service.Implementations
{
    using System.Collections.Generic;
    using System.Linq;
    using Common.ViewModels;
    using Contracts;
    using Dto.Employees;
    using Repository.Contracts;
    using Repository.Implementations;

    public class EmployeeService : IEmployeeService
    {
        private IEmployeeRepository _employeeRepository;

        public EmployeeService(EmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public List<EmployeeViewModel> GetAllEmployeesByCompanyId(int id)
        {
            var employees = _employeeRepository.GetAllEmployeesByCompanyId(id);

            var companyemployees = employees.Select(e => new EmployeeViewModel()
            {
                Id = e.Id,
                FirstName = e.FirstName,
                LastName = e.LastName,
                StartDate = e.StartDate,
                ExperienceLevel = e.ExperienceLevel,
                Salary = e.Salary,
                VacationDays = e.VacationDays,
                CompanyName = e.CompanyName,
                CompanyId = e.CompanyId
            });

            return companyemployees.ToList();
        }

        public void AddEmployee(EmployeeAddViewModel model)
        {
            var dto = new EmployeeAddDto()
            {
                Id = model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                ExperienceLevel = model.ExperienceLevel,
                StartDate = model.StartDate,
                CompanyId = model.CompanyId,
                Salary = model.Salary,
                VacationDays = model.VacationDays
            };

            _employeeRepository.AddEmployee(dto);
        }

        public EmployeeEditViewModel GetEmployeeById(int id)
        {
            var employee = _employeeRepository.GetEmployeeById(id);

            return new EmployeeEditViewModel()
            {
                Id = employee.Id,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                ExperienceLevel = employee.ExperienceLevel,
                StartDate = employee.StartDate,
                Salary = employee.Salary,
                CompanyId = employee.CompanyId,
                VacationDays = employee.VacationDays,
            };
        }

        public void EditEmployee(EmployeeEditViewModel model)
        {
            var employee = new EmployeeEditDto()
            {
                Id = model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                ExperienceLevel = model.ExperienceLevel,
                StartDate = model.StartDate,
                Salary = model.Salary,
                CompanyId = model.CompanyId,
                VacationDays = model.VacationDays,
            };
            _employeeRepository.EditEmployee(employee);
        }

        public void DeleteById(int id)
        {
            _employeeRepository.DeleteById(id);
        }

        public EmployeeDeleteViewModel GetEmployeeForDeletion(int id)
        {
            var employee = _employeeRepository.GetEmployeeForDeletion(id);

            return new EmployeeDeleteViewModel()
            {
                Id = employee.Id,
                CompanyId = employee.CompanyId,
                FirstName = employee.FirstName,
                LastName = employee.LastName
            };
        }
    }
}