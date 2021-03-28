using System;
using System.Collections;
using System.Collections.Generic;

namespace Project.Models.Feedback
{
    // control class for feedback system
    public class FeedbackControl
    {
        //retrieve Data (default: All)
        public FeedbackControl()
        {
            //querying db (call data gateway to findAll, return as a list of lists)
            List<List<string>> arList = FeedbackTDG1.findAll();
            //testing
            Console.WriteLine(arList.Count);

            for (int i = 0; i < arList.Count; i++)
            {
                Console.WriteLine("----------");
                Console.WriteLine(arList[i][0]);
                Console.WriteLine(arList[i][1]);
                Console.WriteLine(arList[i][2]);
                Console.WriteLine(arList[i][3]);
                Console.WriteLine(arList[i][4]);
   
            }
        }

        public FeedbackControl(int fbType)
        {
            // calling TDG
            switch (fbType)
            {
                case 1:
                    List<List<string>> all = FeedbackTDG1.findAll();
                    //testing
                    Console.WriteLine(all.Count);
                    break;
                case 2:
                    List<List<string>> resolved = FeedbackTDG1.getResolvedFeedback();
                    //testing
                    Console.WriteLine(resolved.Count);
                    // getting all values
                    foreach (var list in resolved)
                    {
                        foreach (var value in list)
                        {
                            Console.WriteLine(value);
                        }
                    }
                    break;

                default: // set default as 3
                    List<List<string>> pending = FeedbackTDG1.getPendingFeedback();
                    //testing
                    Console.WriteLine(pending.Count);
                    break;
            }
        }

        //update feedback status to db
        public FeedbackControl(string feedbackStatus)
        {
            //querying db
            FeedbackTDG1.getResolvedFeedback();
        }

        //insert Data
        public FeedbackControl(string type, string content, string email)
        {
            // create obj
            switch (type)
            {
                case "Devices":
                    Devices dev = new Devices();

                    foreach (Iinputs inputs in dev.Inputs)
                    {
                        inputs.feedbackContent(content);
                    }
                    //querying db (TM called TDG)
                    FeedbackTDG1.insert(type, content, email);
                    break;
                case "Connection":
                    Connection conn = new Connection();
                    foreach (Iinputs inputs in conn.Inputs)
                    {
                        inputs.feedbackContent(content);
                    }
                    //querying db (TM called TDG)
                    FeedbackTDG1.insert(type, content, email);
                    break;

                default: // set default as "Accounts"
                    FbAccount acc = new FbAccount();
                    foreach (Iinputs inputs in acc.Inputs)
                    {
                        inputs.feedbackContent(content);
                    }
                    //querying db (TM called TDG)
                    FeedbackTDG1.insert(type, content, email);
                    break;
            }
            return;
        }
    }
}