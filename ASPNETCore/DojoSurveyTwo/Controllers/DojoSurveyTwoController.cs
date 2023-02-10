using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DojoSurveyTwo.Models;   
public class DojoSurveyTwoController : Controller   // Remember inheritance?    
{      
    //home page with form
    [HttpGet("")]
    public ViewResult Index()
    {
        return View("index");
    }

    //post route for form
    [HttpPost("process")]
    public IActionResult Process(Survey survey)
    {  
        Console.WriteLine(survey.Name);
        if(ModelState.IsValid){
        return RedirectToAction("Results", survey);
        }
        else{
            return View("index");
        }
    }


    //results route
    [HttpGet("results")]
    public IActionResult Results(Survey survey)
    {
        // ViewBag.TextName=survey.TextName;
        // ViewBag.Location=survey.Location;
        // ViewBag.Language=survey.Language;
        // ViewBag.Comment=survey.Comment;

        return View("results", survey);
    }
}