using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using WeddingPlanner.Models;
namespace WeddingPlanner.Controllers;    
public class WeddingPlannerController : Controller
{    
    private readonly ILogger<WeddingPlannerController> _logger;
    private MyContext _context;  
    public WeddingPlannerController(ILogger<WeddingPlannerController> logger, MyContext context)    
    {        
        _logger = logger;
        _context = context;    
    }         
    


    [SessionCheck]
    [HttpGet("dashboard/{id}")]
    public IActionResult Dashboard(int id)
    {
        User? user= _context.Users.FirstOrDefault(u=> u.UserId==id);
        List<Wedding>? allWeddings = _context.Weddings
            .Include(w => w.Creator)
            .Include(w => w.Guests)
                .ThenInclude(g => g.User)
            .ToList();
        ViewModel viewModel= new ViewModel{User=user, Weddings=allWeddings};
        return View("Dashboard", viewModel);
    }

    [SessionCheck]
    [HttpGet("weddings/new")]
    public IActionResult NewWedding()
    {
        return View("CreateWedding");
    }

    [HttpGet("weddings/{id}")]
    public IActionResult OneWedding(int id)
    {
        Wedding? OneWedding= _context.Weddings
                .Include(w=>w.Guests)
                .ThenInclude(g=>g.User)
                .FirstOrDefault(w => w.WeddingId== id);
        return View("OneWedding", OneWedding);
    }

    [HttpPost("weddings/create/{userId}")]
    public IActionResult CreateWedding(Wedding newWedding, int userId)
    {
        if(!ModelState.IsValid)
        {
            return View("CreateWedding");
        }

        User? creator= _context.Users.FirstOrDefault(u=> u.UserId==userId);
        newWedding.Creator=creator;
        _context.Weddings.Add(newWedding);
        _context.SaveChanges();

        return RedirectToAction("OneWedding", new{id=newWedding.WeddingId});
    }

    [HttpPost("weddings/guests/create/{userId}/{weddingId}")]
    public IActionResult CreateGuest(int userId, int weddingId)

    {
        if(!ModelState.IsValid)
        {
        return Dashboard(userId);
        }
        GuestList? toCreate= _context.GuestLists.FirstOrDefault(gl=>gl.UserId.Equals(userId) && gl.WeddingId.Equals(weddingId));
        if(toCreate==null)
        {
            GuestList newLink= new GuestList
        {
            UserId= userId,
            WeddingId= weddingId
        };

        _context.GuestLists.Add(newLink);
        _context.SaveChanges();

        return RedirectToAction("Dashboard", new{id=userId}); 
        }
        
        return View("Dashboard", new{id=userId});
    }

    [HttpPost("weddings/guests/remove/{userId}/{weddingId}")]
    public IActionResult RemoveGuest(int userId, int weddingId)

    {
        if(!ModelState.IsValid)
        {
        return Dashboard(userId);
        }

        GuestList? toDelete= _context.GuestLists.FirstOrDefault(gl=>gl.UserId.Equals(userId) && gl.WeddingId.Equals(weddingId));
        if (toDelete is not null) 
        {
        _context.GuestLists.Remove(toDelete);
        _context.SaveChanges();

        }
        return RedirectToAction("Dashboard", new{id=userId}); 
    }

    [HttpPost("weddings/destroy/{weddingId}")]
    public IActionResult DeleteWedding(int weddingId)
    {
        Wedding? ToDelete= _context.Weddings.FirstOrDefault(w => w.WeddingId== weddingId);
        if(ToDelete != null)
        {
            _context.Weddings.Remove(ToDelete);
            _context.SaveChanges();
        }
        int userId= HttpContext.Session.GetInt32("UserId")?? 0;
        return RedirectToAction("Dashboard", new{id=userId});
    }
}

public class SessionCheckAttribute : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        // Find the session, but remember it may be null so we need int?
        int? userId = context.HttpContext.Session.GetInt32("UserId");
        // Check to see if we got back null
        if(userId == null)
        {
            // Redirect to the Index page if there was nothing in session
            // "Home" here is referring to "HomeController", you can use any controller that is appropriate here
            context.Result = new RedirectToActionResult("Index", "Home", null);
        }
    }
}