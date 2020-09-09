using flowmaker.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace flowmaker.components.ViewModels
{

    public class HomepageViewModel : BaseViewModel
    {
        public static HomepageViewModel NotAvailable
        {
            get { return new HomepageViewModel { IsAvailable = false }; }
        }
    }
}
