using System.Collections.Generic;

namespace Flowmaker.Entities
{
    public class Project : EntityObject
    {
        public string EditableHostname { get; set; }
        public ICollection<Environment> Environments { get; } = new List<Environment>();
    }
}
