#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace WeddingPlanner.Models;

public class GuestList
{
    [Key]
    public int GuestListId { get; set; }

    public int UserId{get;set;}
    public int WeddingId{get;set;}

    public Wedding? Wedding { get; set; }    
    public User? User { get; set; }

}