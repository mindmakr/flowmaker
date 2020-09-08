using flowmaker.models;
using System;

namespace flowmaker.components.ViewModels
{
    public class BaseViewModel
    {
        public BaseViewModel(Slot slot)
        {
            Slot = slot;
        }
        private Slot Slot { get; set; }

        public string Title { get { return Slot != null ? Slot.Title : string.Empty; } }
        public string Name { get { return Slot != null ? Slot.Name : string.Empty; } }
        public string WorkspaceTitle { get { return Slot != null ? Slot.Workspace.Title : string.Empty; } }
        public string WorkspaceName { get { return Slot != null ? Slot.Workspace.Name : string.Empty; } }
        public bool IsEditable { get { return Slot != null && Slot.IsEditable; } }
        public bool IsAvailable { get { return Slot != null; } }
        public BaseViewModel()
        {

        }


        public string ProductTitle { get { return (IsAvailable ? WorkspaceTitle : "Flowmaker") + (IsEditable ? " - Flowmaker" : string.Empty); } }
    }


}
