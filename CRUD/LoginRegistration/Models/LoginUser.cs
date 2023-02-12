#pragma warning disable CS8618;
using System.ComponentModel.DataAnnotations;
namespace LoginRegistration.Models;
public class LoginUser
{
    
    [Required]    
    public string Email { get; set; }    
    [Required]  
    [DataType(DataType.Password)]  
    public string Password { get; set; } 
}