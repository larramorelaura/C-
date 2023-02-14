#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace Forum.Models;

public class Post
{
[Key]
public int PostId{get;set;}

[Required(ErrorMessage="Topic is required")]
[MinLength(3, ErrorMessage ="Topic must be 3 characters or more")]
public string Topic{get;set;}

[Required(ErrorMessage = "Body is required")]
[MinLength(5, ErrorMessage ="Body must be 5 characters or more")]
public string Body{get;set;}

[Display(Name="Image Url")]
public string? ImgUrl{get;set;}
public DateTime CreatedAt{get;set;} =DateTime.Now;
public DateTime UpdatedAt{get;set;} =DateTime.Now;
}