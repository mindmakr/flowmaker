using flowmaker.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace flowmaker.web.ViewModels
{

    public class HomepageViewModel : BaseViewModel
    {
        public HomepageViewModel(Slot slot)
        {
            Slot = slot;
            IsEditable = Slot != null && Slot.IsEditable;
            IsAvailable = Slot != null;
            WorkspaceName = Slot != null ? Slot.Workspace.Name:String.Empty;
            WorkspaceTitle = Slot != null ? Slot.Workspace.Title : String.Empty;
        }
        private Slot Slot { get; set; }

        public string Title { get { return Slot != null ? Slot.Title : String.Empty; } }
        public string Name { get { return Slot != null ? Slot.Name : String.Empty; } }
    }


}
