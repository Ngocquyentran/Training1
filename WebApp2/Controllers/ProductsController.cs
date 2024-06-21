using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp2.Models;
using WebApp2.Services;

namespace WebApp2.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        private readonly ProductsContext _context;
        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository, ProductsContext context)
        {
            _context = context;
            _productRepository = productRepository;
        }

        [HttpGet("all")]
        public IActionResult GetAll()
        {
            var listProduct = _context.Products.ToList();
            return Ok(listProduct);
        }

        [HttpGet("name")]
        public IActionResult GetByName(string search=null, int page=1) 
        {
            try
            {
                var result= _productRepository.GetProductsByName(search, page);
                return Ok(result);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpGet("type")]
        public IActionResult GetByType(string search = null, int page = 1)
        {
            try
            {
                var result = _productRepository.GetProductsByType(search, page);
                return Ok(result);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpGet("brand")]
        public IActionResult GetByBrand(string search = null, int page = 1)
        {
            try
            {
                var result = _productRepository.GetProductsByBrand(search, page);
                return Ok(result);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpGet("category")]
        public IActionResult GetByCategory(string search = null, int page = 1)
        {
            try
            {
                var result = _productRepository.GetProductsByCategory(search, page);
                return Ok(result);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var product = _context.Products.SingleOrDefault(x => x.Id == id);
                if (product == null)
                {
                    return NotFound();
                }
                return Ok(product);
            }
            catch
            {
                return BadRequest();
            }

        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            try
            {
                var product1 = new Product
                {
                    Code = product.Code,
                    Name = product.Name,
                    Category = product.Category,
                    Type = product.Type,
                    Brand = product.Brand,
                    Description = product.Description
                };

                _context.Add(product1);
                _context.SaveChangesAsync();
                return Ok(new
                {
                    Success = true,
                    Data = product1
                });
            }
            catch
            {
                return BadRequest();
            }
            
            //return RedirectToAction(nameof(GetAll));
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Product product)
        {
            try
            {
                var product1 = _context.Products.SingleOrDefault(x => x.Id == id);
                if (product1 == null)
                {
                    return NotFound();
                }
                product1.Code = product.Code;
                product1.Name = product.Name;
                product1.Category = product.Category;
                product1.Type = product.Type;
                product1.Brand = product.Brand;
                product1.Description = product.Description;

                _context.SaveChangesAsync();
                return Ok(new
                {
                    Success = true,
                    Data = product1
                });
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var product = _context.Products.SingleOrDefault(x => x.Id == id);
                if (product == null)
                {
                    return NotFound();
                }
                _context.Remove(product);
                _context.SaveChangesAsync();
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

    }
}
