using System.Collections.Generic;

namespace flowmaker.models
{
    public class Workspace : BaseModel
    {
        public ICollection<Slot> Environments { get; } = new List<Slot>();
    }
}
