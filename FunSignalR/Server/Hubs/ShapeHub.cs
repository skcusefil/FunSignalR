using FunSignalR.Shared.Models;
using Microsoft.AspNetCore.SignalR;

namespace FunSignalR.Server.Hubs
{
    public class ShapeHub : Hub
    {
        public async Task SendShape(Shape shape)
        {
            await Clients.All.SendAsync("ReceiveShape", shape);
        }

        public async Task UpdateShapePosition(Shape shape)
        {
            await Clients.All.SendAsync("ReceiveNewPosition", shape);
        }

        
    }
}
