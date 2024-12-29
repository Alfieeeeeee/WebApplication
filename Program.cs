using MyWebApplication.Repository;
using MyWebApplication.Repository.Interfaces;
using MyWebApplication.Services.Interfaces;
using MyWebApplication.Services;
using static MyWebApplication.Repository.DBConnection;

namespace MyWebApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllers();
            builder.Services.AddScoped<IDatabaseConnection, DBConnection>();
            builder.Services.AddScoped<IProductRepository, ProductRepository>();
            builder.Services.AddScoped<IProductService, ProductService>();
            var app = builder.Build();

            app.Run();
        }
    }
}
