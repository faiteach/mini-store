using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Mvc;
using mini_store.Models;
using mini_store.Data;

namespace mini_store.Controllers;

public class HomeController : Controller
{
   
     private static List<dynamic> _cart= new List<dynamic>();

private static dynamic[] _categories =
{
new { Id = 0, Name = "إلكترونيات", Icon = "fa-solid fa-bolt-lightning" },
new { Id = 1, Name = "ملابس", Icon = "fa-solid fa-shirt" },
new { Id = 2, Name = "كتب", Icon = "fas fa-book-open" }
};
private static dynamic[] _products =
{
 new
    {
        CategoryId = 0,
        Name = "هاتف ذكي",
        Price = 2500,
        Description = "هاتف ذكي بكاميرا عالية الدقة",
        Image = "phone.jpg"
    },

    new
    {
        CategoryId = 0,
        Name = "حاسوب محمول",
        Price = 4500,
        Description = "حاسوب محمول مناسب للمطورين",
        Image = "laptop.jpg"
    },

    new
    {
        CategoryId = 0,
        Name = "سماعات لاسلكية",
        Price = 350,
        Description = "سماعات بجودة صوت ممتازة",
        Image = "headphones.jpg"
    },

    new
    {
        CategoryId = 0,
        Name = "ساعة ذكية",
        Price = 600,
        Description = "ساعة ذكية لمتابعة النشاط اليومي",
        Image = "smartwatch.jpg"
    },

    new
    {
        CategoryId = 1,
        Name = "قميص قطني",
        Price = 150,
        Description = "قميص مريح للاستخدام اليومي",
        Image = "shirt.jpg"
    },

    new
    {
        CategoryId = 1,
        Name = "جاكيت شتوي",
        Price = 300,
        Description = "جاكيت دافئ وأنيق",
        Image = "jacket.jpg"
    },

    new
    {
        CategoryId = 1,
        Name = "بنطال جينز",
        Price = 200,
        Description = "جينز عصري ومريح",
        Image = "jeans.jpg"
    },

    new
    {
        CategoryId = 2,
        Name = "كتاب برمجة",
        Price = 90,
        Description = "دليل شامل لتعلم البرمجة",
        Image = "book.jpg"
    },

    new
    {
        CategoryId = 2,
        Name = "رواية",
        Price = 75,
        Description = "رواية ممتعة للقراءة",
        Image = "novel.jpg"
    },

    new
    {
        CategoryId = 2,
        Name = "كتاب تطوير الذات",
        Price = 110,
        Description = "كتاب يساعد على تطوير المهارات الشخصية",
        Image = "selfhelp.jpg"
    }
};


    public IActionResult Index()
    {
        ViewBag.CategoriesList = _categories;
        return View();
    }
    public IActionResult Products(int id)
    {
        var filtered = _products 
        .Where(p => p.CategoryId == id)
        .ToList();
        ViewBag.FilteredProducts = filtered;
        ViewBag.CategoryName = _categories[id];
        return View();
    }
    public IActionResult Details(string name)
    {
        var Product= _products.FirstOrDefault(p => p.Name == name);

         if (Product == null)
        {
            return NotFound();
        }
        ViewBag.Product=Product;
        return View();
    }
   
    public IActionResult AddToCart(String name)
    {
        var pro = _products.FirstOrDefault(p => p.Name == name);
         if(pro != null)
        {
            _cart.Add(pro);
        }
        return RedirectToAction("Cart");
    }
    public IActionResult Cart()
{
    ViewBag.CartItems = _cart;
    ViewBag.Count = _cart.Count;
    ViewBag.Total = _cart.Sum(p => (decimal)p.Price);

    return View();
}
    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
