using System;
using System.Text;
using System.Threading;
using Flowmaker.Nats;


namespace Flowmaker.CLI
{
    class Program
    {
        static void Main(string[] args)
        {
            var fm = new FlowmakerConnection();
            var task = fm.GetClient("App.Channels.A");
            task.Subscribe((msg) => Work(msg));
            Thread.Sleep(1000);
            task.Send(Encoding.UTF8.GetBytes("Happy Days"));
            task.Send(Encoding.UTF8.GetBytes("Today is Monday"));


            Console.ReadKey();
        }

        public static bool Work(byte[] data)
        {
            LogMessage(Encoding.UTF8.GetString(data));
            return false;
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
}
