using System;
using System.Collections.Generic;
 
namespace Project.Models.Feedback
{
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
 
 