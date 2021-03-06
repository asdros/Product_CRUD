using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Product_CRUD.Interfaces;
using Product_CRUD.Models;
using Product_CRUD.Models.Entities;

namespace Product_CRUD.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ApplicationContext _context;
        private readonly ILoggerManager _logger;

        public ProductsController(ApplicationContext context, ILoggerManager logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: Products
        public  ViewResult Index(string sortOrder,string searchString)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.CategorySortParm = sortOrder == "Category" ? "category_desc" : "Category";
            ViewBag.PriceSortParm = sortOrder == "Price" ? "price_desc" : "Price";

            var products = from p in  _context.Products.Include(x=>x.Category)
                            select p;

            if(!String.IsNullOrEmpty(searchString))
            {
                products = products.Where(p => p.Name.Contains(searchString));
            }

            switch(sortOrder)
            {
                case "name_desc":
                    products = products.OrderByDescending(p => p.Name);
                    break;
                case "Category":
                    products = products.OrderBy(p => p.Category.CategoryName);
                    break;
                case "category_desc":
                    products = products.OrderByDescending(p => p.Category.CategoryName);
                    break;
                case "Price":
                    products = products.OrderBy(p => p.Price);
                    break;
                case "price_desc":
                    products = products.OrderByDescending(p => p.Price);
                    break;
                default:
                    products = products.OrderBy(p => p.Name);
                    break;
            }

            return View(products);
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                _logger.LogInfo($"Id: {id} of product is incorrect.");
                return NotFound();
            }

            var product = await _context.Products
                             .Where(p => p.Id.Equals(id))
                             .Include(p => p.Category)
                             .SingleOrDefaultAsync();

            if (product == null)
            {
                _logger.LogInfo($"Product with id: {id} does not exist in a database.");
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "CategoryName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,CategoryId,Price")] Product product)
        {
            if (product == null)
            {
                _logger.LogError("Product object sent from client is null.");
                return BadRequest("Product object is null");
            }

            if (!ModelState.IsValid)
            {
                _logger.LogError("Invalid model state for the Product object");
                return View(product);
            }

            _context.Add(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                _logger.LogInfo($"Id: {id} of product is incorrect.");
                return NotFound();
            }

            var product = await _context.Products
                            .Where(p => p.Id.Equals(id))
                            .SingleOrDefaultAsync();

            if (product == null)
            {
                _logger.LogInfo($"Not found a product with id: {id}.");
                return NotFound();
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");

        }
    }
}
