using Flowmaker.ViewModels.Components;

namespace Flowmaker.ViewModels
{
    public abstract class ViewModelObject
    {
        public string Title { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string RequestPath { get; set; } = string.Empty;
        public bool IsEditable { get { return Project != null && Environment != null && Project.EditableHostname == Environment.Hostname; } }
        public bool IsAvailable { get { return Project!=null && Environment != null; } }
        public ProjectVm Project { get; set; }
        public EnvironmentVm Environment { get; set; }
    }

}
