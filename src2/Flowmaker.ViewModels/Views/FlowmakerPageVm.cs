using Flowmaker.ViewModels.Components;
using System.Collections.Generic;

namespace Flowmaker.ViewModels.Views
{
    public class FlowmakerPageVm : ViewModelObject
    {
        public IEnumerable<FlowVm> Flows { get; set; }
        public HeaderVm Header { get; set; }
        public EditorVm Editor { get; set; }
        public FooterVm Footer { get; set; }
    }
}
