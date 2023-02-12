using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CRUDelicious.Models;

namespace CRUDelicious.Controllers;



public class CRUDeliciousController : Controller 
{
private readonly ILogger<CRUDeliciousController> _logger;

    private DishContext _context;
    public CRUDeliciousController(ILogger<CRUDeliciousController> logger, DishContext context)
    {
        _logger = logger;

        _context= context;
    }

[HttpGet("/dishes")]
public IActionResult Index()
{
    ViewBag.AllDishes= _context.Dishes.ToList();
    return View("Index");
}

[HttpGet("dishes/new")]
public IActionResult CreateDish()
{
    return View();
}

[HttpPost("dishes/create")]
public IActionResult Create(Dish dish)
{
    Console.WriteLine(dish.Name);
    if(ModelState.IsValid)
    {
        _context.Add(dish);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }
    else
    { 
        return View("CreateDish");
    }
}

[HttpGet("dishes/{id}")]
public IActionResult OneDish(int id)
{
    //make a query to get the one dish using the id and pass it to the view
    Dish? OneDish= _context.Dishes.FirstOrDefault(d=> d.DishId==id);
    return View("OneDish", OneDish);
}

[HttpGet("dishes/{id}/edit")]
public IActionResult Edit(int id)
{
    //make a query to get the one dish for edit and pass to view
    Dish? OneDish= _context.Dishes.FirstOrDefault(d=> d.DishId==id);
    return View("Update", OneDish);
}

[HttpPost("dishes/{id}/update")]
public IActionResult Update(Dish newDish, int id)
{

    Dish? OldDish = _context.Dishes.FirstOrDefault(i => i.DishId == id);

    if(ModelState.IsValid)
    {
        OldDish.Name= newDish.Name;
        OldDish.Chef=newDish.Chef;
        OldDish.Description=newDish.Description;
        OldDish.Calories=newDish.Calories;
        OldDish.Tastiness=newDish.Tastiness;

        _context.SaveChanges();

        return RedirectToAction("OneDish", new{id=id});
    }
    return View("Edit", OldDish);
}

[HttpPost("dishes/{id}/destroy")]
public IActionResult Destroy(int id)
{
    Dish? DishToDelete= _context.Dishes.SingleOrDefault(i => i.DishId ==id);
    _context.Dishes.Remove(DishToDelete);
    _context.SaveChanges();
    return RedirectToAction("Index");
}

}