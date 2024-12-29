using Dapper;
using Microsoft.Data.SqlClient;
using MyWebApplication.Models;
using MyWebApplication.Repository.Interfaces;
using System.Data;
using static MyWebApplication.Repository.DBConnection;

namespace MyWebApplication.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly IDatabaseConnection _databaseConnection;

        public ProductRepository(IDatabaseConnection databaseConnection)
        {
            _databaseConnection = databaseConnection;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            using (var connection = _databaseConnection.GetConnection())
            {
                return connection.Query<Product>("SELECT * FROM Products").ToList();
            }
        }

        public Product GetProductById(int id)
        {
            using (var connection = _databaseConnection.GetConnection())
            {
                return connection.QueryFirstOrDefault<Product>("SELECT * FROM Products WHERE ProductID = @Id", new { Id = id });
            }
        }

        public Product AddProduct(Product product)
        {
            using (var connection = _databaseConnection.GetConnection())
            {
                var sql = "INSERT INTO Products (ProductName, SupplierID, CategoryID, QuantityPerUnit, UnitPrice) VALUES (@ProductName, @SupplierID, @CategoryID, @QuantityPerUnit, @UnitPrice); SELECT CAST(SCOPE_IDENTITY() as int)";
                var id = connection.Query<int>(sql, product).Single();
                product.ProductID = id;
                return product;
            }
        }

        public bool UpdateProduct(Product product)
        {
            using (var connection = _databaseConnection.GetConnection())
            {
                var sql = "UPDATE Products SET ProductName = @ProductName, SupplierID = @SupplierID, CategoryID = @CategoryID, QuantityPerUnit = @QuantityPerUnit, UnitPrice = @UnitPrice WHERE ProductID = @ProductID";
                var rowsAffected = connection.Execute(sql, product);
                return rowsAffected > 0;
            }
        }

        public bool DeleteProduct(int id)
        {
            using (var connection = _databaseConnection.GetConnection())
            {
                var sql = "DELETE FROM Products WHERE ProductID = @Id";
                var rowsAffected = connection.Execute(sql, new { Id = id });
                return rowsAffected > 0;
            }
        }
    }
}