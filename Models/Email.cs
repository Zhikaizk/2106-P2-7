using System;
using System.Collections.Generic;
namespace Project.Models.Notification
{
 
 public class Email : IEmail  
 {
private EmailNotification _emailNotification;  
public Email(string emailcontent)  
{  
    updatecontent = emailcontent;

}  
public Email(string observerName,string emailcontent)  
{  
    emailaddress = observerName;  
    updatecontent = emailcontent;
}  

public Email()
{}

public string updatecontent { get; set; }  
public string emailaddress { get; set; } 
  
// public void Subscribe(EmailNotification emailNotification)  
// {  
    
//     _emailNotification = emailNotification;  
//     emailNotification.Subscribe(this);  
// } 
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
    Console.WriteLine("this is my testing");
}  
}
}
 