
using System.ComponentModel.DataAnnotations;

namespace API.DTOs;

public class LoginDto
{
    public required string Username { get; set; }  // Username is optional if Email is provided
    public required string Email { get; set; }     // Email is optional if Username is provided
    
    [Required]
    public required string Password { get; set; }
}
