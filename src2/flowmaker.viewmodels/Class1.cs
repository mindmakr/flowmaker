using System;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using System.Text;

namespace flowmaker.viewmodels
{
    public class BaseViewModel
    {
        public BaseViewModel()
        {
            Name = "BaseViewMode";
        }
        public string Name { get; set; }
    }

    public class Homepage : BaseViewModel
    {
    }
}
