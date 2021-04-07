using System;
using System.Collections.Generic;
using Project.Models.Notification;

namespace Project.Models.Feedback
{
    abstract class Feedback : IFeedback
    {
        private List<Iinputs> inputs = new List<Iinputs>();
        // private string inputs;
        private string feedbackStatus;
        //private Household household;
        private string householdEmail;

        // inputsHandling
        public List<Iinputs> Inputs
        {
            get { return inputs; }
        }

        // emailHandling
        private void setHouseholdEmail(string householdEmail)
        {
            this.householdEmail = householdEmail;
        }
        public void IHHouseholdEmail(string householdEmail)
        {
            setHouseholdEmail(householdEmail);
        }
        private string getHouseholdEmail()
        {
            return this.householdEmail;
        }
        public string retrieveHouseholdEmail()
        {
            return getHouseholdEmail();
        }  

        // feedbackStatus handling
        private string getFeedbackStatus()
        {
            return this.feedbackStatus;
        }
        private void setFeedbackStatus(string feedbackStatus)
        {
            this.feedbackStatus = feedbackStatus;
        }

        // Constructor calls abstract Factory method
        public Feedback()
        {
            this.createFeedback();
        }

        // Factory Method
        public abstract void createFeedback();
    }
}

