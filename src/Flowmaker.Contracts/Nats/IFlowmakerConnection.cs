namespace Flowmaker.Contracts.Nats
{
    public interface IFlowmakerConnection
    {
        IFlowmakerClient GetClient(string subject);
    }
}