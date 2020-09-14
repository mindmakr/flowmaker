using Flowmaker.ViewModels.Components;
using System.Collections.Generic;
using System.Linq;

namespace Flowmaker.ViewModels.Views
{
    public class FlowmakerPageVm : ViewModelObject
    {
        public new string Title { get { return Project != null? Project.Title:string.Empty; } }
        public new string Name { get { return Project != null ? Project.Name : string.Empty; } }
        public IEnumerable<FlowVm> Flows { get; set; }
        public ViewPageVm ViewPage { get {return Flows!=null && Flows.Any(f => f.Slug == RequestRoute) ? Flows.FirstOrDefault(f => f.Slug == RequestRoute).ViewPage : null; }}
        public HeaderVm Header { get; set; }
        public EditorVm Editor { get; set; }
        public FooterVm Footer { get; set; }
        public string ViewPageContent { get { return ViewPage != null && !string.IsNullOrEmpty(ViewPage.Content) ? ViewPage.Content : string.Empty; } }
    }
}
