using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Project.Models.Feedback;

namespace Project
{
    public class Program
    {
        public static void Main(string[] args)
        {

           List<Feedback> count_fb = new List<Feedback>();
            count_fb.Add(new Software());

            // Display document page
            foreach (var fb in count_fb)
            {
                Console.WriteLine("\n" + fb.GetType().Name + "--");
                foreach (Inputs inputs in fb.Inputs)
                {
                    inputs.feedbackContent("jialin");
                }
            }

            //CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
