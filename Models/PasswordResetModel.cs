using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Project.Models.PasswordResetModel
{
    public class PasswordResetModel{
        [Required,EmailAddress,Display(Name="Registered email address")]

        private string username{get;set;}
        private string email{ get;set; }
        private string password{ get;set; }
        private bool EmailSent {get;set;}

    }
       

}