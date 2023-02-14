using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Filters;
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
    [HttpGet("")]    
    public IActionResult Index()    
    {     
        return View();    
    } 

    [HttpPost("registration")]   
    public IActionResult CreateUser(User newUser)    
    {        
        if(ModelState.IsValid)        
        {
            // Initializing a PasswordHasher object, providing our User class as its type            
            PasswordHasher<User> Hasher = new PasswordHasher<User>();   
            // Updating our newUser's password to a hashed version         
            newUser.Password = Hasher.HashPassword(newUser, newUser.Password);            
            //Save your user object to the database 
            _context.Add(newUser);
            _context.SaveChanges();
            HttpContext.Session.SetInt32("UserId", newUser.UserId);
            return RedirectToAction("Dashboard");       
        } else {
            return View("Index");
        }   
    }

    [SessionCheck]
    [HttpGet("dashboard/{id}")]
    public IActionResult Dashboard(int id)
    {
        User user= _context.Users.FirstOrDefault(u=> u.UserId==id);
        return View("Dashboard", user);
    }

    [HttpPost("login")]
    public IActionResult Login(LoginUser userSubmission)
    {    
        if(ModelState.IsValid)    
        {        
            // If initial ModelState is valid, query for a user with the provided email        
            User? userInDb = _context.Users.FirstOrDefault(u => u.Email == userSubmission.Email);        
            // If no user exists with the provided email        
            if(userInDb == null)        
            {            
                // Add an error to ModelState and return to View!            
                ModelState.AddModelError("Email", "Invalid Email/Password");            
                return View("Index");        
            }   
            // Otherwise, we have a user, now we need to check their password                 
            // Initialize hasher object        
            PasswordHasher<LoginUser> hasher = new PasswordHasher<LoginUser>();                    
            // Verify provided password against hash stored in db        
            var result = hasher.VerifyHashedPassword(userSubmission, userInDb.Password, userSubmission.Password);                                    

            if(result == 0)        
            {            
                ModelState.AddModelError("Password", "Invalid Email/Password");            
                return View("Index");        
            } 
            
            HttpContext.Session.SetInt32("UserId", userInDb.UserId);
            
            return Dashboard(userInDb.UserId);
        } else 
        {
            return View("Index");
        }
    }

    
    [HttpPost("/logout")]
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Index");
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