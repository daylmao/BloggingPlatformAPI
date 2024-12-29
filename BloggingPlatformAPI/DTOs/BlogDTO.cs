namespace BloggingPlatformAPI.DTOs
{
    public class BlogDTO
    {
        public int BlogId { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int CategoryId { get; set; }
        public List<string>? Tags { get; set; }
    }
}
