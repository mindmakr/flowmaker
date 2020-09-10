using System.Collections.Generic;

namespace Flowmaker.Domains
{
    public class Workspace : DomainObject
    {
        public ICollection<Slot> Environments { get; } = new List<Slot>();
    }
}
