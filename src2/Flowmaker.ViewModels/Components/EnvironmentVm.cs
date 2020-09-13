using System;

namespace Flowmaker.ViewModels.Components
{
    public class EnvironmentVm : VmObject
    {
        public string Hostname { get; set; } = string.Empty;
        public bool IsEditable { get; set; } = false;
    }
}
