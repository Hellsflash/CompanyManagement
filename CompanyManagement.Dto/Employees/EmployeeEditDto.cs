namespace CompanyManagement.Dto.Employees
{
    using System;
    using Common.Enums;

    public class EmployeeEditDto
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public ExperianceEnum ExperienceLevel { get; set; }

        public string StartDate { get; set; }

        public Decimal Salary { get; set; }

        public int VacationDays { get; set; }

        public int CompanyId { get; set; }
    }
}