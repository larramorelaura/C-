#pragma warning disable CS8618
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ChefsNDishes.Models;

public class Dish
{
    [Key]
    public int DishId {get; set;}

    [Required(ErrorMessage ="Dish name is required")]
    public string Name {get;set;}

    [Required(ErrorMessage ="Calories are required")]
    [Range(0, int.MaxValue, ErrorMessage = "Calories must be greater than 0")]
    public int Calories {get;set;}

    [Required(ErrorMessage ="Tastiness is required")]
    [Range(1,5, ErrorMessage ="Tastiness must be between 1 and 5")]
    public int Tastiness {get;set;}

    public int UserId { get; set; }

    public User? Chef { get; set; }
}