#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace WeddingPlanner.Models;

public class ViewModel
{
    public string CurrentView {get;set;}
    public User? User {get;set;}

    public List<Wedding>? Weddings{get;set;}
}