using System;

namespace Project.Models.Notification
{
    public interface IEmail
    {
         //this will be change to UnSubscribe (String email)
         // this will be change to Subscribe(String email); 
         public String updatecontent{get;set;}
         public String emailaddress{get;set;}
         public void UpdateObserver();
         //this will be change to Updatecontent(String);         
    }
}
