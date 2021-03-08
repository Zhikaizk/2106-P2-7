using System;
using System.Collections.Generic;
using EFCoreSample;
 
namespace Project.Models.Feedback
{
 // control class for feedback system
  public class FeedbackControl {

    //retrieve Data
    public FeedbackControl(){
      //querying db
      // FeedbackTDG.printData();
    }

    //insert Data
    public FeedbackControl(String type, String content){

      //querying db
      FeedbackTDG.insertData(type, content);

      String feedbackType = type;
      String feedbackContent = content;
      
      //create obj
      if (feedbackType == "Devices"){
        Devices fb = new Devices();
        // Console.WriteLine("\n" + fb.GetType().Name + "--");
        foreach (Iinputs inputs in fb.Inputs)
        {
            inputs.feedbackContent(feedbackContent);
        }
      }
      else if (feedbackType == "Account"){
        Account fb = new Account();
        // Console.WriteLine("\n" + fb.GetType().Name + "--");
        foreach (Iinputs inputs in fb.Inputs)
        {
            inputs.feedbackContent(feedbackContent);
        }
      }
      else if (feedbackType == "Connection"){
        Connection fb = new Connection();
        // Console.WriteLine("\n" + fb.GetType().Name + "--");
        foreach (Iinputs inputs in fb.Inputs)
        {
            inputs.feedbackContent(feedbackContent);
        }
        return;
      }

    }
  }
}