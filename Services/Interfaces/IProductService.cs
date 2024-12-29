using MyWebApplication.Models;

namespace MyWebApplication.Services.Interfaces
{
    public interface IProductService
    {
        IEnumerable<Product> GetAllProducts();
        Product GetProductById(int id);
        Product CreateProduct(Product product);
        bool UpdateProduct(Product product);
        bool DeleteProduct(int id);
    }
}