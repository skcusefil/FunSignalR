using FunSignalR.Shared.Models;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunSignalR.Shared.SignalRClient
{
    public class ShapeHubClient
    {
        private HubConnection? _hubConnection;

        public delegate void ShapeEventHandler(object sender, ShapeEventArgs e);
        public event ShapeEventHandler ShapeRecieve;

        public delegate void ShapeNewPositionEventHandler(object sender, ShapeEventArgs e);
        public event ShapeEventHandler ShapeRecieveNewPosition;
        public ShapeHubClient(Uri uri)
        {
            _hubConnection = new HubConnectionBuilder()
                              .WithUrl(uri)
                              .Build();

            _hubConnection.On<Shape>("ReceiveShape", (shape) =>
            {
                OnShapeRecieve(new ShapeEventArgs(shape));
            });

            _hubConnection.On<Shape>("ReceiveNewPosition", (shape) =>
            {
                OnShapeRecieveNewPosition(new ShapeEventArgs(shape));
            });
        }

        public async Task StartAsync() => await _hubConnection.StartAsync();

        protected virtual void OnShapeRecieve(ShapeEventArgs e)
        {
            ShapeRecieve?.Invoke(this, e);
        }

        protected virtual void OnShapeRecieveNewPosition(ShapeEventArgs e)
        {
            ShapeRecieveNewPosition?.Invoke(this, e);
        }

        public async Task SendShape(Shape shape)
        {
            if (_hubConnection is not null)
            {
                await _hubConnection.SendAsync("SendShape", shape);
            }
        }

        public async Task UpdateShapePosition(Shape shape)
        {
            if (_hubConnection is not null)
            {
                await _hubConnection.SendAsync("UpdateShapePosition", shape);
            }
        }

        public async Task DisposeAsync() {

            await _hubConnection.DisposeAsync();
        }

    }

    public class ShapeEventArgs : EventArgs
    {
        public Shape Shape { get; set; }

        public ShapeEventArgs(Shape shape)
        {
            Shape = shape;
        }
    }
}
