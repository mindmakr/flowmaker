namespace Flowmaker.Contracts.Nats
{
    public interface IFlowmakerJob
    {
        bool Execute(byte[] data);
    }
}