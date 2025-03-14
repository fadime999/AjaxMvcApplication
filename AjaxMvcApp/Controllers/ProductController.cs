using AjaxMvcApp.Data;
using AjaxMvcApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace AjaxMvcApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _context;
        
        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var products = _context.Products.ToList(); // ❌ Eğer _context null ise hata olur
            return View(products);
        }

        [HttpGet]
        public JsonResult SearchProducts(string searchTerm)
        {
            var productNames = _context.Products
                .Where(p => p.Name.StartsWith(searchTerm)) // Arama işlemi
                .ToList();

            return Json(productNames);
        }
        // Ürün Ekleme İşlemi
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid) // Model doğrulaması
            {
                _context.Products.Add(product);
                _context.SaveChanges();
                return RedirectToAction("Index"); // Ürün eklenince listeye yönlendir
            }

            return View(product); // Hata olursa tekrar formu göster
        }
    }
}
