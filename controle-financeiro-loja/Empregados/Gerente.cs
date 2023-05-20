using controle_financeiro_loja.Produtos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace controle_financeiro_loja.Empregados
{
    public class Gerente : Empregado
    {        
        public static int TotalGerentes { get; private set;  } = 0;        
       
        public Gerente(string nome, string cpf, double salario, string senha) :base(nome, cpf, salario, senha)
        {               
            ++TotalGerentes;            
        }       
    }
}
