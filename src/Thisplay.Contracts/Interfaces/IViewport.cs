using System.Collections.Generic;

namespace Thisplay.Contracts.Interfaces
{
    public interface IViewport
    {
        IEnumerable<IViewpart> Children { get; set; }
    }
}