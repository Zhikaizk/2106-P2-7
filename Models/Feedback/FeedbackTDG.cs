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
        public static void InsertData()
        {
            using (var context = new FeedbackContext())
            {
                // Creates the database if not exists
                context.Database.EnsureCreated();

                //insert feedback to db
                context.Feedback.Add(new FeedbackTableModule
                {
                    FeedbackContent = "i am facing",
                    FeedbackType = "Devices",
                    FeedbackStatus = "pending",
                    HouseholdEmail = "jialin@gmail.com"
                });

                // Saves changes
                context.SaveChanges();
            }
        }
        // retrieve all feedback
        public static void PrintData()
        {
            // Gets and prints all books in database
            using (var context = new FeedbackContext())
            {
                
                var datas = context.Feedback;
                foreach (var data1 in datas)
                {
                    // var data = new StringBuilder();
                    var data = new StringBuilder();
                    data.AppendLine($"Id: {data1.FeedbackId}");
                    data.AppendLine($"Type: {data1.FeedbackType}");
                    data.AppendLine($"Status: {data1.FeedbackStatus}");
                    data.AppendLine($"Content: {data1.FeedbackContent}");
                    data.AppendLine($"Email: {data1.HouseholdEmail}");
                    Console.WriteLine(data.ToString());
                    // Console.WriteLine(data.ToString());
                  
                }
            }
        }
        // retrieve pending feedback
        // retrieve resolved feedback
    }
    
}