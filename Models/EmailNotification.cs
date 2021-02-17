using System;
using System.Collections;
using System.Collections.Generic;
using Project.Models.Notification;

namespace Project.Models.Notification
{
    public class EmailNotification   
    {  
        private readonly List<IEmail> _observers = new List<IEmail>();

        public string SubjectName { get; set; } 

        public EmailNotification(){} 
  
        public EmailNotification(string subjectName)  
        {  
            SubjectName = subjectName;  
            SubjectState = "Created";  
            Console.WriteLine("Instantiated named Subject {0}", SubjectName);  
        }  
  
        public string SubjectState { get; set; }  
  
        public void Subscribe(IEmail observer)  
        {  
            _observers.Add(observer);  
            Console.WriteLine("Observer named {0} is now added to the {1}'s observers list and will receive notification when change happens to the subject {1} state", observer.updatecontent, SubjectName);  
        }  
  
        public void Unsubscribe(IEmail observer)  
        {  
            _observers.Remove(observer);  
            Console.WriteLine("Observer named {0} is removed from the {1}'s observers list and will no longer receive notification when change happens to the subject {1} state", observer.updatecontent, SubjectName);  
        }  
  
        public void NotifyObservers()  
        {  
            foreach (IEmail observer in _observers)  
            {  
                observer.UpdateObserver();  
            }  
        }  
  
        public void ModifySubjectStateOrData(string subjectStateOrData)  
        {  
            Console.WriteLine("{0} state changed from {1} to {2}", SubjectName, SubjectState, subjectStateOrData);  
            SubjectState = subjectStateOrData;  
            NotifyObservers();  
        }   
}  
}