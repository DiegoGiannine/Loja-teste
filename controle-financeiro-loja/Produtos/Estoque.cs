using controle_financeiro_loja.Empregados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace controle_financeiro_loja.Produtos
{
    public class Estoque
    {        
        private Dictionary<int, Produto> produtos;
        public Estoque(Empregado empregado)
        {
            if (!(empregado is Gerente) && !(empregado is Dono))
            {
                throw new ArgumentException("Apenas gerentes e donos podem criar estoques");
            }
            produtos = new Dictionary<int, Produto>();
        }
        public void ExibirInformacoesProduto(Empregado empregado, int codigoProduto)
        {
            if (produtos.ContainsKey(codigoProduto))
            {
                Produto produto = produtos[codigoProduto];
                Console.WriteLine(produto.ObterPropriedadesProduto());
            }
            else
            {
                Console.WriteLine("Produto não encontrado.");
            }
        }
        public void AdicionarItem(Empregado empregado, int codigoProduto, string nomeProduto, double preco, int quantidadeProduto, DateOnly dataValidade)
        {
            {
                Produto produto = new Produto(codigoProduto, nomeProduto,preco , quantidadeProduto, dataValidade);
                produtos.Add(codigoProduto, produto);
            }
        }
        public void RegistrarVenda(Empregado empregado,  int codigoProduto, int quantidadeVendida)
        {
            if (produtos.ContainsKey(codigoProduto))
            {
                Produto produto = produtos[codigoProduto];
                if (produto.Quantidade >= quantidadeVendida)
                {
                    produto.Vender(quantidadeVendida);
                    Console.WriteLine("Vendido " + quantidadeVendida + " quantidades do produto " + produto.Nome + "\nValor Total da Venda R$" + Produto.ValorRecebido);
                }
                else
                {
                    Console.WriteLine("Quantidade insuficiente em estoque.");
                }
            }
            else
            {
                Console.WriteLine("Produto não encontrado.");
            }
        }        
        public void RemoverItem(Empregado empregado, int codigoProduto)
        {
            if (!(empregado is Gerente) && !(empregado is Dono))
            {
                throw new ArgumentException("Apenas gerentes podem remover os itens do estoque");
            }
            if (produtos.ContainsKey(codigoProduto))
            {
                produtos.Remove(codigoProduto);
                Console.WriteLine("Produto " + codigoProduto + " removido com sucesso!");
            }
            else
            {
                Console.WriteLine("Produto não encontrado.");
            }
            
            
        }
        public void AdicionarQuantidade(Empregado empregado, int codigoProduto, int quantidade)
        {
            if (!(empregado is Gerente) && !(empregado is Repositor) && !(empregado is Dono))
            {
                throw new ArgumentException("Apenas gerentes e repositores podem alterar a quantidade");
            }
            if (produtos.ContainsKey(codigoProduto))
            {
                Produto produto = produtos[codigoProduto];
                produto.Quantidade += quantidade;
                Console.WriteLine($"Quantidade adicionada ao estoque: {quantidade}");
                Console.WriteLine($"Quantidade atual em estoque: {produto.Quantidade}");
            }
            else
            {
                Console.WriteLine("Produto não encontrado.");
            }            
        }                       
    }
}
