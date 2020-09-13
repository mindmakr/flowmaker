using Flowmaker.ViewModels.Components;
using System.Collections.Generic;

namespace Flowmaker.ViewModels.Views
{
    public class FlowmakerPageVm : ViewModelObject
    {
        public new string Title { get { return Project != null? Project.Title:string.Empty; } }
        public IEnumerable<FlowVm> Flows { get; set; }
        public ViewPageVm ViewPage { get; set; }
        public HeaderVm Header { get; set; }
        public EditorVm Editor { get; set; }
        public FooterVm Footer { get; set; }
        public string ViewPageContent { get { return ViewPage != null && !string.IsNullOrEmpty(ViewPage.Content) ? ViewPage.Content : string.Empty; } }
    }
}
