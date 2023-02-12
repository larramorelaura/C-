using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ChefsNDishes.Models;

namespace ChefsNDishes.Controllers;

public class ChefsNDishesController : Controller
{
    private readonly ILogger<ChefsNDishesController> _logger;
    private ChefsNDishesContext _context;
    public ChefsNDishesController(ILogger<ChefsNDishesController> logger, ChefsNDishesContext context)
    {
        _logger = logger;
        _context=context;
    }

    [HttpGet("")]
    public async Task<IActionResult> Index()
    {      
        // List<User> users= _context.Users.Include(u=>u.AllDishes).ToList();
        var results = from user in _context.Users
                select new {
                    FirstName = user.FirstName,
                    Age = DateTime.Now.Year - user.DOB.Year,
                    DishCount = user.AllDishes.Count
                };

        var users = await results.ToListAsync();

        return View("Index", users);
    }

    [HttpGet("chefs")]
    public IActionResult AllChefs()
    {      
        List<User> users= _context.Users.Include(u=>u.AllDishes).ToList();
        return RedirectToAction("Index");
    }

    [HttpGet("dishes")]
    public IActionResult AllDishes()
    {      
        List<Dish> dishes= _context.Dishes.Include(d=>d.Chef).ToList();
        return View("Dishes", dishes);
    }

    [HttpGet("chefs/new")]
    public IActionResult CreateChef()
    {      
        List<User> users= _context.Users.ToList();
        return View("CreateChef");
    }

    [HttpPost("chefs/create")]
    public IActionResult AddChef(User newUser)
    {
        if (ModelState.IsValid)
        {
            _context.Users.Add(newUser);
            _context.SaveChanges();
            return RedirectToAction("AllChefs");
        }
        return View("CreateChef");
    }

    [HttpGet("dishes/new")]
    public IActionResult CreateDish()
    {      
        List<User> users = _context.Users.Include(u=>u.AllDishes).ToList();
        ViewModel viewModel = new ViewModel { Dish=new Dish(), AllChefs = users };
        return View("CreateDish", viewModel);
    }

    [HttpPost("dishes/create")]
    public IActionResult AddDish(ViewModel newViewModel)
    {
        Console.WriteLine(newViewModel.Dish.Name);

        Dish dish = new Dish
        {
            Name = newViewModel.Dish.Name,
            Chef = _context.Users.Find(newViewModel.Dish.UserId),
            Tastiness = newViewModel.Dish.Tastiness,
            Calories = newViewModel.Dish.Calories,
        };

        if (ModelState.IsValid)
        {
            _context.Dishes.Add(dish);
            _context.SaveChanges();
            return RedirectToAction("AllDishes");
        }
        List<User> users = _context.Users.Include(u=>u.AllDishes).ToList();
        ViewModel viewModel = new ViewModel { Dish=new Dish(), AllChefs = users };
        return View("CreateDish", viewModel);
        
    }
}
