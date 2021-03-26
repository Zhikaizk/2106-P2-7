  
using System;
using System.Collections.Generic;
 
namespace Project.Models.Feedback
{
  //'SoftwareConcreteCreator' class (create the objects)
  // inherits Feedback class
  class Connection : Feedback
  {
    // Factory Method implementation
    public override void createFeedback()
    {
        Inputs.Add(new Content());
    }
  }
}
 