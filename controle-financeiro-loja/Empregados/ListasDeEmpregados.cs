using controle_financeiro_loja.Produtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace controle_financeiro_loja.Empregados
{
    internal class ListasDeEmpregados
    {
        public List<Empregado> ListaDonos { get; private set; }
        public List<Empregado> ListaGerentes { get; private set; }
        public List<Empregado> ListaVendedores { get; private set; }
        public List<Empregado> ListaRepositores { get; private set; }
        
        public ListasDeEmpregados(Empregado empregado)
        {
            if (!(empregado is Dono))
            {
                throw new ArgumentException("Apenas gerentes podem criar listas");
            }
            ListaDonos = new List<Empregado>();
            ListaGerentes = new List<Empregado>();
            ListaVendedores = new List<Empregado>();
            ListaRepositores = new List<Empregado>();                
        }
        public string ObterPropriedadesGerente(string cpf)
        {
            Empregado empregado = ListaGerentes.FirstOrDefault(p => p.Cpf == cpf);
            if (empregado == null)
            {
                throw new ArgumentException("Empregado não encontrado");
            }

            return $"Nome: {empregado.Nome}, Cpf: {empregado.Cpf}, Salário: R${empregado.Salario}, Senha: {empregado.Senha}";
        }
        public void AddDonoALista(Empregado quemEstaAlterando, Dono dono)
        {
            if (!(quemEstaAlterando is Dono))
            {
                throw new ArgumentException("Apenas Donos e Gerentes podem adicionar empregados a listas");
            }
            ListaDonos.Add(dono);            
        }
        public void AddVendedorALista(Empregado quemEstaAlterando, Vendedor vendedor)
        {
            if (!(quemEstaAlterando is Dono) && !(quemEstaAlterando is Gerente))
            {
                throw new ArgumentException("Apenas Donos e Gerentes podem adicionar empregados a listas");
            }            
            ListaVendedores.Add(vendedor);
            Console.WriteLine("O vendedor " + vendedor.Nome + " foi adicionado no Banco de vendedores");
        }
        public void AddGerenteALista(Empregado quemEstaAlterando, Gerente gerente)
        {
            if(quemEstaAlterando == gerente)
            {
                throw new ArgumentException("Você não pode se adicionar a lista");
            }
            if (!(quemEstaAlterando is Dono) && !(quemEstaAlterando is Gerente))
            {
                throw new ArgumentException("Apenas Donos e Gerentes podem adicionar empregados a listas");
            }            
            ListaGerentes.Add(gerente);
            Console.WriteLine("O gerente " + gerente.Nome + " foi adicionado no Banco de gerentes");
        }
        public void AddRepositorALista(Empregado quemEstaAlterando, Repositor repositor)
        {
            if (!(quemEstaAlterando is Dono) && !(quemEstaAlterando is Gerente))
            {
                throw new ArgumentException("Apenas Donos e Gerentes podem adicionar empregados a listas");
            }
            ListaRepositores.Add(repositor);
            Console.WriteLine("O repositor " + repositor.Nome + " foi adicionado no Banco de repositores");
        }
        public void RemoverVendedorDaLista(Empregado quemEstaAlterando, Vendedor vendedor)
        {
            if (!(quemEstaAlterando is Dono) && !(quemEstaAlterando is Gerente))
            {
                throw new ArgumentException("Apenas Donos e Gerentes podem remover empregados a listas");
            }
            ListaVendedores.Remove(vendedor);
            Console.WriteLine("O vendedor " + vendedor.Nome + " foi removido do Banco de vendedores");
        }
        public void RemoverGerenteDaLista(Empregado quemEstaAlterando, Gerente gerente)
        {
            if (quemEstaAlterando == gerente)
            {
                throw new ArgumentException("Você não pode se remover da lista");
            }
            if (!(quemEstaAlterando is Dono) && !(quemEstaAlterando is Gerente))
            {
                throw new ArgumentException("Apenas Donos e Gerentes podem remover empregados a listas");
            }
            ListaGerentes.Remove(gerente);
            Console.WriteLine("O gerente " + gerente.Nome + " foi removido do Banco de gerentes");
        }
        public void RemoverVendedorDaLista(Empregado quemEstaAlterando, Repositor repositor)
        {
            if (!(quemEstaAlterando is Dono) && !(quemEstaAlterando is Gerente))
            {
                throw new ArgumentException("Apenas Donos e Gerentes podem remover empregados a listas");
            }
            ListaRepositores.Remove(repositor);
            Console.WriteLine("O repositor " + repositor.Nome + " foi removido do Banco de repositores");
        }
        public double SomarSalariosGerentes(Empregado empregado)
        {

            if (!(empregado is Dono) && !(empregado is Gerente))
            {
                throw new ArgumentException("Apenas Donos e Gerentes podem calcular salarios dos empregados");
            }
            double somaSalarios = 0;

            foreach (Gerente gerente in ListaGerentes)
            {
                somaSalarios += gerente.Salario;
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

            foreach (Repositor repositor in ListaRepositores)
            {
                somaSalarios += repositor.Salario;
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

            foreach (Vendedor vendedor in ListaVendedores)
            {
                somaSalarios += vendedor.Salario;
            }
            return somaSalarios;

        }
    }
}
