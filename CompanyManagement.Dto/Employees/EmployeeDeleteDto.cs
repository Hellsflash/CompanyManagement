namespace CompanyManagement.Dto.Employees
{
    public class EmployeeDeleteDto
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int CompanyId { get; set; }
    }
}