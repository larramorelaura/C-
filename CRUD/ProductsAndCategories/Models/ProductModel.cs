#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace ProductsAndCategories.Models;

public class Product
{
    [Key]
    public int ProductId { get; set; }

    public string Name{get;set;}

    public string Description{get;set;}

    public decimal Price {get;set;}

    public List<ProductAndCategory> Categories { get; set; } = new List<ProductAndCategory>();

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

}
