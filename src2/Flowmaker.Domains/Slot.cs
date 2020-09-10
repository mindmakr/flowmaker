using System;

namespace Flowmaker.Domains
{
    public class Slot : DomainObject
    {
        public string Hostname { get; set; }
        public Guid WorkspaceId { get; set; }
        public Workspace Workspace { get; set; }
        public bool IsEditable { get; set; }
    }
}
