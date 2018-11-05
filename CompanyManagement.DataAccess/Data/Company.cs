namespace CompanyManagement.DataAccess.Data
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Company
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string Info { get; set; }

        public List<Employee> Employees { get; set; }
    }
}