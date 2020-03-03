using System;
using System.Text;
using System.Threading.Tasks;
using NATS.Client;
using NC = NATS.Client;
using Flowmaker.Contracts.Nats;
namespace Flowmaker.Nats
{
    public class FlowmakerClient : IFlowmakerClient
    {
        public bool _exit;
        public readonly string Subject;
        private NC.IConnection Connection { get; }

        public FlowmakerClient(NC.IConnection connection, string subject)
        {
            Connection = connection;
            Subject = subject;
        }

        public void Send(byte[] data)
        {
            Send(Subject, data);
        }

        public void Send(string subject, byte[] data)
        {
            Connection.Publish(subject, data);
        }

        public void Abort()
        {
            _exit = true;
        }

        public void Subscribe(Func<byte[], bool> handler)
        {
            Task.Run(() =>
            {
                ISyncSubscription sub = Connection.SubscribeSync(Subject);
                while (!_exit)
                {
                    var message = sub.NextMessage();
                    if (message != null)
                    {
                        //string data = Encoding.UTF8.GetString(message.Data);
                        _exit = handler(message.Data);

                    }
                }
            });
        }
    }
}

