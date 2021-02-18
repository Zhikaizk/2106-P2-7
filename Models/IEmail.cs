using System;

namespace Project.Models.Notification
{
    public interface IEmail
    {
         public String updatecontent{get;set;}
         public String emailaddress{get;set;}
         public void UpdateObserver();  
        // public void Subscribe(EmailNotification emailNotification)  
        //public void Subscribe(String emailNotification)  
         
    }



}
