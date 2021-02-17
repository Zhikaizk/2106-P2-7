using System;

namespace Project.Models.Notification
{
    public interface IEmail
    {
         public String updatecontent{get;set;}
         public String emailaddress{get;set;}
         void UpdateObserver();  
         
    }



}
