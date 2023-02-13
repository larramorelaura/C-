#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace ProductsAndCategories.Models;

public class ProductAndCategory
{
    [Key]
    public int ProductAndCategoryId { get; set; }

    public int CategoryId{get;set;}
    public int ProductId{get;set;}

    public Product? Product { get; set; }    
    public Category? Category { get; set; }

}