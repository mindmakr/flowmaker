using System;
using System.Text;
using Flowmaker.Nats;

namespace Flowmaker.TestClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var fm = new FlowmakerConnection();
            var task = fm.GetClient("App.Channels.A");
            task.Send(Encoding.UTF8.GetBytes("Client is saying Hello"));
            task.Send(Encoding.UTF8.GetBytes("World"));
        }

    }
}
