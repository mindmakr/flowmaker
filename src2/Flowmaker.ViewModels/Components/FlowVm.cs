using System;

namespace Flowmaker.ViewModels.Components
{
    public class FlowVm : VmObject
    {
        public string Slug { get; set; }
        public string ParentSlug { get; set; }
        public string Route { get; set; }
        public ViewPageVm ViewPage { get; set; }
    }
}
