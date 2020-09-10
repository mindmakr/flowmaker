namespace Flowmaker.Web.ViewModels
{
    public class Environment
    {
        public Environment()
        {

        }

        public string Title { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string WorkspaceTitle { get; set; } = string.Empty;
        public string WorkspaceName { get; set; } = string.Empty;
        public bool IsEditable { get; set; } = false;
        public bool IsAvailable { get; set; } = false;

        public string ProductTitle { get { return (IsAvailable ? WorkspaceTitle : "Flowmaker") + (IsEditable ? " - Flowmaker" : string.Empty); } }
    }
}
