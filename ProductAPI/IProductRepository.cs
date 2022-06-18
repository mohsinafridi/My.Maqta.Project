using ProductAPI.Models;

namespace ProductAPI
{
    public interface IProductRepository
    {
        public Task<List<Product>> GetAllProducts();
    }
}
