using System;

namespace Flowmaker.ViewModels.Components
{
    public abstract class VmObject
    {
        public Guid Id { get; set; }
        public string Title { get; set; } 
        public string Name { get; set; } 
        public int DisplayOrder { get; set; } 
        public bool Disabled { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
