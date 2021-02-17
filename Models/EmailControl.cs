using System;
using System.Collections;
using System.Collections.Generic;
using Project.Models.Notification;

namespace Project.Models.Notification
{
    public class EmailControl   
    {  
        private Boolean results;
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
            EmailNotification S1 = new EmailNotification();  
            //here will have the whole list of emails when retrieved from database
            //the emails can use subscribe and notifyobservers all at one go
            Email O1 = new Email("leongzhikaii@gmail.com",emailcontenthere);  
            Email O2 = new Email("gameboys96@live.com",emailcontenthere);  
            O1.Subscribe(S1);
            O2.Subscribe(S1);  
            Boolean results=S1.NotifyObservers(); 
            return results; 
              
        }
}  
}