using System;

namespace flowmaker.models
{
    public class Slot : BaseModel
    {
        public string Hostname { get; set; }
        public Guid WorkspaceId { get; set; }
        public Workspace Workspace { get; set; }
        public bool IsEditable { get; set; }
    }
}
