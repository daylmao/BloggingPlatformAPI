﻿namespace BloggingPlatformAPI.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string? Name { get; set; }
        public virtual ICollection<Blog>? Blogs { get; set; }
    }
}
