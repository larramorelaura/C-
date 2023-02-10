#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace DojoSurveyTwo.Models;   
public class Survey{
    [Required(ErrorMessage ="Name is required")]
    [MinLength(2, ErrorMessage ="Name must be at least 2 characters")]
    public string Name {get;set;}

    [Required(ErrorMessage ="Choose a location")]
    
    public string Location {get;set;}

    [Required(ErrorMessage ="Choose a language")]
    
    public string Language {get;set;}

    
    [MaxLength(20, ErrorMessage ="Comments can be no longer than 20 characters")]
    public string? Comment {get;set;}


}