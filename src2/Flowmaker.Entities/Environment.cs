using System;

namespace Flowmaker.Entities
{
    public class Environment : EntityObject
    {
        public string Hostname { get; set; }
        public Guid ProjectId { get; set; }
        public Project Project { get; set; }
    }
}
