using Flowmaker.ViewModels.Components;
using System.Collections.Generic;

namespace Flowmaker.ViewModels.Views
{
    public class EditorVm : ViewModelObject
    {
        public new string Title { get { return Project != null ? Project.Title : string.Empty; } }
        public new string Name { get { return Project != null ? Project.Name : string.Empty; } }
        public FlowVm Flow { get; set; }
        public IEnumerable<FlowVm> Flows { get; set; }
        public IEnumerable<EnvironmentVm> Environments { get; set; }
    }
}
