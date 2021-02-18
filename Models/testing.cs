using System;
using System.Collections.Generic;
namespace Project.Models.Notification
{

 public  partial class testing   {
     private IEmail email;
     public void on(){
         this.email= new Email();
         email.UpdateObserver();
         //this is where another componment will use //this is an exmaple first
         //email.Subscribe(EmailNotification testing);
         
     }
     

 }
}