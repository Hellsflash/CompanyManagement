namespace CompanyManagement.Common.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    public class CompanyEditViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is Required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Address is Required")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Info is Required")]
        public string Info { get; set; }
    }
}