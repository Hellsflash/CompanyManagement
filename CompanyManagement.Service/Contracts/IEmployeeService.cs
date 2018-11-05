namespace CompanyManagement.Service.Contracts
{
    using System.Collections.Generic;
    using Common.ViewModels;

    public interface IEmployeeService
    {
        List<EmployeeViewModel> GetAllEmployeesByCompanyId(int id);

        void AddEmployee(EmployeeAddViewModel model);

        EmployeeEditViewModel GetEmployeeById(int id);

        void EditEmployee(EmployeeEditViewModel model);

        void DeleteById(int id);

        EmployeeDeleteViewModel GetEmployeeForDeletion(int id);
    }
}