using Microsoft.EntityFrameworkCore;

namespace MVC_Docker_Load_Balancer.Models
{
    public static class Populadb
    {
        public static void IncluiDadosDB(IApplicationBuilder app)
        {
            IServiceScopeFactory? scopedFactory = app.ApplicationServices.GetService<IServiceScopeFactory>();
            if (scopedFactory is not null)
            {
                using IServiceScope scope = scopedFactory.CreateScope();

                AppDbContext? context = scope.ServiceProvider.GetService<AppDbContext>();

                if (context is not null)
                {
                    IncluiDadosDB(context);
                }
            }
        }

        public static void IncluiDadosDB(AppDbContext? context)
        {
            if (context is not null)
            {
                System.Console.WriteLine("Aplicando Migrations...");
                context.Database.Migrate();

                if (!context.LBProdutos.Any())
                {
                    System.Console.WriteLine("Criando dados...");
                    context.LBProdutos.AddRange(
                        new LBProduto("Luvas de goleiro", "Futebol", 25),
                        new LBProduto("Bola de basquete", "Basquete", 48.95m),
                        new LBProduto("Bola de Futebol", "Futebol", 19.50m),
                        new LBProduto("Óculos para natação", "Aquaticos", 34.95m),
                        new LBProduto("Meias Grandes", "Futebol", 50),
                        new LBProduto("Calção de banho", "Aquáticos", 16),
                        new LBProduto("Cesta para quadra", "Basquete", 29.95m)
                    );
                    context.SaveChanges();
                }
                else
                {
                    System.Console.WriteLine("Dados já existem...");
                }
            }
        }
    }
}