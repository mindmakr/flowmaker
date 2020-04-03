using System;
using System.Collections.Generic;

namespace Flowmaker.Contracts.Thisplay
{
    public class Viewport
    {
        public IList<Viewpart> Children { get; set; }
        public Viewport()
        {
            Children = new List<Viewpart>();
        }
    }

    public class Viewpart
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public Viewpart()
        {
        }
    }
}
