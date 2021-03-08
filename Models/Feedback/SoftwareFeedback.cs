  
using System;
using System.Collections.Generic;
 
namespace Project.Models.Feedback
{//'SoftwareConcreteCreator' class (create the objects)
  // inherits Feedback class
  class Software : Feedback

  {
    // Factory Method implementation

    public override void CreateFeedback()
    {
        Inputs.Add(new Content());
        
    }
  }
}
 