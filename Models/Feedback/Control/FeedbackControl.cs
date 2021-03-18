using System;
using System.Collections.Generic;
 
namespace Project.Models.Feedback
{
  // control class for feedback system
  public class FeedbackControl 
  {
    //retrieve Data
    public FeedbackControl()
    {

      //querying db (call data gateway to getAllFeedback, return as a list of arrays)
      // FeedbackTM.getAllFeedback();

      Devices objCreated = new Devices();
      objCreated.insertDetails(1, "pending", "jialin@gmail.com");
      // Devices fb = new Devices();
      foreach (Iinputs inputs in objCreated.Inputs)
      {
          inputs.feedbackContent("facing issues");
      }
      objCreated.printDetails();

    }
    //update feedback status to db
    public FeedbackControl(string feedbackStatus)
    {
      //querying db
    }

    //insert Data
    public FeedbackControl(string type, string content, string email )
    {
      //create obj
      if (type == "Devices"){
        Devices fb = new Devices();
        foreach (Iinputs inputs in fb.Inputs)
        {
            inputs.feedbackContent(content);
        }
        //querying db
        FeedbackTDG1.insert(type, content, email);
      }
      else if (type == "Accounts"){
        Account fb = new Account();
        foreach (Iinputs inputs in fb.Inputs)
        {
            inputs.feedbackContent(content);
        }
        //querying db
        FeedbackTDG1.insert(type, content, email);
      }
      else if (type == "Connection"){
        Connection fb = new Connection();
        foreach (Iinputs inputs in fb.Inputs)
        {
            inputs.feedbackContent(content);
        }
        //querying db
        FeedbackTDG1.insert(type, content, email);
      }
      return;
    }
  }
}