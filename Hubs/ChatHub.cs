using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using  ICT_2106.Models;

namespace SignalRChat.Hubs
{
    public class ChatHub : Hub
    {
        
        public async Task SendMessage(string user, string message)
        {
            Clients.All.SendAsync("ReceiveMessage", user, message); 
            Bot botspeaking = new Bot(message);
            
            Clients.All.SendAsync("ReceiveMessage", "Bot", "lol"); 
            
        
        }
    }
}