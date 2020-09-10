using System.Collections.Generic;

namespace Flowmaker.Data.Entities
{
    public class Workspace : EntityObject
    {
        public ICollection<Slot> Environments { get; } = new List<Slot>();
    }
}
