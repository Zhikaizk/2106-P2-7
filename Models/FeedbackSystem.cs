using System;
using System.Collections.Generic;
 
namespace Project.Models.Feedback
{
 
  /// The 'Inputs' interface
  public interface  Inputs

  {
    void feedbackContent(String content);
  }
 
  /// A 'ContentProduct' (entity class thats implements Inputs)
  class Content : Inputs
  {
      private String content;
      private String getContent(){
          return this.content;
      }
      private void setContent(String content){
          this.content = content;
      }


      
    public void feedbackContent(String content){
        if (this.content is null){
            setContent(content);
            Console.WriteLine(getContent());
        }
        else{
            Console.WriteLine(getContent());
        }
        

    }
  }
 
  /// The 'FeedbackCreator' abstract class
  abstract class Feedback
  { 
    private List<Inputs> inputs = new List<Inputs>();
 
    // Constructor calls abstract Factory method

    public Feedback()
    {
      this.CreateFeedback();
    }
 
    public List<Inputs> Inputs
    {
      get { return inputs; }
    }
 
    // Factory Method
    public abstract void CreateFeedback();
  }
 
  //'SoftwareConcreteCreator' class (create the objects)
  class Software : Feedback

  {
    // Factory Method implementation

    public override void CreateFeedback()
    {
        Inputs.Add(new Content());
        
    }
  }
 
  //  'HardwareConcreteCreator' class
  class Hardware : Feedback

  {
    // Factory Method implementation

    public override void CreateFeedback()
    {
        Inputs.Add(new Content());
        
    }
  }
}
 
 