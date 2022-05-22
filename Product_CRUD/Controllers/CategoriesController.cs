using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Product_CRUD.Interfaces;
using Product_CRUD.Models;
using Product_CRUD.Models.DTO;
using Product_CRUD.Models.Entities;

namespace Product_CRUD.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ApplicationContext _context;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public CategoriesController(ApplicationContext context, ILoggerManager logger, IMapper mapper)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
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

            var categoryFromDB = await _context.Categories
                              .Where(c => c.Id.Equals(id))
                              .SingleOrDefaultAsync();

            if (categoryFromDB == null)
            {
                _logger.LogInfo($"Category with id: {id} does not exist in a database.");
                return NotFound();
            }

            var productsFromDb = await _context.Products
                                .Where(p => p.CategoryId.Equals(id))
                                .Include(p => p.Tax)
                                .ToListAsync();

            var categoryDTO = _mapper.Map<CategoryToDisplayDTO>(categoryFromDB);

            categoryDTO.ProductToDisplayDTOs = _mapper.Map<ICollection<ProductToDisplayDTO>>(productsFromDb);

            return View(categoryDTO);
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

        // GET: Categories/Delete/5
        public async Task<IActionResult> Delete(short? id)
        {
            if (id == null)
            {
                _logger.LogInfo($"Id: {id} of category is incorrect.");
                return NotFound();
            }

            var category = await _context.Categories
                            .Where(p => p.Id.Equals(id))
                            .SingleOrDefaultAsync();

            if (category == null)
            {
                _logger.LogInfo($"Not found a category with id: {id}.");
                return NotFound();
            }

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");

        }
    }
}
