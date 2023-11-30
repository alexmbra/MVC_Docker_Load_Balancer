namespace MVC_Docker_Load_Balancer.Models
{
    public class ProdutoRepository : IRepository
    {
        private readonly AppDbContext context;
        public ProdutoRepository(AppDbContext ctx)
        {
            context = ctx;
        }
        public IEnumerable<LBProduto> LBProdutos => context.LBProdutos;

    }
}