using System;

namespace flowmaker.models
{
    public class FlowInstance : BaseModel
    {

        public string Slug { get; set; }
        public string ParentSlug { get; set; }
        public Guid FlowId { get; set; }
        public Flow Flow { get; set; }
        public Guid SlotId { get; set; }
        public Slot Slot { get; set; }
    }
}
