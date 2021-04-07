using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.SignalR;
using System.Text.Json;
using System.IO;

namespace ICT_2106.Models
{
    

    public class Bot  : Hub
    {
        private string testing;
        private string botname="BotKai";

          public string tag { get; set; }
    public string[] patterns { get; set; }
    public string[] responses { get; set; }
    public string context_set{ get; set; }

        public Bot()
        {
            Console.WriteLine("Created");
        }

        public Bot(string message)
        {
            // save the address for later
           this.testing = message;
           string jsonString = File.ReadAllText("intents.json");
           Bot test=JsonSerializer.Deserialize<Bot>(jsonString);
           Console.WriteLine(test.context_set);
        }

    }
}