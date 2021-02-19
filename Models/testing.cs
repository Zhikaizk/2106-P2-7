using System;
using System.Collections.Generic;
namespace Project.Models.Notification
{

 public  class testing   {
     private IEmail email;
     public void on(){
         this.email= new Email();
         //can only access to whatever was implemented in the interface.
         // my Email have Subscribe and unSubscribe but IEmail don't allow others to access it.
         email.UpdateObserver();
         //this is where another componment will use //this is an exmaple first
         //email.Subscribe(EmailNotification testing);         
     }     
 }
}