using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Session.Models;

namespace Session.Controllers;


public class SessionController : Controller
{
    [HttpGet("")]
    public ViewResult Index()
    {
        return View();
    }

    [HttpPost("process")]
    public IActionResult Process(User user)
    {
        if(ModelState.IsValid)
        {
            HttpContext.Session.SetString("UserName", user.Name);
            HttpContext.Session.SetInt32("Count", 22);
            string? LocalVariable = HttpContext.Session.GetString("UserName");
            int? IntVariable = HttpContext.Session.GetInt32("Count");
            return RedirectToAction("Game");
        }
        return View("Index");
    }

    [HttpPost("counterProcess")]
    public IActionResult CounterProcess(string mathfunction)
    {
        int IntVariable = HttpContext.Session.GetInt32("Count") ?? 0;
        
        Random rand= new Random();
        if(mathfunction=="+1")
        {
            IntVariable+=1;
            HttpContext.Session.SetInt32("Count", IntVariable);
            Console.WriteLine(IntVariable);
        }
        if(mathfunction=="-1")
        {
            IntVariable-=1;
            HttpContext.Session.SetInt32("Count", IntVariable);
        }
        if(mathfunction=="x2")
        {
            IntVariable*=2;
            HttpContext.Session.SetInt32("Count", IntVariable);
        }
        if(mathfunction=="random")
        {
            IntVariable+=(rand.Next(1,10));
            HttpContext.Session.SetInt32("Count", IntVariable);
        }
        return RedirectToAction("Game");
    }

    [HttpGet("game")]
    public IActionResult Game(User user)
    {
        if(HttpContext.Session.GetString("UserName")!=null){
        return View("game");
        }
        return View("Index");
    }

    [HttpPost("logout")]
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return View("Index");
    }
}
