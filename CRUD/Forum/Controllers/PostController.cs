using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Filters;
using Forum.Models;

namespace Forum.Controllers;

public class ForumController : Controller
{
    private readonly ILogger<ForumController> _logger;
    
    private MyContext _context;  
    public ForumController(ILogger<ForumController> logger, MyContext context)    
    {        
        _logger = logger;
        _context = context;    
    } 

    // [HttpGet("")]
    // public IActionResult Registration()
    // {
    //     return View("LoginAndRegistration");
    // }
    [SessionCheck]
    [HttpGet("/posts/add")]
    public IActionResult NewPost()
    {
        return View("NewPost");
    }

    
    [HttpPost("posts/new")]
    public IActionResult CreatePost(Post newPost)
    {
        if(!ModelState.IsValid)
        {
            return View("NewPost");
        }
        _context.Posts.Add(newPost);
        _context.SaveChanges();
        return RedirectToAction("AllPosts");
    }

    [HttpPost("posts/{postId}/delete")]
    public IActionResult DeletePost(int postId)
    {
        Post? post = _context.Posts.FirstOrDefault(p => p.PostId == postId);

        if(post != null)
        {
            _context.Posts.Remove(post);
            _context.SaveChanges();
        }
        return RedirectToAction("AllPosts");
    }


    [HttpPost("posts/{postId}/update")]
    public IActionResult Update(Post editedPost, int postId)
    {
        

        if(!ModelState.IsValid)
        {
            return Edit(postId);
        }
        
        Post? post = _context.Posts.FirstOrDefault(p => p.PostId == postId);
        if (post==null)
        {
        return RedirectToAction("AllPosts");
        }

        post.Topic=editedPost.Topic;
        post.Body=editedPost.Body;
        post.ImgUrl=editedPost.ImgUrl;
        post.UpdatedAt=DateTime.Now;

        _context.Posts.Update(post);
        _context.SaveChanges();
        return RedirectToAction("OnePost", new{postId=postId});
    }

    [SessionCheck]
    [HttpGet("posts/{postId}/edit")]
    public IActionResult Edit(int postId)
    {
        Post? post = _context.Posts.FirstOrDefault(p => p.PostId == postId);

        return View("Edit", post);
    }


    [SessionCheck]
    [HttpGet("/posts/{postId}")]
    public IActionResult OnePost(int postId)
    {
        Post? post= _context.Posts.FirstOrDefault(post => post.PostId ==postId);
        if(post ==null)
        {
            return RedirectToAction("AllPosts");
        }
        return View("OnePost", post);
    }

    [SessionCheck]
    [HttpGet("/posts")]
    public IActionResult AllPosts()
    {
        List<Post> allPosts = _context.Posts.ToList();
        return View("AllPosts", allPosts);
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