using System;

namespace Flowmaker.Contracts.Nats
{
    public interface IFlowmakerChannel
    {
        string Subject { get; }
        bool IsActive { get; set; }

        void Abort();
        void Handle(Func<byte[], bool> handler);
        void Handle<T>(T job) where T : IFlowmakerJob;
        void Send(byte[] data);
        void Send(string subject, byte[] data);
    }
}