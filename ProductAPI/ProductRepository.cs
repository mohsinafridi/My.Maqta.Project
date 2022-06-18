using ProductAPI.Models;

namespace ProductAPI
{
    public class ProductRepository : IProductRepository
    {
        private readonly List<Product> products = new List<Product>();
        public ProductRepository()
        {
            products.Add(new Product
            {
                Id = Guid.NewGuid(),
                Name = "P0001",
                Description = "Lenovo Laptop",                
                UnitPrice = 125000
            });

            products.Add(new Product
            {
                Id = Guid.NewGuid(),
                Name = "P0002",
                Description = "DELL Laptop",                
                UnitPrice = 135000
            });

            products.Add(new Product
            {
                Id = Guid.NewGuid(),
                Name = "P0003",
                Description = "HP Laptop",                
                UnitPrice = 115000
            });
        }
        public Task<List<Product>> GetAllProducts()
        {
            return Task.FromResult(products);
        }
        
    }
}
