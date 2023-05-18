using controle_financeiro_loja.Produtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace controle_financeiro_loja.Empregados
{
    public class Vendedor : Empregado
    {
        public static int TotalVendedores = 0;
        
        public Vendedor(string nome, string cpf, double salario, string senha) : base(nome, cpf, salario, senha)
        {
            ++TotalVendedores;
        }       
    }
}
