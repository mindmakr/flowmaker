using System;

namespace Flowmaker.Entities
{
    public class ViewPage : EntityObject
    {
        public Guid FlowId { get; set; }
        public Flow Flow { get; set; }
        public string Content { get; set; }
    }
}
