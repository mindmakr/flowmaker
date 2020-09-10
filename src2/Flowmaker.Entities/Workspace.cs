using System.Collections.Generic;

namespace Flowmaker.Entities
{
    public class Workspace : EntityObject
    {
        public ICollection<Slot> Environments { get; } = new List<Slot>();
    }
}
