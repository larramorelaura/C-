#pragma warning disable CS8618;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace WeddingPlanner.Models;
public class LoginUser
{
    [NotMapped]
    [Required]    
    public string LoginEmail { get; set; }    
    [NotMapped]
    [Required]  
    [DataType(DataType.Password)]  
    public string LoginPassword { get; set; } 
}