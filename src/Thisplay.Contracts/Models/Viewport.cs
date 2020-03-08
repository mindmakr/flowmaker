using System;
using System.Collections.Generic;
using Thisplay.Contracts.Interfaces;

namespace Thisplay.Contracts.Models
{
    public class Viewport : IViewport
    {
        public IEnumerable<IViewpart> Children { get; set; }

        public Viewport()
        {
            Children = new List<Viewpart>();
        }
    }
}
