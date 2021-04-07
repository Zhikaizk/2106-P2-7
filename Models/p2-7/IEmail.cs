using System;

namespace Project.Models.Notification
{
    public interface IEmail
    {
         //this will be change to UnSubscribe (String email)
         // this will be change to Subscribe(String email); 
        void Update(string subject,string message);
        public String updateContent{get;set;}
        public String emailAddress{get;set;}
         public String updateSubject{get;set;}

    }
}
