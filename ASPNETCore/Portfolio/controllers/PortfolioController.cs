// This brings all the MVC features we need to this file
using Microsoft.AspNetCore.Mvc;
// Be sure to use your own project's namespace here! 
namespace YourNamespace.Controllers;   
public class HelloController : Controller   // Remember inheritance?    
{      
    [HttpGet] // We will go over this in more detail on the next page    
    [Route("")] // We will go over this in more detail on the next page
    public string Index()        
    {            
    	return "This is my index";        
    } 
    [HttpGet("projects")]   
    [Route("projects")] // We will go over this in more detail on the next page
    public string Projects()        
    {            
    	return "These are my Projects!";        
    }   
    [HttpGet("contacts")] 
    [Route("contacts")] // We will go over this in more detail on the next page
    public string Contact()        
    {            
    	return "This is my contact";        
    }    
    
    [HttpGet("elsewhere")]
    public ViewResult Elsewhere()
    {
        // This would be a case where we have to specify the file name
        return View("Index");
    }
}