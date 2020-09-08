using flowmaker.models;
using System;

namespace flowmaker.components.ViewModels
{
    public class BaseViewModel
    {
        public BaseViewModel()
        {
           
        }

        public string Title { get; set; }
        public string Name { get; set; }
        public string WorkspaceTitle { get; set; }
        public string WorkspaceName { get; set; }
        public bool IsEditable { get; set; }
        public bool IsAvailable { get; set; }

        public string ProductTitle { get { return (IsAvailable ? WorkspaceTitle : "Flowmaker") + (IsEditable ? " - Flowmaker" : string.Empty); } }
    }


}
