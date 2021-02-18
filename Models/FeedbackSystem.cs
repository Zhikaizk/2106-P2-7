using System;
using System.Collections.Generic;
 
namespace Project.Models.Feedback
{
 
  // /// The 'Inputs' interface
  // public interface Iinputs

  // {
  //   void feedbackContent(String content);
  // }
 
  /// A 'ContentProduct' (entity class thats implements Inputs)
 
  /// The 'FeedbackCreator' abstract class
  abstract class Feedback
  { 
    private List<Iinputs> inputs = new List<Iinputs>();
 
    // Constructor calls abstract Factory method

    public Feedback()
    {
      this.CreateFeedback();
    }

    public List<Iinputs> Inputs
    {
      get { return inputs; }
    }

  
    // Factory Method
    public abstract void CreateFeedback();
  }
 


 
}
 
 