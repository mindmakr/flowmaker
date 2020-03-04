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
            for (int i = 0; i < 100; i++)
            {
                task.Send(Encoding.UTF8.GetBytes($"Client Message {i}"));
            }
        }

    }
}
