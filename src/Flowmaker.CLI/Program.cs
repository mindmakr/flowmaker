using System;
using System.Text;
using Flowmaker.Contracts.Nats;
using Flowmaker.Nats;


namespace Flowmaker.CLI
{
    class Program
    {
        static void Main(string[] args)
        {
            var fm = new FlowmakerConnection();
            //var task = fm.GetChannel(new MyJob(), "App.Channels.A");
            var channel = fm.GetChannel("App.Channels.A", (msg) => Work(msg));
            channel.Send(Encoding.UTF8.GetBytes("Happy Days"));
            channel.Send(Encoding.UTF8.GetBytes("Today is Monday"));
            Console.ReadKey();
        }

        public static bool Work(byte[] data)
        {
            LogMessage(Encoding.UTF8.GetString(data));
            return true;
        }

        public static void LogMessage(byte[] payload)
        {
            var message = Encoding.UTF8.GetString(payload);
            Console.WriteLine($"{DateTime.Now.ToString("HH:mm:ss.fffffff")} - {message}");
        }

        public static void LogMessage(string message)
        {
            Console.WriteLine($"{DateTime.Now.ToString("HH:mm:ss.fffffff")} - {message}");
        }
    }

    class MyJob : IFlowmakerJob
    {
        public bool Execute(byte[] data)
        {
            Program.LogMessage(Encoding.UTF8.GetString(data));
            return true;
        }
    }
}
