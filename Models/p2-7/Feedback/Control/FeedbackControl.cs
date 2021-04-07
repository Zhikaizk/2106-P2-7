using System;
using System.Collections;
using System.Collections.Generic;
using Project.Models.Notification;
namespace Project.Models.Feedback

{
    // control class for feedback system
    public class FeedbackControl
    {
        private IEmail emailnotification;

        public FeedbackControl()
        {
        }

        //insert Data
        public FeedbackControl(string type, string content, string email)
        {
            // create obj
            switch (type)
            {
                case "Devices":
                    Feedback dev = new Devices();
                    dev.IHHouseholdEmail(email);
                    foreach (Iinputs inputs in dev.Inputs)
                    {
                        inputs.feedbackContent(content);
                        //querying db (TM called TDG)
                        FeedbackTDG.insert(dev.GetType().Name, inputs.retrieveContent(), dev.retrieveHouseholdEmail());
                    }
                    break;
                case "Connection":
                    Feedback conn = new Connection();
                    conn.IHHouseholdEmail(email);
                    foreach (Iinputs inputs in conn.Inputs)
                    {
                        inputs.feedbackContent(content);
                         //querying db (TM called TDG)
                        FeedbackTDG.insert(conn.GetType().Name,  inputs.retrieveContent(), conn.retrieveHouseholdEmail());
                    }
                    break;
                default: // set default as "Accounts"
                    Feedback acc = new FbAccount();
                    acc.IHHouseholdEmail(email);
                    foreach (Iinputs inputs in acc.Inputs)
                    {
                        inputs.feedbackContent(content);
                        //querying db (TM called TDG)
                        FeedbackTDG.insert(acc.GetType().Name, inputs.retrieveContent(), acc.retrieveHouseholdEmail());
                    }
                    break;
            }
            return;
        }

        // send out email
        // update database
        public FeedbackControl(string subject, string content, int feedbackId, string feedbackStatus, string email)
        {

            FeedbackTDG.updateStatus(feedbackStatus, feedbackId);
           
            this.emailnotification = new Email(email);
            //can only access to whatever was implemented in the interface.
            // my Email have Subscribe and unSubscribe but IEmail don't allow others to access it.
            emailnotification.Update(subject,content);
            EmailNotification notification = new EmailNotification();
            notification.Attach(emailnotification);
            Boolean results = notification.NotifyObservers();

        }
    }
}