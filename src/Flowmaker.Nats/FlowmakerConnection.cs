using NC = NATS.Client;
using Flowmaker.Contracts.Nats;

namespace Flowmaker.Nats
{
    //nats-server
    public class FlowmakerConnection : IFlowmakerConnection
    {
        private NC.IConnection _connection;
        private NC.Options _natsOptions;
        public FlowmakerConnection(string natsServerUrl = null)
        {
            var factorty = new NC.ConnectionFactory();
            _natsOptions = NC.ConnectionFactory.GetDefaultOptions();
            _natsOptions.Url = natsServerUrl == null ? "nats://localhost:4222" : natsServerUrl;
            _connection = factorty.CreateConnection(_natsOptions);
        }

        public IFlowmakerClient GetClient(string subject)
        {
            return new FlowmakerClient(_connection, subject);
        }
    }
}

