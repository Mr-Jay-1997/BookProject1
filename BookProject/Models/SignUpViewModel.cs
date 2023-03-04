using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BookProject.Models
{
    public class SignUpViewModel
    {
        [Key]
        public int UserId { get; set; }
        [Required(ErrorMessage ="Please enter First Name")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Please enter Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter Email")]
        [Remote(action: "IsUserExist", controller: "Account")]
        
        public string Email { get; set; }
        
        [Required(ErrorMessage = "Please enter Password")]
        public string Password { get; set; }
        [Compare("Password", ErrorMessage ="Passwords doesn't match")]
        [Required(ErrorMessage = "Please enter Password")]

        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }

        public string Mobile { get; set; }

    }
}
