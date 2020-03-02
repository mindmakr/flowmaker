using System;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
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

        public FlowmakerTask GetTask(string subject)
        {
            return new FlowmakerTask(_connection, subject);
        }
        public FlowmakerConsumer GetConsumer()
        {
            return new FlowmakerConsumer(_connection);
        }
    }

    public class FlowmakerTask
    {
        public bool _exit;
        public readonly string Subject;
        public NC.IConnection Connection { get; }

        public FlowmakerTask(NC.IConnection connection, string subject)
        {
            Connection = connection;
            Subject = subject;
        }

        public void Send(string message)
        {
            byte[] data = Encoding.UTF8.GetBytes(message);
            Connection.Publish(Subject, data);
        }

        public void Subscribe()
        {
            Task.Run(() =>
            {
                ISyncSubscription sub = Connection.SubscribeSync(Subject);
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
}


public class FlowmakerConsumer
{
    public bool _exit;
    public readonly string Subject;
    public NC.IConnection Connection { get; }


    public FlowmakerConsumer(string subject)
    {
        Subject = subject;
    }

    public FlowmakerConsumer(NC.IConnection connection)
    {
        Connection = connection;
    }

    public void Do()
    {
        Task.Run(() =>
        {
            ISyncSubscription sub = Connection.SubscribeSync(Subject);
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
