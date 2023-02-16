#pragma warning disable CS8618;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Forum.Models;

[NotMapped]
public class LoginUser
{
    
    [Required]
    [Display(Name ="Email")]    
    public string LoginEmail { get; set; }    
    [Required]  
    [DataType(DataType.Password)]  
    [Display(Name ="Passord")]
    public string LoginPassword { get; set; } 
}