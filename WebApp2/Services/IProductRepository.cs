using WebApp2.Models;

namespace WebApp2.Services
{
    public interface IProductRepository
    {
        List<Product> GetProductsByName(string search = null, int page = 1);
        List<Product> GetProductsByType(string search = null, int page = 1);
        List<Product> GetProductsByBrand(string search = null, int page = 1);
        List<Product> GetProductsByCategory(string search = null, int page = 1);
    }
}
