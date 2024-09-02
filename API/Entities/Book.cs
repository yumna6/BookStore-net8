using System;

namespace API.Entities;

public class Book
{
    public int Id { get; set; }  // Unique book identifier
    
    public required string Title { get; set; }  // Book title
    
    public required string Author { get; set; }  // Author of the book
    
    public decimal Price { get; set; }  // Price of the book
    
    public ICollection<AppUser>? UsersPurchased { get; set; }  // Users who have purchased this book
}
