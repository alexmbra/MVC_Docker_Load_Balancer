namespace MVC_Docker_Load_Balancer.Models
{
    public interface IRepository
    {
        IEnumerable<LBProduto> LBProdutos { get; }
    }
}