using NC = NATS.Client;
using Flowmaker.Contracts.Nats;
using System.Threading;
using System;
using System.Threading.Tasks;
using NATS.Client;

namespace Flowmaker.Nats
{
    //nats-server
    public class FlowmakerConnection : IFlowmakerConnection
    {
        private NC.IConnection _connection;
        private NC.Options _natsOptions;
        private bool _isInReadyState = false;
        public FlowmakerConnection(string natsServerUrl = null)
        {
            var factorty = new NC.ConnectionFactory();
            _natsOptions = NC.ConnectionFactory.GetDefaultOptions();
            _natsOptions.Url = natsServerUrl == null ? "demo.nats.io:4222" : natsServerUrl;
            _connection = factorty.CreateConnection(_natsOptions);
        }

        public IFlowmakerChannel GetChannel(string subject)
        {
            return new FlowmakerChannel(this, _connection, subject);
        }

        public IFlowmakerChannel GetChannel<T>(string subject, T job) where T : IFlowmakerJob
        {
            var channel = new FlowmakerChannel(this, _connection, subject);
            channel.Handle(job);
            return channel;
        }

        public IFlowmakerChannel GetChannel(string subject, Func<byte[], bool> handler)
        {
            var channel = new FlowmakerChannel(this, _connection, subject);
            channel.Handle(handler);
            return channel;
        }

        public bool WaitTillReady()
        {
            if (_isInReadyState) return true;
            Thread.Sleep(1000);
            _isInReadyState = true;
            return _isInReadyState;
        }
    }
}

