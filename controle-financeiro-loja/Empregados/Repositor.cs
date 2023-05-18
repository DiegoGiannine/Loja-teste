using controle_financeiro_loja.Produtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace controle_financeiro_loja.Empregados
{
    public class Repositor:Empregado
    {
        public static int TotalRepositores = 0;        
        public Repositor(string nome, string cpf, double salario, string senha) : base(nome, cpf, salario, senha)
        {
            ++TotalRepositores;            
        }        
    }
}
