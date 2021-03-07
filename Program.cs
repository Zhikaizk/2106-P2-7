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

namespace Project
{
    public class Program
    {
        public static void Main(string[] args)
        {
            InsertData();
            PrintData();
            //FeedbackControl fc = new FeedbackControl("software", "i am facing an issue");
            // CreateHostBuilder(args).Build().Run();
        }
             public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
        private static void InsertData()
        {
            using (var context = new FeedbackContext())
            {
                // Creates the database if not exists
                context.Database.EnsureCreated();
                context.Feedback.Add(new Feedback
                {
                    FeedbackContent = "The Lord of the Rings",
                    FeedbackType = "J.R.R. Tolkien",
                    FeedbackStatus = "English",
                    HouseholdEmail = "jialin@gmail.com"
                });

                // Saves changes
                context.SaveChanges();
            }
        }

        private static void PrintData()
        {
            // Gets and prints all books in database
            using (var context = new FeedbackContext())
            {
                
                var datas = context.Feedback;
                foreach (var data1 in datas)
                {
                    var data = new StringBuilder();
                    data.AppendLine($"Id: {data1.FeedbackId}");
                    data.AppendLine($"Type: {data1.FeedbackType}");
                    data.AppendLine($"Status: {data1.FeedbackStatus}");
                    data.AppendLine($"Content: {data1.FeedbackContent}");
                    data.AppendLine($"Email: {data1.HouseholdEmail}");
                    Console.WriteLine(data.ToString());
                }
            }
        }
   
    }
}
