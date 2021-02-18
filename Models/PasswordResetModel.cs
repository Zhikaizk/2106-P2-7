using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Project.Models.PasswordResetModel
{
    public class PasswordResetModel
    {
        private string householdEmail { get; set; }
        private bool requestPasswordReset {get;set;}
        private bool confirmationEmailSend { get; set; }
        private string resetlink{get;set;}
        private string encrpytionKey { get; set; }
        // private string newPassword { get; set; }
        // private string confirmPassword {get;set;}
        // private string oldPassword { get; set; }



    }


}