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
            fm.GetConsumer().Do();
            Thread.Sleep(500);
            var p = fm.GetPublisher();
            p.Do("Happy Days");
            p.Do("Today is Monday");
            Console.ReadKey();
        }
    }
}
