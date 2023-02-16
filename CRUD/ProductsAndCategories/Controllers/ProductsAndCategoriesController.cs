using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductsAndCategories.Models;

namespace ProductsAndCategories.Controllers;

public class ProductsAndCategoriesController : Controller
{
    private readonly ILogger<ProductsAndCategoriesController> _logger;
    
    private MyContext _context;  
    public ProductsAndCategoriesController(ILogger<ProductsAndCategoriesController> logger, MyContext context)    
    {        
        _logger = logger;
        _context = context;    
    } 

    [HttpGet("")]
    public IActionResult Index()
    {
        List<Product> Products= _context.Products.Include(c=>c.Categories).ToList();
        ViewModel viewModel= new ViewModel {AllProducts=Products};
        return View("Index", viewModel);
    }
    
    [HttpPost("products/create")]
    public IActionResult CreateProduct(ViewModel newViewModel)
    {
        Console.WriteLine(newViewModel.Product.Name);
        Product product = new Product
        {
            Name = newViewModel.Product.Name,
            Description =newViewModel.Product.Description,
            Price= newViewModel.Product.Price,
        };
    
        if (ModelState.IsValid)
        {
            
            _context.Products.Add(product);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        if (!ModelState.IsValid)
{
    foreach (var error in ModelState.Values)
    {
        foreach (var errorMessage in error.Errors)
        {
            Console.WriteLine(errorMessage.ErrorMessage);
        }
    }
}
        List<Product> Products= _context.Products.Include(c=>c.Categories).ToList();
        ViewModel viewModel= new ViewModel {AllProducts=Products};
        return View("Index", viewModel);
    }

    [HttpGet("categories")]
    public IActionResult Categories()
    {
        List<Category> Categories= _context.Categories.Include(c=>c.Products).ToList();
        ViewModel viewModel= new ViewModel {AllCategories=Categories};
        return View("Categories", viewModel);
    }

    [HttpPost("categories/create")]
    public IActionResult CreateCategory(ViewModel newViewModel)
    {
        Console.WriteLine(newViewModel.Category.Name);
        Category category = new Category
        {
            Name = newViewModel.Category.Name,
            
        };
    
        if (ModelState.IsValid)
        {
            Console.WriteLine("In the valid if " + category);
            _context.Categories.Add(category);
            _context.SaveChanges();
            return RedirectToAction("Categories");
        }
        if (!ModelState.IsValid)
{
    foreach (var error in ModelState.Values)
    {
        foreach (var errorMessage in error.Errors)
        {
            Console.WriteLine(errorMessage.ErrorMessage);
        }
    }
}
        List<Category> Categories= _context.Categories.Include(c=>c.Products).ToList();
        ViewModel viewModel= new ViewModel {AllCategories=Categories};
        return View("Categories", viewModel);
    }

    [HttpGet("categories/{id}")]
    public IActionResult OneCategory(int id)
    {
        // Category? OneCategory= _context.Categories.Include(c=> c.Products).ThenInclude(c=>c.Category).FirstOrDefault(c=> c.CategoryId==id);
        Category? OneCategory= _context.Categories.Include(c=> c.Products).ThenInclude(c=>c.Product).FirstOrDefault(c=> c.CategoryId==id);
        List<Product> products = _context.Products
            .Where(c => !_context.ProductsAndCategories
            .Any(pc => pc.ProductId == c.ProductId && pc.CategoryId == id))
            .Include(c => c.Categories)
            .ToList();

        // List<Product> Products= _context.Products.Include(p=>p.Categories).ToList();
        ViewModel viewModel= new ViewModel {AllProducts=products, Category=OneCategory};
        HttpContext.Session.SetString("RedirectAction", $"http://localhost:5101/categories/{id}");
        return View("Category", viewModel);
    }

    [HttpPost("products/categories/set/")]
    public IActionResult CreateLink(ViewModel newViewModel)
    {
        Console.WriteLine(newViewModel.ProductAndCategory.CategoryId);
        ProductAndCategory newLink= new ProductAndCategory
        {
            CategoryId= newViewModel.ProductAndCategory.CategoryId,
            ProductId= newViewModel.ProductAndCategory.ProductId,
        };

        if (ModelState.IsValid)
        {
            
            _context.ProductsAndCategories.Add(newLink);
            _context.SaveChanges();
            string redirectRoute = HttpContext.Session.GetString("RedirectAction");
            HttpContext.Session.Clear();
            return Redirect(redirectRoute);
            // return RedirectToAction("Categories");
        }
                if (!ModelState.IsValid)
        {
            foreach (var error in ModelState.Values)
            {
                foreach (var errorMessage in error.Errors)
                {
                    Console.WriteLine(errorMessage.ErrorMessage);
                }
            }
        }
        List<Category> Categories= _context.Categories.Include(c=>c.Products).ToList();
        ViewModel viewModel= new ViewModel {AllCategories=Categories};
        return View("Categories", viewModel);

    }

    [HttpPost("/products/categories/remove/{categoryId}/{productId}")]
    public IActionResult DestroyLink(int categoryId, int productId)
    {
        ProductAndCategory? toDelete= _context.ProductsAndCategories.FirstOrDefault(pc=>pc.CategoryId.Equals(categoryId) && pc.ProductId.Equals(productId));
        Console.WriteLine(toDelete.ProductAndCategoryId);
        if (toDelete is not null) {
        _context.ProductsAndCategories.Remove(toDelete);
        _context.SaveChanges();
        string redirectRoute = HttpContext.Session.GetString("RedirectAction");
        HttpContext.Session.Clear();
        return Redirect(redirectRoute);
        }
    return View("Index");
    }

    [HttpGet("products/{id}")]
    public IActionResult OneProduct(int id)
    {
        
        Product? OneProduct= _context.Products.Include(p=> p.Categories).ThenInclude(c=>c.Category).FirstOrDefault(p=> p.ProductId==id);
        List<Category> categories = _context.Categories
            .Where(c => !_context.ProductsAndCategories
            .Any(pc => pc.CategoryId == c.CategoryId && pc.ProductId == id))
            .Include(c => c.Products)
            .ToList();
        // List<Category> Categories= _context.Categories.Include(c=>c.Products).ToList();
        ViewModel viewModel= new ViewModel {AllCategories=categories, Product=OneProduct};
        HttpContext.Session.SetString("RedirectAction", $"http://localhost:5101/products/{id}");
        return View("Product", viewModel);
    }

}
