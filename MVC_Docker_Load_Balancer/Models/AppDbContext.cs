using Microsoft.EntityFrameworkCore;

namespace MVC_Docker_Load_Balancer.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }
        public DbSet<LBProduto> LBProdutos { get; set; }
    }
}