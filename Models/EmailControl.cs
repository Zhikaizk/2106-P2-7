using System;
using System.Collections;
using System.Collections.Generic;
using Project.Models.Notification;

namespace Project.Models.Notification
{
    public class EmailControl   
    {  
        public EmailControl (String emailaddress ,String emailnotifiy)
        {
            Console.WriteLine(emailaddress+emailnotifiy+"HI IM HEREE");
            Softwareupdate(emailaddress,emailnotifiy);
        }
        private void Softwareupdate(String emailaddresses, String emailnotifiy)
        {
            EmailNotification S1 = new EmailNotification(emailnotifiy);  
            Email O1 = new Email(emailaddresses);  
            O1.Subscribe(S1);  
            Console.WriteLine();     
        }
}  
}