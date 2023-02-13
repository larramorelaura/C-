#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace ProductsAndCategories.Models;

public class Category
{
    [Key]
    public int CategoryId { get; set; }
    
    [Required(ErrorMessage ="Name is required")]
    public string Name{get;set;}

    public List<ProductAndCategory>? Products { get; set; } = new List<ProductAndCategory>();
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

}