namespace Flowmaker.Domains
{
    public class Flow : DomainObject
    {
        public string Slug { get; set; }
        public string ParentSlug { get; set; }
    }
}
