using System.ComponentModel.DataAnnotations;

namespace ADSBackend.Models.AdminViewModels
{
    public class UserViewModel
    {
        public int Id { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "First Name")]
        [Required]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        public string Role { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Passwords don't match")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Name of Assignment: ")]
        public string AssignmentName { get; set; }

        [Display(Name = "Optional Specified Time: ")]
        public string TimeChoice { get; set; }

        [Display(Name = "Optional Choice Of Date To Be Completed On: ")]
        public string DateChoice { get; set; }

        [Display(Name = "Due Date: ")]
        public string DueDate { get; set; }

       
    }
}
