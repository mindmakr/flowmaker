﻿using System;

namespace Flowmaker.Data.Entities
{
    public class Slot : EntityObject
    {
        public string Hostname { get; set; }
        public Guid WorkspaceId { get; set; }
        public Workspace Workspace { get; set; }
        public bool IsEditable { get; set; }
    }
}
