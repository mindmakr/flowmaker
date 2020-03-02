using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Flowmaker.Nats;
using NATS.Client;
using NATS.Client.Rx;
using NATS.Client.Rx.Ops;

namespace Flowmaker.CLI
{
    class Program
    {
        static void Main(string[] args)
        {
            var fm = new FlowmakerConnection();
            var task = fm.GetTask("happydays");
            task.Subscribe();
            Thread.Sleep(500);


            //var p = fm.GetTask();
            task.Send("Happy Days");
            task._exit = true;
            task.Send("Today is Monday");
            Console.ReadKey();
        }
    }
}
