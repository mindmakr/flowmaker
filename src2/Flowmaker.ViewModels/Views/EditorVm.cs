using Flowmaker.ViewModels.Components;
using System.Collections.Generic;

namespace Flowmaker.ViewModels.Views
{
    public class EditorVm : ViewModelObject
    {
        public IEnumerable<FlowVm> Flows { get; set; } = new List<FlowVm>();
    }
}
