﻿using flowmaker.models;
using System;

namespace flowmaker.components.ViewModels
{
    public class BaseViewModel
    {
        public BaseViewModel()
        {
           
        }

        public string Title { get; set; } = String.Empty;
        public string Name { get; set; } = String.Empty;
        public string WorkspaceTitle { get; set; } = String.Empty;
        public string WorkspaceName { get; set; } = String.Empty;
        public bool IsEditable { get; set; } =false;
        public bool IsAvailable { get; set; } =false;

        public string ProductTitle { get { return (IsAvailable ? WorkspaceTitle : "Flowmaker") + (IsEditable ? " - Flowmaker" : string.Empty); } }
    }


}
