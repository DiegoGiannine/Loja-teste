using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace controle_financeiro_loja.Empregados
{
    public abstract class Empregado
    {
        public string Nome { get; set; }
        public string Cpf { get; private set; }
        public double Salario { get; protected set; }
        public string Senha { get; protected set; }

        public static int TotalDeFuncionarios = 0;

        public Empregado(string nome, string cpf, double salario, string senha)
        {
            this.Nome = nome;
            this.Salario = salario;
            this.Cpf = cpf;
            this.Senha = senha;
            ++TotalDeFuncionarios;
        }
        public virtual void AlterarSalario(double novoSalario, Empregado quemEstaAlterando)
        {
            if (quemEstaAlterando is Dono || (quemEstaAlterando is Gerente && quemEstaAlterando != this))
            {
                Salario = novoSalario;
                Console.WriteLine("Salário alterado com sucesso!");
            }
            else
            {
                Console.WriteLine("Apenas o dono e o gerente podem alterar salários.");
            }
        }
    }
}
