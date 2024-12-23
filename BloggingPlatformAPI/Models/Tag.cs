namespace BloggingPlatformAPI.Models
{
    public class Tag
    {
        public int TagId { get; set; }
        public string? Name { get; set; }
        public virtual ICollection<Blog>? Blogs { get; set; }
    }
}
