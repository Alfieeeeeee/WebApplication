using MyWebApplication.Models;
using MyWebApplication.Repository.Interfaces;
using MyWebApplication.Services.Interfaces;

namespace MyWebApplication.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public IEnumerable<Product> GetAllProducts()
        {
            return _productRepository.GetAllProducts();
        }

        public Product GetProductById(int id)
        {
            return _productRepository.GetProductById(id);
        }

        public Product CreateProduct(Product product)
        {
            return _productRepository.AddProduct(product);
        }

        public bool UpdateProduct(Product product)
        {
            return _productRepository.UpdateProduct(product);
        }

        public bool DeleteProduct(int id)
        {
            return _productRepository.DeleteProduct(id);
        }
    }
}