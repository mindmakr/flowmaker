using System;
using System.Collections.Generic;

namespace Flowmaker.Entities
{
    public class Flow : EntityObject
    {
        public string Slug { get; set; }
        public string ParentSlug { get; set; }
        public Guid EnvironmentId { get; set; }
        public Environment Environment { get; set; }
        public ViewPage ViewPage { get; set; }
        public string Route { get { return (string.IsNullOrEmpty(ParentSlug) || ParentSlug=="/" )? Slug : ParentSlug + Slug; } }
    }
}
