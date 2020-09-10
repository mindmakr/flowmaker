using System;

namespace Flowmaker.ViewModels.Views
{
    public class ErrorView
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
