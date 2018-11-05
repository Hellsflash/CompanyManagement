namespace CompanyManagement.Repository.Contracts
{
    using System.Collections.Generic;
    using Dto.Employees;

    public interface IEmployeeRepository
    {
        List<EmployeeDto> GetAllEmployeesByCompanyId(int id);

        void AddEmployee(EmployeeAddDto dto);

        EmployeeEditDto GetEmployeeById(int id);

        void EditEmployee(EmployeeEditDto dto);

        void DeleteById(int id);

        EmployeeDeleteDto GetEmployeeForDeletion(int id);
    }
}