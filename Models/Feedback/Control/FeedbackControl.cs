using System;
using System.Collections;
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
      // FeedbackTDG1.getResolvedFeedback();
      List<string> arlist = FeedbackTDG1.getResolvedFeedback();
      Console.WriteLine(arlist.Count);
      Console.WriteLine(arlist[0]);
      
    }

    //update feedback status to db
    public FeedbackControl(string feedbackStatus)
    {
      //querying db
      FeedbackTDG1.getResolvedFeedback();
    }

    //insert Data
    public FeedbackControl(string type, string content, string email )
    {
      // change to switch case
      // create obj
      if (type == "Devices"){
        Devices fb = new Devices();
      
        foreach (Iinputs inputs in fb.Inputs)
        {
            inputs.feedbackContent(content);
        }
        //querying db (TM called TDG)
        FeedbackTDG1.insert(type, content, email);
      }
      else if (type == "Accounts"){
        FbAccount fb = new FbAccount();
        foreach (Iinputs inputs in fb.Inputs)
        {
            inputs.feedbackContent(content);
        }
        //querying db (TM called TDG)
        FeedbackTDG1.insert(type, content, email);
      }
      else if (type == "Connection"){
        Connection fb = new Connection();
        foreach (Iinputs inputs in fb.Inputs)
        {
            inputs.feedbackContent(content);
        }
       //querying db (TM called TDG)
        FeedbackTDG1.insert(type, content, email);
      }
      return;
    }
  }
}