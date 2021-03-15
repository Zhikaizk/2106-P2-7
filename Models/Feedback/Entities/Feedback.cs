using System;
using System.Collections.Generic;

namespace Project.Models.Feedback
{
    abstract class Feedback
    {
      private List<Iinputs> inputs = new List<Iinputs>();
      private int feedbackId;
      private string feedbackStatus;
      private string householdEmail;
      
      //getters and setters for variables
      private int getFeedbackId()
      {
          return this.feedbackId;
      }
      private void setFeedbackId(int feedbackId)
      {
          this.feedbackId = feedbackId;
      }
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
      public void insertDetails(int feedbackId, string feedbackStatus, string householdEmail){
        setFeedbackId(feedbackId);
        setFeedbackStatus(feedbackStatus);
        setHouseholdEmail(householdEmail);

      }

      public void printDetails(){
        int id = getFeedbackId();
        string status = getFeedbackStatus();
        string email = getHouseholdEmail();
        Console.WriteLine("ID: " + id + "\nStatus:  " + status + "\nEmail: " + email);
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

