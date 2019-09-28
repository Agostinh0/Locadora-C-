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
            Console.WriteLine("(9) Registrar aluguel\n(10) Registrar devolução\n");

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
                                Fachada.Instance.RemoverCliente(client);
                                Console.WriteLine("Cliente removido com sucesso!");
                                Console.ReadLine();
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
                    case 5: break;
                    case 6: break;
                    case 7: break;
                    case 8: break;
                    case 9: break;
                    case 10: break;
                }

            } while (operacao != 11);

        }

        static void Main(string[] args)
        {

            Menu();

            
        }
    }
}
