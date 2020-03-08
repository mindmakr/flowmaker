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
            var channel = fm.GetChannel("App.Channels.A");
            for (int i = 0; i < 100; i++)
            {
                channel.Send(Encoding.UTF8.GetBytes($"Client Message {i}"));
            }
        }

    }
}
