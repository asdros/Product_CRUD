﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Product_CRUD.Interfaces;
using Product_CRUD.Models;
using Product_CRUD.Models.DTO;
using Product_CRUD.Models.Entities;

namespace Product_CRUD.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ApplicationContext _context;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public ProductsController(ApplicationContext context, ILoggerManager logger, IMapper mapper)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
        }

        // GET: Products
        public async Task<ViewResult> Index(string sortOrder, string searchString)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.CategorySortParm = sortOrder == "Category" ? "category_desc" : "Category";
            ViewBag.PriceSortParm = sortOrder == "Price" ? "price_desc" : "Price";

            var productsFromDB = await _context.Products
                                    .Include(p => p.Category)
                                    .Include(p=>p.Tax)
                                    .ToListAsync();

            var products = _mapper.Map<IEnumerable<ProductToDisplayDTO>>(productsFromDB);

            if (!String.IsNullOrEmpty(searchString))
            {
                products = products.Where(p => p.Name.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    products = products.OrderByDescending(p => p.Name);
                    break;
                case "Category":
                    products = products.OrderBy(p => p.CategoryName);
                    break;
                case "category_desc":
                    products = products.OrderByDescending(p => p.CategoryName);
                    break;
                case "Price":
                    products = products.OrderBy(p => p.NettoPrice);
                    break;
                case "price_desc":
                    products = products.OrderByDescending(p => p.NettoPrice);
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
            ViewData["TaxId"] = new SelectList(_context.Taxes, "Id", "DisplayValue");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,CategoryId,NetPrice,TaxId")] Product product)
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

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                _logger.LogInfo($"Id: {id} of product is incorrect.");
                return RedirectToAction("Index");
            }

            var product = await _context.Products
                            .Where(p => p.Id.Equals(id))
                            .SingleOrDefaultAsync();

            if (product == null)
            {
                _logger.LogInfo($"Not found a product with id: {id}.");
                return NotFound();
            }

            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "CategoryName", product.CategoryId);
            ViewData["TaxId"] = new SelectList(_context.Taxes, "Id", "DisplayValue", product.TaxId);
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name,CategoryId,NetPrice,TaxId")] Product product)
        {
            if (id != product.Id)
            {
                _logger.LogInfo($"Not found a product with id: {id}.");
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.Id))
                    {
                        _logger.LogError("Product object sent from the client does not exist in the database.");
                        return NotFound();
                    }
                    else
                    {
                        _logger.LogError("Internal application error when updating a record.");
                        throw;
                    }
                }

                return RedirectToAction(nameof(Index));
            }

            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "CategoryName", product.CategoryId);
            return View(product);
        }

        private bool ProductExists(Guid id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}
