using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PropertyManagement.Models
{
    public class RegistrationModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "User Name")]
        [Remote("EmailExists", "UserAuth", HttpMethod = "POST", ErrorMessage = "Email already exists")]

        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Compare("Password")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Name { get; set; }
        
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Surname { get; set; }


        [Required]
        [StringLength(10, MinimumLength = 10)]
        public string PhoneNumber { get; set; }

        public bool AcceptUserAgreement { get; set; }
        public string RegistrationInValid { get; set; }
    }
}
