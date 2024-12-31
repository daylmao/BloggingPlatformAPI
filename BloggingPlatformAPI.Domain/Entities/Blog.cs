namespace BloggingPlatformAPI.Entities
{
    public class Blog
    {
        public int BlogId { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; }
        public int CategoryId { get; set; }

        public virtual Category? Category { get; set; }
        public virtual List<string>? Tags { get; set; }
    }
}
