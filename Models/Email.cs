using System;
using System.Collections.Generic;
namespace Project.Models.Notification
{

    public class Email : IEmail
    {
        //private EmailNotification _emailNotification;  
        public String updatecontent { get; set; }
        public String emailaddress { get; set; }
        public Email()
        {
          Console.WriteLine("Email() Email Endedhere");
          EmailPassword(householdEmailDetails);
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


        public String householdEmailDetails { get; set; }
        public void EmailPassword(string householdEmailDetails)
        {
            Console.WriteLine("EmailPassword() Email Endedhere");

            // save the address for later
            this.householdEmailDetails = householdEmailDetails;
        }



    }
}