using System;
using System.Collections.Generic;
using Project.Models.Notification;

namespace Project.Models.Feedback
{
    abstract class Feedback : Household, IFeedback
    {
        private string inputs;
        private string feedbackStatus;
        private IEmail sentEmail;
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

        // housholdEmailHandling
        // private void setEmail(string email)
        // {
        //     household.email = email;
        // }
        // public void IHEmail(string email)
        // {
        //     setEmail(email);
        // }
        // public string retrieveEmail()
        // {
        //     return household.email;
        // }

        // Sending of Email
        public void on()
        {
            this.sentEmail = new Email(householdEmail);
            //can only access to whatever was implemented in the interface.
            // my Email have Subscribe and unSubscribe but IEmail don't allow others to access it.
            sentEmail.Update("SUBJECTHERE",inputs);
            EmailNotification notification = new EmailNotification();
            notification.Attach(sentEmail);
            Boolean results = notification.NotifyObservers();
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

