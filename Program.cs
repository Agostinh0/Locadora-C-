using System;
using Locadora.controladores.models;
using Locadora.controladores;

namespace Locadora
{
    class Program
    {
        static void Menu() {

            Console.Clear();

            Console.WriteLine("\t------------LOCADORA DO TRABSON------------");

            Console.WriteLine("(1) Adicionar cliente\n(2) Buscar cliente\n(3) Editar cliente\n(4) Remover cliente");
            Console.WriteLine("(5) Adicionar filme\n(6) Buscar filme\n(7) Editar filme\n(8) Remover filme");
            Console.WriteLine("(9) Registrar aluguel\n(10) Registrar devolução\n(11) Sair");

            Console.WriteLine("Escolha uma operação:");
            int operacao = int.Parse(Console.ReadLine());

            do
            {
                switch (operacao)
                {
                    case 1:

                        Console.Clear();


                        Console.WriteLine("Insira o nome do cliente: ");
                        string nome = Console.ReadLine();

                        Console.WriteLine("Insira o CPF do cliente: ");
                        string cpf = Console.ReadLine();

                        Console.WriteLine("\nAgora você irá inserir os dados do endereço do cliente: ");
                        Console.WriteLine("Logradouro: ");
                        string logradouro = Console.ReadLine();

                        Console.WriteLine("Número: ");
                        int numero = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Complemento (se não houver, apenas pressione ENTER): ");
                        string complemento = Console.ReadLine();

                        Console.WriteLine("CEP: ");
                        string cep = Console.ReadLine();

                        Console.WriteLine("Bairro: ");
                        string bairro = Console.ReadLine();

                        Console.WriteLine("Cidade: ");
                        string cidade = Console.ReadLine();

                        Endereco endereco = new Endereco(logradouro, numero, complemento, cep, bairro, cidade);

                        int status = 0;
                        while (status != 1 && status != 2)
                        {

                            Console.WriteLine("O cliente será PREMIUM? 1 para SIM, 2 para NÃO: ");
                            status = Convert.ToInt32(Console.ReadLine());

                            Boolean premium;

                            if (status == 1)
                            {
                                premium = true;

                                Cliente cliente = new Cliente(nome, cpf, endereco, premium);
                                Fachada.Instance.SalvarCliente(cliente);

                                Console.Clear();
                                Console.WriteLine("Cliente adicionado com sucesso!\n");
                                Console.WriteLine(cliente.ToString());

                                Console.ReadLine();
                            }
                            else if (status == 2)
                            {
                                premium = false;

                                Cliente cliente = new Cliente(nome, cpf, endereco, premium);
                                Fachada.Instance.SalvarCliente(cliente);

                                Console.Clear();
                                Console.WriteLine("Cliente adicionado com sucesso!\n");
                                Console.WriteLine(cliente.ToString());

                                Console.ReadLine();
                            }
                            else
                            {
                                Console.WriteLine("Operação Inválida!");
                            }
                        }

                        Menu();

                        break;

                    case 2:

                        Console.Clear();

                        Console.WriteLine("Insira o CPF do cliente: ");
                        string busca = Console.ReadLine();

                        Console.Clear();
                        Console.WriteLine(Fachada.Instance.BuscarCliente(busca));

                        Console.ReadLine();

                        Menu(); break;
                    case 3:

                        Console.Clear();

                        Console.WriteLine("Insira o CPF do cliente: ");
                        string pesquisa = Console.ReadLine();

                        Console.Clear();
                        Cliente cl = Fachada.Instance.BuscarCliente(pesquisa);
                        Console.WriteLine(cl.ToString());

                        Console.WriteLine("Insira o novo nome do cliente: ");
                        string novoNome = Console.ReadLine();

                        Console.WriteLine("\nAgora você irá inserir os novos dados do endereço do cliente: ");
                        Console.WriteLine("Logradouro: ");
                        string novoLogradouro = Console.ReadLine();

                        Console.WriteLine("Número: ");
                        int novoNumero = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Complemento (se não houver, apenas pressione ENTER): ");
                        string novoComplemento = Console.ReadLine();

                        Console.WriteLine("CEP: ");
                        string novoCep = Console.ReadLine();

                        Console.WriteLine("Bairro: ");
                        string novoBairro = Console.ReadLine();

                        Console.WriteLine("Cidade: ");
                        string novaCidade = Console.ReadLine();

                        Endereco novoEndereco = new Endereco(novoLogradouro, novoNumero, novoComplemento, novoCep, novoBairro, novaCidade);

                        int novoStatus = 0;
                        while (novoStatus != 1 && novoStatus != 2)
                        {

                            Console.WriteLine("O cliente será PREMIUM? 1 para SIM, 2 para NÃO: ");
                            novoStatus = Convert.ToInt32(Console.ReadLine());

                            Boolean premium;

                            if (novoStatus == 1)
                            {
                                premium = true;

                                Fachada.Instance.EditarCliente(cl, novoNome, novoEndereco, premium);

                                Console.Clear();
                                Console.WriteLine("Cliente alterado com sucesso!\n");
                                Console.WriteLine(cl.ToString());

                                Console.ReadLine();
                            }
                            else if (novoStatus == 2)
                            {
                                premium = false;

                                Fachada.Instance.EditarCliente(cl, novoNome, novoEndereco, premium);

                                Console.Clear();
                                Console.WriteLine("Cliente alterado com sucesso!\n");
                                Console.WriteLine(cl.ToString());

                                Console.ReadLine();
                            }
                            else
                            {
                                Console.WriteLine("Operação Inválida!");
                            }
                        }

                        Menu();


                        break;

                    case 4:
                        Console.Clear();

                        Console.WriteLine("Insira o CPF do cliente: ");
                        string search = Console.ReadLine();

                        Console.Clear();
                        Cliente client = Fachada.Instance.BuscarCliente(search);
                        Console.WriteLine(client.ToString());

                        int confirmacao = 0;

                        while (confirmacao != 1 && confirmacao != 2)
                        {
                            Console.WriteLine("Deseja remover o cliente? 1 para SIM, 2 para NÃO");
                            confirmacao = Convert.ToInt32(Console.ReadLine());

                        
                            if (confirmacao == 1)
                            {
                                if (Fachada.Instance.RemoverCliente(client))
                                {
                                    Console.WriteLine("Cliente removido com sucesso!");
                                    Console.ReadLine();
                                }
                                else {
                                    Console.WriteLine("Não foi possível remover o cliente.\nVerifique se ele possui filmes alugados");
                                    Console.ReadLine();
                                }
                            }
                            else if (confirmacao == 2)
                            {
                                Console.WriteLine("Operação cancelada.");
                                Console.ReadLine();
                            }
                            else {
                                Console.WriteLine("Opção inválida!");
                            }
                        }

                        Menu();

                        break;
                    case 5:

                        Console.Clear();


                        Console.WriteLine("Insira o título do filme: ");
                        string titulo = Console.ReadLine();

                        Console.WriteLine("Insira o diretor do filme: ");
                        string diretor = Console.ReadLine();

                        Console.WriteLine("Dia de lançamento: ");
                        int dia = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Mês de lançamento (número): ");
                        int mes = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Ano de lançamento: ");
                        int ano = Convert.ToInt32(Console.ReadLine());

                        DateTime dataLancamento = new DateTime(ano, mes, dia);                       

                        Console.WriteLine("Preço: ");
                        double preco = Convert.ToDouble(Console.ReadLine());

                        Console.WriteLine("Gênero (Exemplos: Ação, Aventura, Drama, etc): ");
                        string genero = Console.ReadLine();

                        Console.WriteLine("Sinopse: ");
                        string sinopse = Console.ReadLine();

                        Filme filme = new Filme(titulo, diretor, dataLancamento, preco, genero, sinopse);
                        Fachada.Instance.SalvarFilme(filme);

                        Console.Clear();
                        Console.WriteLine("Filme adicionado com sucesso!");
                        Console.WriteLine(filme.ToString());

                        Console.ReadLine();

                        Menu();

                        break;
                    case 6:

                        Console.Clear();

                        Console.WriteLine("Insira o título do filme: ");
                        string buscaFilme = Console.ReadLine();

                        Console.Clear();
                        Console.WriteLine(Fachada.Instance.BuscarFilme(buscaFilme));

                        Console.ReadLine();

                        Menu();

                        break;
                    case 7:

                        Console.Clear();

                        Console.WriteLine("Insira o título do filme: ");
                        string filmSearch = Console.ReadLine();

                        Console.Clear();
                        Filme f = Fachada.Instance.BuscarFilme(filmSearch);
                        Console.WriteLine(f.ToString());

                        Console.WriteLine("Insira o novo título do filme: ");
                        string novoTitulo = Console.ReadLine();

                        Console.WriteLine("Insira o novo diretor do filme: ");
                        string novoDiretor = Console.ReadLine();

                        Console.WriteLine("Novo dia de lançamento: ");
                        int novoDia = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Novo mês de lançamento (número): ");
                        int novoMes = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Novo ano de lançamento: ");
                        int novoAno = Convert.ToInt32(Console.ReadLine());

                        DateTime novaDataLancamento = new DateTime(novoAno, novoMes, novoDia);

                        Console.WriteLine("Novo preço: ");
                        double novoPreco = Convert.ToDouble(Console.ReadLine());

                        Console.WriteLine("Novo gênero (Exemplos: Ação, Aventura, Drama, etc): ");
                        string novoGenero = Console.ReadLine();

                        Console.WriteLine("Nova sinopse: ");
                        string novaSinopse = Console.ReadLine();

                        Fachada.Instance.EditarFilme(f, novoTitulo, novoDiretor, novaDataLancamento, 
                            novoPreco, novoGenero, novaSinopse);

                        Console.Clear();

                        Console.WriteLine("Filme atualizado com sucesso!");
                        Console.WriteLine(f.ToString());
                        Console.ReadLine();

                        Menu();

                        break;
                    case 8:

                        Console.Clear();

                        Console.WriteLine("Insira o título do filme: ");
                        string movieSearch = Console.ReadLine();

                        Console.Clear();
                        Filme movie = Fachada.Instance.BuscarFilme(movieSearch);
                        Console.WriteLine(movie.ToString());

                        int confirm = 0;

                        while (confirm != 1 && confirm != 2)
                        {
                            Console.WriteLine("Deseja remover o filme? 1 para SIM, 2 para NÃO");
                            confirm = Convert.ToInt32(Console.ReadLine());


                            if (confirm == 1)
                            {
                                Fachada.Instance.RemoverFilme(movie);
                                Console.WriteLine("Filme removido com sucesso!");
                                Console.ReadLine();
                            }
                            else if (confirm == 2)
                            {
                                Console.WriteLine("Operação cancelada.");
                                Console.ReadLine();
                            }
                            else
                            {
                                Console.WriteLine("Opção inválida!");
                            }
                        }

                        Menu();

                        break;
                    case 9:

                        Console.Clear();

                        Console.WriteLine("Insira o título do filme: ");
                        string buscaFilmeAluguel = Console.ReadLine();

                        Filme film = Fachada.Instance.BuscarFilme(buscaFilmeAluguel);
                        Console.WriteLine(film.ToString());

                        Console.WriteLine("---------------------\nInsira o CPF do cliente: ");
                        string clienteCpf = Console.ReadLine();

                        Cliente fregues = Fachada.Instance.BuscarCliente(clienteCpf);
                        Console.WriteLine(fregues.ToString());

                        Console.WriteLine("---------------------\nPor quantos dias irá alugar?");
                        int dias = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Qual a forma de pagamento?");
                        string formaPagamento = Console.ReadLine();

                        fregues.Alugar(fregues, film);
                        NotaFiscal nf = new NotaFiscal(fregues, film, dias, formaPagamento);

                        Console.Clear();
                        Console.WriteLine("Alugado!");
                        Console.WriteLine(nf.ToString());

                        Console.ReadLine();

                        Menu();

                        break;
                    case 10:

                        Console.Clear();

                        Console.WriteLine("Insira o CPF do cliente: ");
                        string clientCpf = Console.ReadLine();

                        Cliente cli = Fachada.Instance.BuscarCliente(clientCpf);
                        Console.WriteLine(cli.ToString());

                        Console.WriteLine("---------------------\nInsira o nome do filme a ser devolvido");
                        string p = Console.ReadLine();

                        Filme fl = Fachada.Instance.BuscarFilme(p);
                        Console.WriteLine(fl.ToString());

                        cli.Devolver(cli, fl);

                        Console.WriteLine("Devolvido!");

                        Console.ReadLine();

                        Menu();

                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Obrigado por usar o nosso sistema!"); break;
                }

            } while (operacao != 11);

        }

        static void Main(string[] args)
        {

            Menu();

            
        }
    }
}
