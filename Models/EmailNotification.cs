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


        

        // public string SubjectName { get; set; } 

        public EmailNotification(){} 
  
        // public EmailNotification(string subjectName)  
        // {  
        //     SubjectName = subjectName;  
        //     SubjectState = "Created";  
        //     Console.WriteLine("Instantiated named Subject {0}", SubjectName);  
        // }  
  
        //public string SubjectState { get; set; }  
  
    
        public Boolean NotifyObservers()  
        {  
            Notify();
        return true; 
        }  
  
        // public void ModifySubjectStateOrData(string subjectStateOrData)  
        // {  
        //     //SubjectState = subjectStateOrData;  
        //     NotifyObservers();  
        // }   
}  
}