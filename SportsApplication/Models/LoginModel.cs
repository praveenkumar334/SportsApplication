﻿using System.ComponentModel.DataAnnotations;

namespace SportsApplication.Models
{
    public class LoginModel
    {


        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 12)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }


    }

}
