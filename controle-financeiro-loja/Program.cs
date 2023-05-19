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
    string entrar = "";
    string senhaDigitada = "";
    string nomeCorrespondente = null;

    while (entrar.ToLower() != "fechar")
    {
        Console.WriteLine("Digite ENTRAR ou FECHAR");
        entrar = Console.ReadLine();
        if (entrar.ToLower() == "fechar")
        {
            Console.WriteLine("Você encerrou o programa!");
            break;
        }        
        if (entrar.ToLower() == "entrar")
        {
            do
            {
                Console.WriteLine("Digite a SENHA ou VOLTAR");

                senhaDigitada = Console.ReadLine();
                if (senhaDigitada.ToLower() == "voltar")
                {
                    break;
                }
                
                nomeCorrespondente = sistema.VerificarSenha(senhaDigitada, listasDeEmpregados.ListaDonos);
                if (nomeCorrespondente != null)
                {                        
                    Console.Clear();
                    Console.WriteLine("A senha é válida!");
                    Console.WriteLine("Bem Vindo ao Sistema " + nomeCorrespondente);
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
                                break;
                                    
                            case "2":                                    

                                break;
                        }
                    }                    
                }
                
                nomeCorrespondente = sistema.VerificarSenha(senhaDigitada, listasDeEmpregados.ListaGerentes);
                if (nomeCorrespondente != null)
                {
                    Console.WriteLine("A senha é válida!");
                    Console.WriteLine("Bem Vindo ao Sistema " + nomeCorrespondente);
                    break;
                }                

                nomeCorrespondente = sistema.VerificarSenha(senhaDigitada, listasDeEmpregados.ListaVendedores);
                if (nomeCorrespondente != null)
                {
                    Console.WriteLine("A senha é válida!");
                    Console.WriteLine("Bem Vindo ao Sistema " + nomeCorrespondente);
                    break;
                }

                nomeCorrespondente = sistema.VerificarSenha(senhaDigitada, listasDeEmpregados.ListaRepositores);
                if (nomeCorrespondente != null)
                {
                    Console.WriteLine("A senha é válida!");
                    Console.WriteLine("Bem Vindo ao Sistema " + nomeCorrespondente);
                    break;

                }
                else
                {
                    Console.WriteLine("Você precisa digitar a Senha novamente");
                    Console.WriteLine("A SENHA é inválida ou você precisa digitá-la novamente.");
                }
            }
            while (true);
        }    
    }
}

UsarSistema();
