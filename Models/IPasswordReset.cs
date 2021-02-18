using System;

namespace Project.Models.PasswordReset
{
    public interface IPasswordRest
    {
         public String email{get;set;}
         public String resetlink{get;set;}
        //  public String newPassword{get;set;}
         
    }



}
