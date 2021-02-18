using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Project.Models.PasswordResetModel
{
    public class PasswordResetModel
    {
        private string email { get; set; }
        private string oldPassword { get; set; }
        private string encrpytionPassword { get; set; }
        private string newPassword { get; set; }
        private string confirmPassword {get;set;}
        private bool EmailSent { get; set; }

    }


}