using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace Presentation.Hubs
{
    public class MessageHub : Hub
    {
        // Broadcast para todos os jogadores
        public async Task Send(string name, string message)
        {
            await Clients.All.SendAsync("broadcastMessage", name, message);
        }
    }
}