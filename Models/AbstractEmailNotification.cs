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
        private readonly string gmailuserid = "ict2106t7@gmail.com";


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
                smtp.Credentials = new NetworkCredential(gmailuserid, EncryptedAdminGmailSingleton.GetInstance().decryptedpasswordDone());
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Send(message);
            }
        }


// private ICollection<IPasswordRest> PWDlisteners;
        protected void NotifyPassword(String householdEmailDetails, String passwordResetId)
        {
            Console.WriteLine("after notify password Email Endedhere");

            // foreach (IEmail listener in listeners)
                        foreach (IEmail listener in listeners)

            {
                Console.WriteLine("inside for loop notify password Email Endedhere");

                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();
                message.From = new MailAddress(gmailuserid);
                Console.WriteLine("before household add Email Endedhere");
                message.To.Add(new MailAddress(householdEmailDetails));
                Console.WriteLine("after household add Email Endedhere");
                Console.WriteLine(householdEmailDetails);

                message.Subject = "Reset Password";
                message.IsBodyHtml = true; //to make message body as html  
                message.Body = "This is the link to reset password " + "://" + smtp.Host + ":" + smtp.Port + "/ResetPasswordPage" + passwordResetId + householdEmailDetails;
                Console.WriteLine(message.Body + "after create message body Email Endedhere");

                smtp.Port = 587;
                smtp.Host = "smtp.gmail.com"; //for gmail host  
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(gmailuserid, EncryptedAdminGmailSingleton.GetInstance().decryptedpasswordDone());
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                Console.WriteLine("after delivery method Email Endedhere");

                smtp.Send(message);
                Console.WriteLine("after send message Email Endedhere");

            }
            Console.WriteLine("out of for loop Email Endedhere");

        }

    }
}