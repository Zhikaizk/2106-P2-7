using System;
using System.Collections.Generic;

namespace Project.Models.Feedback
{
    abstract class Feedback : IFeedback
    {
      private List<Iinputs> inputs = new List<Iinputs>();

      private string feedbackStatus;
      private string householdEmail;

    //   private Household _household;
      
      //getters and setters for variables
     
      private string getFeedbackStatus()
      {
          return this.feedbackStatus;
      }
      private void setFeedbackStatus(string feedbackStatus)
      {
          this.feedbackStatus = feedbackStatus;
      }
      private string getHouseholdEmail()
      {
          return this.householdEmail;
      }
      private void setHouseholdEmail(string householdEmail)
      {
          this.householdEmail = householdEmail;
      }

      // information hiding 
      public void insertDetails(string feedbackStatus, string householdEmail){
        setFeedbackStatus(feedbackStatus);
        setHouseholdEmail(householdEmail);

      }

      public void printDetails(){
        string status = getFeedbackStatus();
        string email = getHouseholdEmail();
        Console.WriteLine("Status:  " + status + "\nEmail: " + email);
      }
      // Constructor calls abstract Factory method
      public Feedback()
      {
          this.createFeedback();
      }
      public List<Iinputs> Inputs
      {
          get { return inputs; }
      }
      // Factory Method
      public abstract void createFeedback();
    }
}

