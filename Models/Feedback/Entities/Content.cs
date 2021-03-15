using System;
using System.Collections.Generic;
 
namespace Project.Models.Feedback
{
 
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
            //testing purpose
            // Console.WriteLine(getContent());
        }
        else{
            //testing purpose
            // Console.WriteLine(getContent());
        }
        

    }
  }
}