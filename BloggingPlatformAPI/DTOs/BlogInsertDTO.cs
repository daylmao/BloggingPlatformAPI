namespace BloggingPlatformAPI.DTOs
{
    public class BlogInsertDTO
    {
        public string? Title { get; set; }
        public string? Content { get; set; }
        public int CategoryId { get; set; }
        public List<string>? Tags { get; set; }
    }
}
