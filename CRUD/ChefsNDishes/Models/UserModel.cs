#pragma warning disable CS8618
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ChefsNDishes.Models;

public class User
{
    [Key]
    public int UserId { get; set; }


    [Required(ErrorMessage ="First Name is required")]
    [MinLength(2, ErrorMessage = "First Name must be at least 2 characters")]
    public string FirstName {get; set;}


    [Required(ErrorMessage ="Last Name is required")]
    [MinLength(2, ErrorMessage = "Last Name must be at least 2 characters")]
    
    public string LastName {get; set;}

    [Required(ErrorMessage ="Date of Birth is required")]
    [DataType(DataType.Date)]
    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
    [Display(Name = "Date of Birth")]
    [PastDate(ErrorMessage = "Date of birth must be in the past")]
    [AgeVerification(ErrorMessage ="You must be 18")]
    public DateTime DOB { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
    
    public List<Dish> AllDishes { get; set; } = new List<Dish>();
}

public class PastDateAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        var dob = (DateTime)value;

        if (dob >= DateTime.Now)
        {
            return new ValidationResult(ErrorMessage);
        }

        return ValidationResult.Success;
    }
}
public class AgeVerificationAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        var dob = (DateTime)value;

        var age =   (DateTime.Now.Year - dob.Year - 1) +
                    (((DateTime.Now.Month > dob.Month) ||
                    ((DateTime.Now.Month == dob.Month) && (DateTime.Now.Day >= dob.Day)))
                    ? 1 : 0);

        if (age < 18)
        {
            return new ValidationResult(ErrorMessage);
        }

        return ValidationResult.Success;
    }
}

