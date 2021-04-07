using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Project.Models
{
    public class GenerateResetLink
    {
        public bool confirmationEmailSend { get; set; }
        public string resetlink { get; set; }

        public List<PasswordResetModel> householdEmailList {get;set;}

    }
}