using controle_financeiro_loja.Produtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace controle_financeiro_loja.Empregados
{
    public class ListasDeEmpregados
    {
        private Dictionary<string, Empregado> empregados;        
        public ListasDeEmpregados(Empregado empregado)
        {
            if (!(empregado is Dono))
            {
                throw new ArgumentException("Apenas gerentes podem criar listas");
            }            
            empregados = new Dictionary<string, Empregado>();            
        }
        public void ExibirInformacoesFuncionario(string cpf)
        {
            if (empregados.ContainsKey(cpf))
            {
                Empregado empregado = empregados[cpf];
                if (empregado is Gerente gerente)
                {
                    Console.WriteLine($"Nome: {empregado.Nome}, Cpf: {empregado.Cpf}, Salário: R${empregado.Salario}, Senha: {empregado.Senha}");
                }
                else if (empregado is Repositor repositor)
                {
                    Console.WriteLine($"Nome: {empregado.Nome}, Cpf: {empregado.Cpf}, Salário: R${empregado.Salario}, Senha: {empregado.Senha}");
                }
                else if (empregado is Vendedor vendedor)
                {
                    Console.WriteLine($"Nome: {empregado.Nome}, Cpf: {empregado.Cpf}, Salário: R${empregado.Salario}, Senha: {empregado.Senha}");
                }
            }
            else
            {
                Console.WriteLine("Funcionário não encontrado.");
            }
        }        
        public void AdicionarFuncionario(string cpf, Empregado empregado)
        {            
            empregados.Add(cpf, empregado);            
        }
        public void RemoverFuncionario(Empregado empregado, string cpf)
        {
            if (!(empregado is Dono) && !(empregado is Gerente))
            {
                throw new ArgumentException("Apenas Donos e Gerentes podem calcular salarios dos empregados");
            }
            if (empregados.ContainsKey(cpf))
            {
                empregados.Remove(cpf);
                Console.WriteLine("Funcionário removido com sucesso!");
            }
            else
            {
                Console.WriteLine("Funcionário não encontrado.");
            }
        }
        public double SomarSalariosGerentes(Empregado empregado)
        {

            if (!(empregado is Dono) && !(empregado is Gerente))
            {
                throw new ArgumentException("Apenas Donos e Gerentes podem calcular salarios dos empregados");
            }
            double somaSalarios = 0;

            foreach (var funcionario in empregados.Values)
            {
                if (funcionario is Gerente gerente)
                {
                    somaSalarios += gerente.Salario;
                }
            }
            return somaSalarios;
        }
        public double SomarSalariosRepositores(Empregado empregado)
        {

            if (!(empregado is Dono) && !(empregado is Gerente))
            {
                throw new ArgumentException("Apenas Donos e Gerentes podem calcular salarios dos empregados");
            }
            double somaSalarios = 0;

            foreach (var funcionario in empregados.Values)
            {
                if (funcionario is Repositor repositor)
                {
                    somaSalarios += repositor.Salario;
                }
            }
            return somaSalarios;

        }
        public double SomarSalariosVendedores(Empregado empregado)
        {

            if (!(empregado is Dono) && !(empregado is Gerente))
            {
                throw new ArgumentException("Apenas Donos e Gerentes podem calcular salarios dos empregados");
            }
            double somaSalarios = 0;

            foreach (var funcionario in empregados.Values)
            {
                if (funcionario is Vendedor vendedor)
                {
                    somaSalarios += vendedor.Salario;
                }
            }
            return somaSalarios;

        }
        public Empregado RealizarLogin(string cpf, string senha)
        {
            if (empregados.ContainsKey(cpf))
            {
                Empregado empregado = empregados[cpf];
                if (empregado.Senha == senha)
                {                   
                    return empregado;
                }                
            }
            return null;
        }
    }
}
