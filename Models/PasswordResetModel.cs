using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Project.Models
{
    public class PasswordResetModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string householdEmail { get; set; }

        //public bool requestPasswordReset {get;set;}
        public bool confirmationEmailSend { get; set; }
        public string administratorEmail { get; set; }
        public string resetlink { get; set; }
        //public bool PasswordResetNoti {get;set;}

        //new de
        // private string passwordReset { get; set; }

        //private string oldPassword { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "New Password")]
        public string newPassword { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("newPassword", ErrorMessage = "The password and confirmation password do not match.")]
        [Display(Name = "Confirm Reset Password")]
        public string confirmResetPassword { get; set; }

        // public string encrpytionURL { get; set; }

    }
}