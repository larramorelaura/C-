// This brings all the MVC features we need to this file
using Microsoft.AspNetCore.Mvc;
// Be sure to use your own project's namespace here! 
namespace DojoSurvey.Controllers;   
public class DojoSurveyController : Controller   // Remember inheritance?    
{      
    //home page with form
    [HttpGet("")]
    public ViewResult Index()
    {
        return View("index");
    }

    //post route for form
    [HttpPost("process")]
    public IActionResult Process(string TextName, string Location, string Language, string Comment)
    {  
        TempData["name"]=TextName;
        TempData["location"]=Location;
        TempData["language"]=Language;
        TempData["comment"]=Comment;
        

        Console.WriteLine($"My text was: {TextName}");
        
        return RedirectToAction("Results");
    }


    //results route
    [HttpGet("results")]
    public IActionResult Results()
    {
        ViewBag.name=TempData["name"];
        ViewBag.location=TempData["location"];
        ViewBag.language=TempData["language"];
        ViewBag.comment=TempData["comment"];

        return View("results");
    }
}