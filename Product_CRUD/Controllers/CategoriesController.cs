using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Product_CRUD.Interfaces;
using Product_CRUD.Models;
using Product_CRUD.Models.Entities;

namespace Product_CRUD.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ApplicationContext _context;
        private readonly ILoggerManager _logger;

        public CategoriesController(ApplicationContext context, ILoggerManager logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: Categories
        public async Task<IActionResult> Index()
        {
            var categories = await _context.Categories
                                .ToListAsync();

            return View(categories);
        }

        // GET: Categories/Details/5
        public async Task<IActionResult> Details(short? id)
        {
            if (id == null)
            {
                _logger.LogInfo($"Id: {id} of category is incorrect.");
                return NotFound();
            }

            var category = await _context.Categories
                              .Where(c => c.Id.Equals(id))
                              .Include(c=>c.Products.Where(p=>p.CategoryId.Equals(c.Id)))
                              .SingleOrDefaultAsync();

            if (category == null)
            {
                _logger.LogInfo($"Category with id: {id} does not exist in a database.");
                return NotFound();
            }

            return View(category);
        }

        // GET: Categories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Categories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CategoryName")] Category category)
        {
            if (ModelState.IsValid)
            {
                _context.Add(category);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }
    }
}
