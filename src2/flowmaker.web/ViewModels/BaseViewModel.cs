namespace flowmaker.web.ViewModels
{
    public class BaseViewModel
    {
        public string WorkspaceTitle { get; set; }
        public string WorkspaceName { get; set; }
        public bool IsEditable { get; set; }
        public bool IsAvailable { get; set; }
        public BaseViewModel()
        {

        }


        public string ProductTitle { get { return (IsAvailable?WorkspaceTitle:"Flowmaker") + (IsEditable?" - Flowmaker":string.Empty); } }
    }


}
