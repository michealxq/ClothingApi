﻿namespace P1API.Models.Domains
{
    public class Review
    {
        public int ReviewId { get; set; }
        public int ProductId { get; set; }
        public int UserId { get; set; }
        public string Comment { get; set; }
        public int Rating { get; set; } // e.g., 1 to 5 stars
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public Product Product { get; set; }
        public User User { get; set; }
    }
}
