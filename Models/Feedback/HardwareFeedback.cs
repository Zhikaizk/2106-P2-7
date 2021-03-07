  using System;
using System.Collections.Generic;
 
namespace Project.Models.Feedback
{
  //  'HardwareConcreteCreator' class
  // inherits Feedback class
  class Hardware : Feedback

  {
    // Factory Method implementation

    public override void CreateFeedback()
    {
        Inputs.Add(new Content());
        
    }
  }
}