using controle_financeiro_loja.Empregados;
using controle_financeiro_loja.Produtos;
using System.Collections.Concurrent;
using System.ComponentModel;
using System.Net.Http.Headers;
using System.Net.Mail;



void UsarSistema()
{    
    Dono dono1 = new Dono("Diego", "654321", 0, "123456");

    Estoque estoque = new Estoque(dono1);

    ListasDeEmpregados listasDeEmpregados = new ListasDeEmpregados(dono1);
    listasDeEmpregados.AdicionarFuncionario("654321", dono1);    

    do
    {
        Console.WriteLine("Para Fazer Login...");
        Console.WriteLine("Digite o CPF:");
        string loginCpf = Console.ReadLine();
        Console.WriteLine("Digite a senha:");
        string loginSenha = Console.ReadLine();

        string enunciadoEscolhas = "Escolha uma das opções digitando o numero referente a escolhida";
        Empregado empregado = listasDeEmpregados.RealizarLogin(loginCpf, loginSenha);
        if (empregado != null)
        {        
            if(empregado is Dono)
            {
                Console.Clear();
                Console.WriteLine("A senha é válida!");
                Console.WriteLine("Bem Vindo ao Sistema Proprietário " + empregado.Nome);
                Console.ReadKey();

                string escolha = "";                

                while (escolha != "voltar")
                {
                    Console.Clear();
                    Console.WriteLine(enunciadoEscolhas);
                    Console.WriteLine("1. Funcionários");
                    Console.WriteLine("2. Estoque");
                    Console.WriteLine("");
                    Console.WriteLine("Digite VOLTAR para voltar ao menu anterior");
                    escolha = Console.ReadLine();

                    if (escolha.ToLower() == "voltar")
                    {
                        break;
                    }
                    switch (escolha.ToLower())
                    {
                        case "1":                            
                            Console.Clear();
                            Console.WriteLine(enunciadoEscolhas);
                            Console.WriteLine("1. Criar e adicionar funcionário ao banco");
                            Console.WriteLine("");
                            Console.WriteLine("Digite VOLTAR para voltar ao menu anterior");

                            string caso1 = Console.ReadLine();
                            while (caso1.ToLower() != "voltar")
                            {
                                if (caso1.ToLower() == "1")
                                {
                                    CriaFuncionario();
                                    break;
                                }
                            }
                            break;

                        case "2":
                            Console.Clear();
                            Console.WriteLine(enunciadoEscolhas);
                            Console.WriteLine("1. Criar e adicionar um Produto ao Estoque");
                            Console.WriteLine("2. Vender Produto");
                            Console.WriteLine("5. Voltar");
                            Console.WriteLine("");                            
                            string caso2 = Console.ReadLine();
                            switch (caso2.ToLower())
                            {
                                case "1":                                
                                    CriaEAddPordutoEstoque();
                                    break;

                                case "2":
                                    RegistraVenda();
                                    break;

                                case "5":
                                    break;                                
                            }                            
                            break;
                    }
                }
            }
            // Login bem-sucedido, realizar as ações desejadas para o tipo de empregado
            if (empregado is Gerente)
            {
                Console.Clear();
                Console.WriteLine("A senha é válida!");
                // Ações para o Gerente
                Console.WriteLine("Gerente " + empregado.Nome+ " logado com sucesso!");
                Console.ReadKey();

                string escolha = "";
                while (escolha != "voltar")
                {
                    Console.Clear();
                    Console.WriteLine(enunciadoEscolhas);
                    Console.WriteLine("1. Funcionários");
                    Console.WriteLine("2. Estoque");
                    Console.WriteLine("");
                    Console.WriteLine("Digite VOLTAR para voltar ao menu anterior");
                    escolha = Console.ReadLine();

                    if (escolha.ToLower() == "voltar")
                    {
                        break;
                    }
                    switch (escolha.ToLower())
                    {
                        case "1":
                            Console.Clear();
                            Console.WriteLine(enunciadoEscolhas);
                            Console.WriteLine("1. Criar e adicionar funcionário ao banco");
                            string escolha2 = Console.ReadLine();
                            while (escolha2.ToLower() != "voltar")
                            {
                                if (escolha2.ToLower() == "1")
                                {                                    
                                    CriaFuncionario();
                                    break;
                                }
                            }
                            break;

                        case "2":
                            Console.Clear();
                            Console.WriteLine(enunciadoEscolhas);
                            Console.WriteLine("1. Criar e adicionar um Produto ao Estoque");
                            Console.WriteLine("2. Vender Produto");
                            Console.WriteLine("5. Voltar");
                            Console.WriteLine("");
                            string caso2 = Console.ReadLine();
                            switch (caso2.ToLower())
                            {
                                case "1":
                                    CriaEAddPordutoEstoque();
                                    break;

                                case "2":
                                    RegistraVenda();
                                    break;

                                case "5":
                                    break;
                            }
                            break;
                    }
                }
            }
            if (empregado is Vendedor)
            {
                Console.Clear();
                Console.WriteLine("A senha é válida!");
                // Ações para o Vendedor
                Console.WriteLine("Vendedor logado com sucesso!");
                Console.ReadKey();

                string escolha = "";
                while (escolha != "voltar")
                {
                    Console.Clear();
                    Console.WriteLine(enunciadoEscolhas);
                    Console.WriteLine("1. Registrar Venda");
                    Console.WriteLine("");
                    Console.WriteLine("Digite VOLTAR para voltar ao menu anterior");
                    escolha = Console.ReadLine();

                    if (escolha.ToLower() == "voltar")
                    {
                        break;
                    }
                    switch (escolha.ToLower())
                    {
                        case "1":
                            RegistraVenda();
                            break;

                        case "2":
                            break;
                    }
                }
            }
            else if (empregado is Repositor)
            {
                Console.Clear();
                Console.WriteLine("A senha é válida!");
                // Ações para o Repositor
                Console.WriteLine("Repositor logado com sucesso!");
                Console.ReadKey();

                string escolha = "";
                while (escolha != "voltar")
                {
                    Console.Clear();
                    Console.WriteLine(enunciadoEscolhas);
                    Console.WriteLine("1.  Criar e adicionar um Produto ao Estoque");
                    Console.WriteLine("");
                    Console.WriteLine("Digite VOLTAR para voltar ao menu anterior");
                    escolha = Console.ReadLine();

                    if (escolha.ToLower() == "voltar")
                    {
                        break;
                    }
                    switch (escolha.ToLower())
                    {
                        case "1":
                            CriaEAddPordutoEstoque();
                            break;

                        case "2":
                            break;
                    }
                }
            }
        }
        else
        {
            // Login falhou
            Console.WriteLine("CPF ou senha incorretos.");
        }                

        void CriaFuncionario()
        {
            Console.Clear();
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
                listasDeEmpregados.AdicionarFuncionario(cpf, gerente);
                Console.WriteLine("Funcionário " + gerente.Nome + " Foi adicionado ao banco");
                listasDeEmpregados.ExibirInformacoesFuncionario(cpf);
                Console.ReadKey();
                Console.Clear();
            }
            if (cargo.ToLower() == "repositor")
            {
                Repositor repositor = new Repositor(nome, cpf, salario, senha);
                listasDeEmpregados.AdicionarFuncionario(cpf, repositor);
                Console.WriteLine("Funcionário " + repositor.Nome + " Foi adicionado ao banco");
                listasDeEmpregados.ExibirInformacoesFuncionario(cpf);
                Console.ReadKey();
                Console.Clear();
            }
            if (cargo.ToLower() == "vendedor")
            {
                Vendedor vendedor = new Vendedor(nome, cpf, salario, senha);
                listasDeEmpregados.AdicionarFuncionario(cpf, vendedor);
                Console.WriteLine("Funcionário " + vendedor.Nome + " Foi adicionado ao banco");
                listasDeEmpregados.ExibirInformacoesFuncionario(cpf);
                Console.ReadKey();
                Console.Clear();
            }            
        }
        void CriaEAddPordutoEstoque()
        {           
            Console.Clear();
            Console.WriteLine("Digite Código do Produto");
            int codigoProduto = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Nome do Produto");
            string nomeProduto = Console.ReadLine();

            Console.WriteLine("Digite o Preço do Produto");
            double preco = double.Parse(Console.ReadLine());

            Console.WriteLine("Digite a Quantidade do Produto");
            int quantidade = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a Data de Validade");
            DateOnly dataValidade = DateOnly.Parse(Console.ReadLine());
            Console.Clear();

            estoque.AdicionarItem(empregado, codigoProduto, nomeProduto, preco, quantidade, dataValidade);
            estoque.ExibirInformacoesProduto(empregado, codigoProduto);
            Console.ReadKey();
            Console.Clear();
        }
        void RegistraVenda()
        {
            Console.Clear();
            Console.WriteLine("Digite o Código do Produto");
            int codigoProduto = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a Quantidade do Produto a Vender");
            int quantidade = int.Parse(Console.ReadLine());
            Console.Clear();
            estoque.RegistrarVenda(empregado, codigoProduto, quantidade);
            Console.ReadKey();
        }
    }
    while (true);
}

UsarSistema();
