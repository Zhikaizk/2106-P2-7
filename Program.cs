using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Project.Models.Notification;
namespace Project
{
    public class Program
    {
        public static void Main(string[] args)
        {
       // CreateHostBuilder(args).Build().Run();
        EmailNotification S1 = new EmailNotification("S1");  
        Email O1 = new Email("O1");  
        Email O2 = new Email("O2");  
  
        O1.Subscribe(S1);  
        O2.Subscribe(S1);  
        S1.ModifySubjectStateOrData("Approved");  
        Console.WriteLine();  
  
        O2.Unsubscribe();  
        S1.ModifySubjectStateOrData("Implemented");  
  
        Console.ReadLine();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
