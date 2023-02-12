namespace ChefsNDishes.Models
{
    public class ViewModel
    {
        public string? CurrentView { get; set; }

        public List<User>? AllChefs {get;set;}

        public Dish? Dish {get; set;}
    }
}