using System;

namespace Flowmaker.ViewModels.Components
{
    public abstract class VmObject
    {
        public Guid Id { get; set; } = Guid.Empty;
        public string Title { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
    }
}
