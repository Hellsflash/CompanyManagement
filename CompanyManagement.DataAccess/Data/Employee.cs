namespace CompanyManagement.DataAccess.Data
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Employee
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string ExperienceLevel { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public Decimal Salary { get; set; }

        [Required]
        public int VacationDays { get; set; }

        public int CompanyId { get; set; }

        public Company Company { get; set; }
    }
}