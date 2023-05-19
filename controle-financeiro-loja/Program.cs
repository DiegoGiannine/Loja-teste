using controle_financeiro_loja.Empregados;
using controle_financeiro_loja.Produtos;
using controle_financeiro_loja.SistemaInterno;
using System.Collections.Concurrent;
using System.ComponentModel;
using System.Net.Http.Headers;
using System.Net.Mail;



void UsarSistema()
{
    SistemaInterno sistema = new SistemaInterno();

    Dono dono1 = new Dono("Diego", "654321", 0, "123456");

    ListasDeEmpregados listasDeEmpregados = new ListasDeEmpregados(dono1);
    listasDeEmpregados.AddDonoALista(dono1, dono1);    

    do
    {
        Console.WriteLine("Para Fazer Login Digite...");
        Console.WriteLine("Digite o CPF:");
        string loginCpf = Console.ReadLine();
        Console.WriteLine("Digite a senha:");
        string loginSenha = Console.ReadLine();        

        Empregado empregado = null;             

            // Procurar nas listas correspondentes ao tipo de empregado
            empregado = listasDeEmpregados.ListaDonos.FirstOrDefault(g => g.Cpf == loginCpf && g.Senha == loginSenha);
        if (empregado == null)
            empregado = listasDeEmpregados.ListaGerentes.FirstOrDefault(v => v.Cpf == loginCpf && v.Senha == loginSenha);
        if (empregado == null)
            empregado = listasDeEmpregados.ListaVendedores.FirstOrDefault(r => r.Cpf == loginCpf && r.Senha == loginSenha);
        if (empregado == null)
            empregado = listasDeEmpregados.ListaRepositores.FirstOrDefault(r => r.Cpf == loginCpf && r.Senha == loginSenha);

        if (empregado != null)
        {
            if(empregado is Dono)
            {
                Console.Clear();
                Console.WriteLine("A senha é válida!");
                Console.WriteLine("Bem Vindo ao Sistema Proprietário " + empregado.Nome);
                string escolha = "";
                while (escolha != "voltar")
                {
                    Console.WriteLine("Escolha uma das opções digitando o numero referente a escolhida");
                    Console.WriteLine("1. Adicionar Funcionário");
                    Console.WriteLine("Digite VOLTAR para voltar ao menu anterior");
                    escolha = Console.ReadLine();

                    if (escolha.ToLower() == "voltar")
                    {
                        break;
                    }
                    switch (escolha.ToLower())
                    {
                        case "1":
                            MenuCriarGerente();
                            break;

                        case "2":

                            break;
                    }
                }

            }
            // Login bem-sucedido, realizar as ações desejadas para o tipo de empregado
            if (empregado is Gerente)
            {
                // Ações para o Gerente
                Console.WriteLine("Gerente " + empregado.Nome+ " logado com sucesso!");
                string escolha = "";
                while (escolha != "voltar")
                {
                    Console.WriteLine("Escolha uma das opções digitando o numero referente a escolhida");
                    Console.WriteLine("1. Adicionar Funcionário");
                    Console.WriteLine("Digite VOLTAR para voltar ao menu anterior");
                    escolha = Console.ReadLine();

                    if (escolha.ToLower() == "voltar")
                    {
                        break;
                    }
                    switch (escolha.ToLower())
                    {
                        case "1":
                            MenuCriarGerente();
                            break;

                        case "2":

                            break;
                    }
                }
            }
            else if (empregado is Vendedor)
            {
                // Ações para o Vendedor
                Console.WriteLine("Vendedor logado com sucesso!");
            }
            else if (empregado is Repositor)
            {
                // Ações para o Repositor
                Console.WriteLine("Repositor logado com sucesso!");
            }
        }
        else
        {
            // Login falhou
            Console.WriteLine("CPF ou senha incorretos.");
        }       
    }
    while (true);
    


void MenuCriarGerente()
    {
        Console.WriteLine("Digite o cargo do funcionário: Gerente, Vendedor, Repositor");
        string cargo = Console.ReadLine();
        while (cargo.ToLower() != "gerente" && cargo.ToLower() != "vendedor" && cargo.ToLower() != "repositor")
        {
            Console.WriteLine("Cargo inválido! por favor escolha um cargo válido");
            cargo = Console.ReadLine();
        }
        Console.WriteLine("Digite o Nome do funcionário");
        string nome = Console.ReadLine();
        Console.WriteLine("Digite o CPF do funcionário");
        string cpf = Console.ReadLine();
        Console.WriteLine("Digite o Salário do funcionário");
        double salario = double.Parse(Console.ReadLine());
        Console.WriteLine("Digite a Senha de ACESSO ao sistema do funcionário");
        string senha = Console.ReadLine();
        if (cargo.ToLower() == "gerente")
        {
            Gerente gerente = new Gerente(nome, cpf, salario, senha);
            listasDeEmpregados.AddGerenteALista(dono1, gerente);
            Console.WriteLine(listasDeEmpregados.ObterPropriedadesGerente(cpf));
            Console.ReadKey();
            Console.Clear();
        }
    }
}

UsarSistema();
