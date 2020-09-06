namespace flowmaker.models
{
    public class Flow: BaseModel
    {
        public string Slug { get; set; }
        public string ParentSlug { get; set; }
    }
}
