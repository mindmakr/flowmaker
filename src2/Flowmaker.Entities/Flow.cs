using System;

namespace Flowmaker.Entities
{
    public class Flow : EntityObject
    {
        public string Slug { get; set; }
        public string ParentSlug { get; set; }
        public Guid EnvironmentId { get; set; }
        public Environment Environment { get; set; }
    }
}
