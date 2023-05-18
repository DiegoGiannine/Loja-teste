using controle_financeiro_loja.Empregados;
using controle_financeiro_loja.SistemaInterno;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace controle_financeiro_loja.Produtos
{
    public class Produto
    {
        public int CodigoProduto { get; private set; }
        public string Nome { get; set; }
        public double Preco { get; set; }
        public int Quantidade { get; set; }
        public DateOnly DataValidade { get; set; }
        public int QuantidadeVendida { get; private set; }
        public static double ValorRecebido { get; private set; }
        public static double ValorTotalRecebido { get; private set; } 
        public static int TotalProdutosDiferentes { get;  set; }
        public Produto(int codigoProduto, string nome, double preco, int quantidade, DateOnly dataValidade)
        {
            this.CodigoProduto = codigoProduto;
            this.Nome = nome; 
            this.Preco = preco;
            this.Quantidade = quantidade;
            this.DataValidade = dataValidade;
            this.QuantidadeVendida = 0;
            ValorTotalRecebido = 0;
            TotalProdutosDiferentes++;
        }        
        public void Vender(int quantidade)
        {
            if (quantidade <= 0)
            {
                throw new ArgumentException("Quantidade inválida.");
            }

            if (quantidade > Quantidade)
            {
                throw new ArgumentException("Quantidade maior do que o estoque disponível.");
            }

            Quantidade -= quantidade;
            QuantidadeVendida += quantidade;
            ValorRecebido = QuantidadeVendida * Preco;
            ValorTotalRecebido += ValorRecebido;
            Console.WriteLine("Venda Registrada");                        
        }                
    }
}
