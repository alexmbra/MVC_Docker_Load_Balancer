using Microsoft.EntityFrameworkCore;
using MVC_Docker_Load_Balancer.Models;

namespace MVC_Docker_Load_Balancer;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllersWithViews();

        var host = builder.Configuration["DBHOST"] ?? "localhost";
        var port = builder.Configuration["DBPORT"] ?? "3306";
        var password = builder.Configuration["DBPASSWORD"] ?? "numsey";

        builder.Services.AddDbContext<AppDbContext>(options =>
        {
            options.UseMySql($"server={host};port={port};userid=root;pwd={password};database=LBProdutosdb",
                             new MySqlServerVersion(new Version(8, 0, 23)));
        });

        builder.Services.AddSingleton<IConfiguration>(builder.Configuration);
        builder.Services.AddTransient<IRepository, ProdutoRepository>();



        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
        }
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        //Populadb.IncluiDadosDB(app);

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }
}
