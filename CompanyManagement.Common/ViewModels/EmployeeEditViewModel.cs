namespace CompanyManagement.Common.ViewModels
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Enums;

    public class EmployeeEditViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "First Name is Required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is Required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Experience Level is Required")]
        public ExperianceEnum ExperienceLevel { get; set; }

        [Required(ErrorMessage = "Start Date is Required")]
        [DataType(DataType.Date, ErrorMessage = "Wrong Date Format try dd/mm/yyyy")]
        public string StartDate { get; set; }

        [Required(ErrorMessage = "Salary is Required")]
        [Range(0.0, Double.MaxValue, ErrorMessage = "Not a number")]
        public Decimal Salary { get; set; }

        [Required(ErrorMessage = "Number of Days are Required")]
        [Range(0, Int32.MaxValue, ErrorMessage = "Not a Number")]
        public int VacationDays { get; set; }

        public int CompanyId { get; set; }
    }
}