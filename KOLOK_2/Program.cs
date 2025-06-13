using KOLOK_2.DAL;
using KOLOK_2.Services;
using Microsoft.EntityFrameworkCore;

namespace KOLOK_2;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddAuthorization();

     

        
        builder.Services.AddControllers();
        builder.Services.AddDbContext<NewDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));
        
        builder.Services.AddScoped<IDbService, DbService>();
        
        
        var app = builder.Build();

        
        app.MapControllers();
        
        app.UseHttpsRedirection();

        app.UseAuthorization();
        
        app.Run();
    }
}