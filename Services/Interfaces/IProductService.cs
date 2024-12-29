using MyWebApplication.Models;

namespace MyWebApplication.Services.Interfaces
{
    public interface IProductService
    {
        public IEnumerable<Product> GetAllProducts();
        public Product GetProductById(int id);
        public Product CreateProduct(Product product);
        public bool UpdateProduct(Product product);
        public bool DeleteProduct(int id);
    }
}