using System;
namespace Project.Models.Notification
{
 
 public class Email : IEmail  
 {
private EmailNotification _emailNotification;  
public Email(string observerName)  
{  
    updatecontent = observerName;  
}  

public Email()
{}
  
public string updatecontent { get; set; }  
public string emailaddress { get; set; } 
  
public void Subscribe(EmailNotification emailNotification)  
{  
    _emailNotification = emailNotification;  
    emailNotification.Subscribe(this);  
}  
  
public void Unsubscribe()  
{  
    _emailNotification.Unsubscribe(this);  
}  
  
public void UpdateObserver()  
{  
    Console.WriteLine("{0} received the notification",updatecontent);  
}  
}
}
 