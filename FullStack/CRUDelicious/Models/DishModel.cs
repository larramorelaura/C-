#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace CRUDelicious.Models;


public class Dish
{
    [Key]
    public int? DishId { get; set; }
    [Required(ErrorMessage ="Name of dish is required")]
    public string Name {get; set;}
    [Required(ErrorMessage ="Chef is required")]
    public string Chef {get;set;}
    [Required(ErrorMessage ="Tastiness is required")]
    public int Tastiness {get;set;}
    [Required(ErrorMessage ="Calories are required")]
    public int Calories {get; set;}
    
    public string? Description {get; set;}
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
    
}