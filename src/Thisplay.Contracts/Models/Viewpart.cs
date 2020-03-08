using Thisplay.Contracts.Interfaces;

namespace Thisplay.Contracts.Models
{
    public class Viewpart : IViewpart
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public int DisplayOrder { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public bool Active { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public Viewpart()
        {
        }
    }
}
