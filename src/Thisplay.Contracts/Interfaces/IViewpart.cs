namespace Thisplay.Contracts.Interfaces
{
    public interface IViewpart
    {
        string Id { get; set; }
        string Title { get; set; }
        int DisplayOrder { get; set; }
        bool Active { get; set; }
    }
}