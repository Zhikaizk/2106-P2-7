using System;

namespace Project.Models.PasswordReset
{
    public interface IPasswordRest
    {
         public String email{get;set;}
         public String resetLink{get;set;}
          public String newPassword{get;set;}
         
    }
}
