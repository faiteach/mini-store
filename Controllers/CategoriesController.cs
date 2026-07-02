using Microsoft.AspNetCore.Mvc;
using mini_store.Models;
using mini_store.Data;

namespace mini_store.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly AppDbContext _context;

        public CategoriesController(AppDbContext cn )
        {
            _context=cn;
        }

        public IActionResult Index()
        {

            var categories=_context.categories.ToList();
            return View(categories);
        }
        

        [HttpPost]
        public IActionResult Create(Categories categories)
        {
            _context.categories.Add(categories);

            _context.SaveChanges();

            return RedirectToAction("Index");

        }
    }
}