namespace BloggingPlatformAPI.DTOs
{
    public class BlogDTOInsertDTO
    {
        public string? Title { get; set; }
        public string? Content { get; set; }
        public int CategoryId { get; set; }
    }
}
