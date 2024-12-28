namespace BloggingPlatformAPI.DTOs
{
    public class BlogDTOUpdateDTO
    {
        public int BlogId { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public int CategoryId { get; set; }
    }
}
