using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using EFCoreSample;
using System.Text;

namespace EFCoreSample
{
    public class FeedbackTDG{
        // insert feedback
        public static void insertData(String feedbackType, String feedbackContent)
        {
            using (var context = new FeedbackContext())
            {
                // Creates the database if not exists
                context.Database.EnsureCreated();

                //insert feedback to db
                context.Feedback.Add(new FeedbackTableModule
                {
                    feedbackContent = feedbackContent,
                    feedbackType = feedbackType,
                    feedbackStatus = "pending",
                    householdEmail = "jialin@gmail.com"
                });

                // Saves changes
                context.SaveChanges();
            }
        }
        // retrieve all feedback
        public static void printData()
        {
            // Gets and prints all books in database
            using (var context = new FeedbackContext())
            {
                
                var datas = context.Feedback;
                foreach (var data1 in datas)
                {
                    // var data = new StringBuilder();
                    var data = new StringBuilder();
                    data.AppendLine($"Id: {data1.feedbackId}");
                    data.AppendLine($"Type: {data1.feedbackType}");
                    data.AppendLine($"Status: {data1.feedbackStatus}");
                    data.AppendLine($"Content: {data1.feedbackContent}");
                    data.AppendLine($"Email: {data1.householdEmail}");
                    Console.WriteLine(data.ToString());
                  
                }
            }
        }
        // retrieve pending feedback
        // retrieve resolved feedback
    }
    
}