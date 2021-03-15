using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Project.Models.Feedback;

namespace Project
{
    public class Program
    {

        public static void Main(string[] args)
        { 
            
            CreateHostBuilder(args).Build().Run();
            // FeedbackTDG.InsertData();
            // FeedbackTDG.PrintData();
            // FeedbackControl fc = new FeedbackControl();
           
        }
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });

    }
}
