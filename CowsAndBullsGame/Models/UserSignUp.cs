using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CowsAndBullsGame.Models
{
    public class UserSignUp
    {
        [Required(ErrorMessage = "Please Enter your FirstName")]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required(ErrorMessage ="Please Enter your Email")]
        [Display(Name ="Email Address")]
        [EmailAddress(ErrorMessage ="Please Enter valid Email")]
        public string Email { get; set; }

        [Required(ErrorMessage ="Please Enter Password")]
        [Display(Name ="Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage ="Password shuould match")]
        [Display(Name ="Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage ="Password does not match")]
        public string ConfirmPassword { get; set; }

    }
}
