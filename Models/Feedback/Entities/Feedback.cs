using System;
using System.Collections.Generic;
using Project.Models.Notification;

namespace Project.Models.Feedback
{
    abstract class Feedback : Household, IFeedback
    {
        private string inputs;
        private string feedbackStatus;
        private Household household;
        private string householdEmail;

        // inputsHandling
        private void setinputs(string inputs)
        {
            this.inputs = inputs;
        }
        public void IHInputs(string inputs)
        {
            setinputs(inputs);
        }
        private string getInputs()
        {
            return this.inputs;
        }
        public string retrieveInputs()
        {
            return getInputs();
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

