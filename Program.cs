namespace MyWebApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllers();
            builder.Services.AddScoped<IDatabaseConnection, DBConnection>();
            var app = builder.Build();


            app.Run();
        }
    }
}
