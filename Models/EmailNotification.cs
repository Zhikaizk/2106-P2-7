using System;
using System.Collections;
using System.Collections.Generic;
using Project.Models.Notification;
using System.Net.Mail;
using System.Net;

namespace Project.Models.Notification
{

    public class EmailNotification   
    {  
            private readonly string gmailuserid="leongzhikaii@gmail.com";
            private readonly string gmailpassword="thisonereemmber";

        private readonly List<Email> _observers = new List<Email>();
        

        // public string SubjectName { get; set; } 

        public EmailNotification(){} 
  
        // public EmailNotification(string subjectName)  
        // {  
        //     SubjectName = subjectName;  
        //     SubjectState = "Created";  
        //     Console.WriteLine("Instantiated named Subject {0}", SubjectName);  
        // }  
  
        //public string SubjectState { get; set; }  
  
        public void Subscribe(Email observer)  
        {  
            _observers.Add(observer);  
        
        }  
  
        public void Unsubscribe(Email observer)  
        {  
            _observers.Remove(observer);  
           
        }  
  
        public Boolean NotifyObservers()  
        {  
            foreach (Email observer in _observers)  
            {  
                //observer.UpdateObserver();
                 MailMessage message = new MailMessage();  
        SmtpClient smtp = new SmtpClient();  
        message.From = new MailAddress(gmailuserid);  
        message.To.Add(new MailAddress(observer.emailaddress));  
        message.Subject = "System updates";  
        message.IsBodyHtml = true; //to make message body as html  
        message.Body = observer.updatecontent;  
        smtp.Port = 587;  
        smtp.Host = "smtp.gmail.com"; //for gmail host  
        smtp.EnableSsl = true;  
        smtp.UseDefaultCredentials = false;  
        smtp.Credentials = new NetworkCredential(gmailuserid,gmailpassword);  
        smtp.DeliveryMethod = SmtpDeliveryMethod.Network;  
        smtp.Send(message);    
            } 
        return true; 
        }  
  
        // public void ModifySubjectStateOrData(string subjectStateOrData)  
        // {  
        //     //SubjectState = subjectStateOrData;  
        //     NotifyObservers();  
        // }   
}  
}