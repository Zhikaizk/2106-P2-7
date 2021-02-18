 using System;
using System.Collections.Generic;
 
namespace Project.Models.Feedback
{
 // control class for feedback system
  class FeedbackControl {
    public FeedbackControl(String type, String content){
      String feedbackType = type;
      String feedbackContent = content;
      if (feedbackType == "Software"){

        Software fb = new Software();
        Console.WriteLine("\n" + fb.GetType().Name + "--");
        foreach (Iinputs inputs in fb.Inputs)
        {
            inputs.feedbackContent(feedbackContent);
        }
      }
      else if (feedbackType == "Hardware"){
        Hardware fb = new Hardware();
        Console.WriteLine("\n" + fb.GetType().Name + "--");
        foreach (Iinputs inputs in fb.Inputs)
        {
            inputs.feedbackContent(feedbackContent);
        }
      }
      else if (feedbackType is null){
        // return to view when there is no input, to run the feedback.cshtml
        return;
      }

    }
  }
}