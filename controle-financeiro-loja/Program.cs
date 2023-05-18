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

    Dono joao = new Dono("Diego", "654321", 0, "123456");

    ListasDeEmpregados listasDeEmpregados = new ListasDeEmpregados(joao);
    listasDeEmpregados.AddDonoALista(joao, joao);

    string senhaDigitada;
    string nomeCorrespondente = null;
    do
    {
        Console.WriteLine("Digite a senha:");
        senhaDigitada = Console.ReadLine();

        nomeCorrespondente = sistema.VerificarSenha(senhaDigitada, listasDeEmpregados.ListaDonos);
        if (nomeCorrespondente != null)
        {
            Console.WriteLine("A senha é válida!");
            Console.WriteLine("Bem Vindo ao Sistema " + nomeCorrespondente);
            break;
        }

        Console.WriteLine("A senha é inválida. Tente novamente.");
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
    }
    while (true);    

}

UsarSistema();
