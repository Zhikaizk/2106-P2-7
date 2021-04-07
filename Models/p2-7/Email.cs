using System;
using System.Collections.Generic;
namespace Project.Models.Notification
{

    public class Email : IEmail
    {
        //private EmailNotification _emailNotification;  
        public String updateSubject { get; set; }
        public String updateContent { get; set; }
        public String emailAddress { get; set; }
        public Email()
        {
        }

        public Email(string addressIn)
        {
            // save the address for later
            emailAddress = addressIn;
        }


        public void Update(string subject,string message)
        {
            updateSubject=subject;
            updateContent = message;

        }
    }
}