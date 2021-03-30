using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Net;


namespace Project.Models.Notification
{
    public class AbstractEmailNotification
    {
          // the list of services to be sent notifications
        private ICollection<IEmail> listeners;
            private readonly string gmailuserid="ict2106t7@gmail.com";


        // constructor
        public AbstractEmailNotification()
        {
            // start with an empty list of services
            listeners = new List<IEmail>();
        }

        // register a message service
        public void Attach(IEmail listener)
        {
            listeners.Add(listener);
        }

        // de-register a message service
        public void Detach(IEmail listener)
        {
            listeners.Remove(listener);
        }

        // notify all message services
        protected void Notify()
        {
            foreach (IEmail listener in listeners)
            {

        MailMessage message = new MailMessage();  
        SmtpClient smtp = new SmtpClient();  
        message.From = new MailAddress(gmailuserid);  
        message.To.Add(new MailAddress(listener.emailaddress));  
        message.Subject = "System updates";  
        message.IsBodyHtml = true; //to make message body as html  
        message.Body = listener.updatecontent;  
        smtp.Port = 587;  
        smtp.Host = "smtp.gmail.com"; //for gmail host  
        smtp.EnableSsl = true;  
        smtp.UseDefaultCredentials = false;  
        smtp.Credentials = new NetworkCredential(gmailuserid,EncryptedAdminGmailSingleton.GetInstance().decryptedpasswordDone());  
        smtp.DeliveryMethod = SmtpDeliveryMethod.Network;  
        smtp.Send(message);    
            }
        }
    }
    }