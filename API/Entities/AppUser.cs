namespace API.Entities;

public class AppUser
{

    public int Id { get; set; }  // Unique identifier for the user
    
    public required string UserName { get; set; }  // The username of the user
    
    public required string Email { get; set; }  // Email for communication and login
    
    public required byte[] PasswordHash { get; set; }  // Hashed password for authentication
    
    public required byte[] PasswordSalt { get; set; }  // Salt for hashing the password

     public string Role { get; set; } = "Customer";  // User's role in the system (default is Customer)

    public ICollection<Book>? BooksPurchased { get; set; }  // Collection of books purchased by the user 
}

