using System;
using System.Threading.Tasks;
using NATS.Client;
using NC = NATS.Client;
using Flowmaker.Contracts.Nats;

namespace Flowmaker.Nats
{
    public class FlowmakerChannel : IFlowmakerChannel
    {
        private NC.IConnection Connection { get; }

        public string Subject { get; }
        public bool IsActive { get; set; } = true;

        private readonly IFlowmakerConnection _flowmakerConnection;
        public FlowmakerChannel(IFlowmakerConnection flowmakerConnection, NC.IConnection connection, string subject)
        {
            _flowmakerConnection = flowmakerConnection;
            Connection = connection;
            Subject = subject;
        }

        public void Send(byte[] data)
        {
            Send(Subject, data);
        }

        public void Send(string subject, byte[] data)
        {
            _flowmakerConnection.WaitTillReady();
            Connection.Publish(subject, data);
        }

        public void Abort()
        {
            IsActive = false;
        }

        public void Handle(Func<byte[], bool> handler)
        {
            Task.Run(() =>
            {
                ISyncSubscription sub = Connection.SubscribeSync(Subject);
                while (IsActive)
                {
                    var message = sub.NextMessage();
                    if (message != null)
                    {
                        //string data = Encoding.UTF8.GetString(message.Data);
                        IsActive = handler(message.Data);
                    }
                }
            });
        }

        public void Handle<T>(T job) where T : IFlowmakerJob
        {
            Task.Run(() =>
            {
                ISyncSubscription sub = Connection.SubscribeSync(Subject);
                while (IsActive)
                {
                    var message = sub.NextMessage();
                    if (message != null)
                    {
                        //string data = Encoding.UTF8.GetString(message.Data);
                        IsActive = job.Execute(message.Data);
                    }
                }
            });
        }

    }
}

