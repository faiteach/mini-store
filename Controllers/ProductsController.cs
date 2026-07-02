using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mini_store.Models;
using mini_store.Data;
namespace mini_store.Controllers;

    public class ProductController : Controller
    {
        private readonly AppDbContext _context;
        public ProductController(AppDbContext context)
        {
            _context = context;
        }
    
    [Route("dashboard")]
    public IActionResult Index()
    {
        ViewBag.Categories = _context.categories.ToList();
        var products = _context.products.Include(p => p.Categories).ToList();
        return View(products);
    }

    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Create(Product product)
    {
        _context.products.Add(product);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }
    public IActionResult Delete(int id)
    {
        var product = _context.products.Find(id);
        if (product != null)
        {
            _context.products.Remove(product);
            _context.SaveChanges();
        }
        return RedirectToAction(nameof(Index));
    }
   
    public IActionResult Edit(int id)
    {
        var product= _context.products.Find(id);
          var categories=_context.categories.ToList();
            ViewBag.categories=categories;
        if(product==null)
        {
            return NotFound();
        }
        return View(product);
    }
    [HttpPost]
    public IActionResult Edit(Product product)
    {
        _context.products.Update(product);
        _context.SaveChanges();

        return RedirectToAction("Index");
    }

}
