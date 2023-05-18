using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace controle_financeiro_loja.Empregados
{
    public class Dono:Empregado
    {
        public static int TotalDonos { get; private set; } = 0;
        public Dono(string nome, string cpf, double salario, string senha) : base(nome, cpf, salario, senha)
        {
            ++TotalDonos;
        }        
    }
}
