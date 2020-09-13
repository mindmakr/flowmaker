namespace Flowmaker.ViewModels.Views
{
    public class FlowmakerPageVm : ViewModelObject
    {
        public string RequestPath { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public HeaderVm Header { get; set; }
        public EditorVm Editor { get; set; }
        public FooterVm Footer { get; set; }
    }
}
