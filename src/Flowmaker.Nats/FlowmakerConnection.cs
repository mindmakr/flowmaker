using System;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Flowmaker.Contracts.Interfaces;
using NATS.Client;
using NATS.Client.Rx;
using NATS.Client.Rx.Ops;
using NC = NATS.Client;
namespace Flowmaker.Nats
{
    public class FlowmakerConnection
    {
        private static bool _exit = false;
        private NC.IConnection _connection;
        private NC.Options _natsOptions;
        public FlowmakerConnection(string natsServerUrl = null)
        {
            var factorty = new NC.ConnectionFactory();
            _natsOptions = NC.ConnectionFactory.GetDefaultOptions();
            _natsOptions.Url = natsServerUrl == null ? "nats://localhost:4222" : natsServerUrl;
            _connection = factorty.CreateConnection(_natsOptions);
        }

        public FlowmakerPublisher GetPublisher()
        {
            return new FlowmakerPublisher(_connection);
        }
        public FlowmakerConsumer GetConsumer()
        {
            return new FlowmakerConsumer(_connection);
        }
    }

    public class FlowmakerPublisher
    {
        private bool _exit;

        public NC.IConnection Connection { get; }

        public FlowmakerPublisher(NC.IConnection connection)
        {
            Connection = connection;
        }

        public void Do(string message)
        {
            byte[] data = Encoding.UTF8.GetBytes(message);
            Connection.Publish("nats.demo.pubsub", data);
        }
    }
}

public class FlowmakerConsumer
{
    private bool _exit;

    public NC.IConnection Connection { get; }

    public FlowmakerConsumer(NC.IConnection connection)
    {
        Connection = connection;
    }

    public void Do()
    {
        Task.Run(() =>
        {
            ISyncSubscription sub = Connection.SubscribeSync("nats.demo.pubsub");
            while (!_exit)
            {
                var message = sub.NextMessage();
                if (message != null)
                {
                    string data = Encoding.UTF8.GetString(message.Data);
                    LogMessage(data);
                }
            }
        });
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
