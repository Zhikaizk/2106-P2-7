using System;
using System.Collections.Generic;
 
namespace Project.Models.Feedback
{
 
  /// The 'Inputs' interface
  public interface Iinputs

  {
    void feedbackContent(String content);
  }
 
  /// A 'ContentProduct' (entity class thats implements Inputs)
  class Content : Iinputs
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
 
  //'SoftwareConcreteCreator' class (create the objects)
  // inherits Feedback class
  class Software : Feedback

  {
    // Factory Method implementation

    public override void CreateFeedback()
    {
        Inputs.Add(new Content());
        
    }
  }
 
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

  // control class for feedback system
  class FeedbackControl {
    public FeedbackControl(String type, String content){
      if (type.Equals("software")){

            Software fb = new Software();
            Console.WriteLine("\n" + fb.GetType().Name + "--");
            foreach (Iinputs inputs in fb.Inputs)
            {
                inputs.feedbackContent(content);
            }
      }
      else if (type.Equals("hardware")){
           Hardware fb = new Hardware();
            Console.WriteLine("\n" + fb.GetType().Name + "--");
            foreach (Iinputs inputs in fb.Inputs)
            {
                inputs.feedbackContent(content);
            }
      }
      else{
        Console.WriteLine("continue");
      }

    }
  }
}
 
 