namespace BloggingPlatformAPI.DTOs
{
    public class BlogDTO
    {
        public int BlogId { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public DateOnly CreatedAt { get; set; }
        public DateOnly UpdatedAt { get; set; }
        public int CategoryId { get; set; }
    }
}
