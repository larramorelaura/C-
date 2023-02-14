#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace WeddingPlanner.Models;


public class Wedding
{
    [Key]
    public int UserId { get; set; }


    [Required(ErrorMessage ="Wedder One is required")]
    [MinLength(2, ErrorMessage = "Wedder One must be at least 2 characters")]
    [Display(Name ="Wedder One:")]
    public string WedderOne {get; set;}


    [Required(ErrorMessage ="Wedder Two is required")]
    [MinLength(2, ErrorMessage = "Wedder Two must be at least 2 characters")]
    [Display(Name ="Wedder Two:")]
    public string WedderTwo {get; set;}

    [Required(ErrorMessage = "Wedding Date is required")]
    [Display(Name = "Wedding Date")]
    [FutureDate(ErrorMessage = "Wedding Date must be in the future")]
    public DateTime WeddingDate{get;set;}

    [Required(ErrorMessage ="Address is required")]
    public string Address{get;set;}

    public User? Creator{get;set;}
    
    public List<GuestList>? Guests { get; set; } = new List<GuestList>();

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
    
}

public class FutureDateAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        var weddingDate = (DateTime)value;

        if (weddingDate <= DateTime.Now)
        {
            return new ValidationResult(ErrorMessage);
        }

        return ValidationResult.Success;
    }
}

