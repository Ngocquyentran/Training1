using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models
{
    public class ViewController : Controller
    {
        private readonly ProductsContext _context;
        private readonly IConfiguration _configuration;

        public ViewController(ProductsContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        // GET: View
        public async Task<IActionResult> Index(int page=1)
        {
            List<Product> product = _context.Products.ToList();
            const int pageSize = 5;
            if (page < 1) page = 1;
            int recCount = product.Count();
            var pagination = new Pager(recCount, page, pageSize);
            int recSkip =(page-1)*pageSize;
            var data = product.Skip(recSkip).Take(pagination.PageSize).ToList();
            this.ViewBag.Pager = pagination;
            return View(data);
        }

        public IActionResult Create()
        {
            return View();
        }

        // POST: View/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Code,Name,Category,Brand,Type,Description")] Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }
        
    }
    
}
