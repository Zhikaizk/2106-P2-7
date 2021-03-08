using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using EFCoreSample;
namespace Project
{
    public class Program
    {

        public static void Main(string[] args)
        { 
            CreateHostBuilder(args).Build().Run();
            // FeedbackTDG.InsertData();
            // FeedbackTDG.PrintData();
            //FeedbackControl fc = new FeedbackControl("software", "i am facing an issue");
           
        }
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });

    }
}
