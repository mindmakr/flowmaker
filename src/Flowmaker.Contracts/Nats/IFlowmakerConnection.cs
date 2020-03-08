using System;

namespace Flowmaker.Contracts.Nats
{
    public interface IFlowmakerConnection
    {
        IFlowmakerChannel GetChannel<T>(string subject, T job) where T : IFlowmakerJob;
        IFlowmakerChannel GetChannel(string subject, Func<byte[], bool> handler);
        IFlowmakerChannel GetChannel(string subject);
        bool WaitTillReady();
    }
}