using System;
using System.Collections;
using System.Collections.Generic;
using Project.Models.Notification;

namespace Project.Models.Notification
{
    public class EmailControl    
    {  
        private Boolean results;
        private List<IEmail> allHouseholdEmails = new List<IEmail>();
        
        //String emailaddress this is for backup just in case input needed
        public String Success_or_Not(){
            if(results == true){
                return "All email have been sent successfully";
            }else{
                return "Error encountered, Please try again";
            }
        }
        public EmailControl (String emailcontenthere)
        {
            results=Softwareupdate(emailcontenthere);
        }
        ///String emailaddresses this is for backup just in case got input needede
        private Boolean Softwareupdate(String emailcontenthere)
        {
            
            //This is where i collect lal the household email
             EmailTDG emailtdg = new EmailTDG();
             allHouseholdEmails=emailtdg.find(); 
            EmailNotification notification = new EmailNotification();
                        //Attach the content to all the emails.
                        foreach (var email in allHouseholdEmails)
                {
                    email.Update(emailcontenthere);
                    notification.Attach(email);

                } 
            Boolean results= notification.NotifyObservers();
            return results; 
              
        }


private Boolean emailResetPassword;

        public EmailControl(String householdEmailDetails, String passwordResetId)
        {
            Console.WriteLine("email control Endedhere");
            emailResetPassword = emailReset(householdEmailDetails, passwordResetId);
        }


        private Boolean emailReset(String householdEmailDetails, String passwordResetId)
        {
            EmailTDG emailtdg = new EmailTDG();
            emailtdg.find();
            Console.WriteLine("Password Email Endedhere");
            Email email = new Email();
            Console.WriteLine("email reset Email Endedhere");
            EmailNotification notification = new EmailNotification();
            Console.WriteLine("email notification Email Endedhere");
            notification.Attach(email);
            Console.WriteLine("email notificication notification attach Email Endedhere");
            Boolean emailResetPassword = notification.NotifyResetPassword(householdEmailDetails, passwordResetId);
            Console.WriteLine("email boolean Email Endedhere");
            return emailResetPassword;

        }

    }
}