using System;
using System.Collections;
using System.Collections.Generic;
using Project.Models.Notification;
using System.Net.Mail;
using System.Net;

namespace Project.Models.Notification
{

    public class EmailNotification : AbstractEmailNotification
    {  


        public EmailNotification(){} 
  
    
        public Boolean NotifyObservers()  
        {  
            AdminGmailTDG adminGmailTDG = new AdminGmailTDG();
             adminGmailTDG.find();
            Notify();
        return true; 
        }  
}  
}