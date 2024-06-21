using WebApp2.Models;

namespace WebApp2.Services
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductsContext _context;
        public static int pageSize { get; set; } = 5;
        public ProductRepository(ProductsContext context)
        {
            _context = context;
        }
        public List<Product> GetProductsByName(string search = null, int page = 1)
        {

            var products = _context.Products.AsQueryable();
            #region Filter
            if (!string.IsNullOrEmpty(search))
            {
               products =  products.Where(prduct => prduct.Name.Contains(search));
            }
            #endregion

            #region Pagination
            products = products.Skip((page - 1) * pageSize).Take(pageSize);
            #endregion

            var result = products.Select(prduct => new Product
            {
                Id = prduct.Id,
                Code = prduct.Code,
                Name = prduct.Name,
                Category = prduct.Category,
                Brand = prduct.Brand,
                Type = prduct.Type,
                Description = prduct.Description
            });
            return result.ToList();
        }
        public List<Product> GetProductsByType(string search = null, int page = 1)
        {

            var products = _context.Products.AsQueryable();
            #region Filter
            if (!string.IsNullOrEmpty(search))
            {
                products = products.Where(prduct => prduct.Type.Contains(search));
            }
            #endregion

            #region Pagination
            products = products.Skip((page - 1) * pageSize).Take(pageSize);
            #endregion

            var result = products.Select(prduct => new Product
            {
                Id = prduct.Id,
                Code = prduct.Code,
                Name = prduct.Name,
                Category = prduct.Category,
                Brand = prduct.Brand,
                Type = prduct.Type,
                Description = prduct.Description
            });
            return result.ToList();
        }
        public List<Product> GetProductsByBrand(string search = null, int page = 1)
        {

            var products = _context.Products.AsQueryable();
            #region Filter
            if (!string.IsNullOrEmpty(search))
            {
                products = products.Where(prduct => prduct.Brand.Contains(search));
            }
            #endregion

            #region Pagination
            products = products.Skip((page - 1) * pageSize).Take(pageSize);
            #endregion

            var result = products.Select(prduct => new Product
            {
                Id = prduct.Id,
                Code = prduct.Code,
                Name = prduct.Name,
                Category = prduct.Category,
                Brand = prduct.Brand,
                Type = prduct.Type,
                Description = prduct.Description
            });
            return result.ToList();
        }
        public List<Product> GetProductsByCategory(string search = null, int page = 1)
        {

            var products = _context.Products.AsQueryable();
            #region Filter
            if (!string.IsNullOrEmpty(search))
            {
                products = products.Where(prduct => prduct.Category.Contains(search));
            }
            #endregion

            #region Pagination
            products = products.Skip((page - 1) * pageSize).Take(pageSize);
            #endregion

            var result = products.Select(prduct => new Product
            {
                Id = prduct.Id,
                Code = prduct.Code,
                Name = prduct.Name,
                Category = prduct.Category,
                Brand = prduct.Brand,
                Type = prduct.Type,
                Description = prduct.Description
            });
            return result.ToList();
        }
    }
}
