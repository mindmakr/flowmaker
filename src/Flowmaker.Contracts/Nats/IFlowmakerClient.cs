using System;

namespace Flowmaker.Contracts.Nats
{
    public interface IFlowmakerClient
    {
        void Abort();
        void Send(byte[] data);
        void Send(string subject, byte[] data);
        void Subscribe(Func<byte[], bool> handler);
    }
}