using System;
using System.Collections.Generic;
namespace Project.Models.Notification
{
 
 public class Email : IEmail  
 {
//private EmailNotification _emailNotification;  
     public String updatecontent{get;set;}
       public String emailaddress{get;set;}
          public Email()
        {
        }

   public Email(string addressIn)
        {
            // save the address for later
            emailaddress = addressIn;
        }


     public void Update(string message)
        {
            updatecontent = message;

        }

 }
}