using System.ComponentModel.DataAnnotations;

namespace MVC_Docker_Load_Balancer.Models
{
    public class LBProduto
    {
        public LBProduto(string nome, string categoria, decimal preco = 0)
        {
            this.Nome = nome;
            this.Categoria = categoria;
            this.Preco = preco;
        }

        [Key]
        public int ProdutoId { get; set; }
        public string Nome { get; set; }
        public string Categoria { get; set; } = string.Empty;
        public decimal Preco { get; set; }
    }
}