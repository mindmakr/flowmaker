using System;

namespace Flowmaker.Entities
{
    public class Environment : EntityObject
    {
        public string Hostname { get; set; }
        public Guid WorkspaceId { get; set; }
        public Project Workspace { get; set; }
        public bool IsEditable { get; set; }
    }
}
