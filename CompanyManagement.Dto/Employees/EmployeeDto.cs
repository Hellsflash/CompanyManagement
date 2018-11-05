namespace CompanyManagement.Dto.Employees
{
    using System;

    public class EmployeeDto
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string ExperienceLevel { get; set; }

        public string StartDate { get; set; }

        public Decimal Salary { get; set; }

        public int VacationDays { get; set; }

        public string CompanyName { get; set; }

        public int CompanyId { get; set; }
    }
}