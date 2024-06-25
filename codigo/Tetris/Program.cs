using Tetris.Model;

namespace Tetris
{
    internal class Program
    {
        static Restaurante xulambs = new Restaurante();
        static List<Cliente> clientes = new List<Cliente>();
        static List<Cliente> clientesCafeteria = new List<Cliente>();
        static Cafeteria cafeteria = new Cafeteria();

        internal static void ApresentarCardapioRestaurante()
        {
            xulambs.ApresentarCardapio();
        }
        internal static void ApresentarCardapioCafeteria()
        {
            cafeteria.ApresentarCardapio();
        }
        internal static void cabecalho()
        {
            Console.Clear();
            Console.WriteLine("Projeto: OO Comidinhas Veganas");
            Console.WriteLine("==============================");
        }

        internal static Cliente VerificarCliente(string nome)
        {
            return clientes.Where(x => x.GetNome() == nome).FirstOrDefault();
        }
        internal static Cliente VerificarClienteCafeteria(string nome)
        {
            return clientesCafeteria.Where(x => x.GetNome() == nome).FirstOrDefault();
        }

        internal static bool VerificarNome(string nome)
        {
            if(clientes !=  null) 
            {
                foreach (Cliente cliente in clientes)
                {
                    if (cliente.GetNome() == nome)
                        return false;
                }
                return true;
            }
            return true;
            
        }

        internal static bool VerificarNomeCafeteria(string nome)
        {
            if (clientesCafeteria != null)
            {
                foreach (Cliente cliente in clientesCafeteria)
                {
                    if (cliente.GetNome() == nome)
                        return false;
                }
                return true;
            }
            return true;

        }


        internal static void Main(string[] args)
        {
            int escolha;
            int opcao;
            Cliente tmp;
            string nome;

            

            do
            {
                cabecalho();
                Console.WriteLine("Qual menu deseja acessar? ");
                Console.WriteLine("1 - Restaurante Xulambs");
                Console.WriteLine("2 - Cafeteria Xulambs");
                Console.WriteLine("0 - Sair");
                int.TryParse(Console.ReadLine(), out escolha);

                switch(escolha)
                {
                    case 1:

                        do
                        {
                            Console.Clear();
                            Console.WriteLine("Menu do Restaurante");
                            Console.WriteLine("==============================");
                            Console.WriteLine("1 - Cadastrar Cliente");
                            Console.WriteLine("2 - Localizar Pedidos do Cliente");
                            Console.WriteLine("3 - Criar Requisição de mesa");
                            Console.WriteLine("4 - Fechar Requisição");
                            Console.WriteLine("5 - Adicionar Pedido à Requisição");
                            Console.WriteLine("6 - Exibir lista de clientes atuais");
                            Console.WriteLine("7 - Exibir filas de espera e atendidas no momento");
                            Console.WriteLine("0 - Sair");
                            Console.Write("Digite sua opção: ");
                            int.TryParse(Console.ReadLine(), out opcao);


                            switch (opcao)
                            {
                                case 1:


                                    bool nomeLivre = true;
                                    do
                                    {
                                        Console.WriteLine("Digite o nome do cliente: ");
                                        nome = Console.ReadLine();
                                        nomeLivre = VerificarNome(nome);
                                        if (nomeLivre == true)
                                        {
                                            Cliente cliente1 = new Cliente(nome);
                                            clientes.Add(cliente1);
                                            Console.WriteLine("Cliente adicionado com sucesso!");
                                            Console.ReadKey();
                                        }
                                        else
                                        {
                                            Console.WriteLine("Nome invalido, tente outro");
                                            Console.ReadKey();
                                        }

                                    }
                                    while (nomeLivre == false);
                                    break;
                                case 2:
                                    Console.WriteLine("Digite o nome do Cliente: ");
                                    nome = Console.ReadLine();
                                    tmp = VerificarCliente(nome);
                                    if (tmp != null)
                                    {
                                        Console.WriteLine(xulambs.BuscarPedidos(tmp));
                                        Console.ReadKey();
                                    }
                                    else
                                        throw new ArgumentNullException("Cliente inexistente");
                                    break;
                                case 3:
                                    Console.WriteLine("Digite o nome do cliente a ser criado a requisicao");
                                    Console.WriteLine("Clientes atuais: ");
                                    clientes.ForEach(Console.WriteLine);
                                    nome = Console.ReadLine();
                                    tmp = VerificarCliente(nome);
                                    if (tmp != null)
                                    {
                                        Console.WriteLine("\nDigite a quantidade de pessoas que irão sentar na mesa: ");
                                        int quantidade = int.Parse(Console.ReadLine());
                                        xulambs.solicitarMesa(tmp, quantidade);
                                        Console.WriteLine("\nRequisicao criada com sucesso");
                                        Console.ReadKey();
                                    }
                                    else
                                        throw new ArgumentNullException("Cliente inexistente");

                                    break;
                                case 4:
                                    Console.WriteLine("Digite o nome do cliente para fechar o pedido: ");
                                    nome = Console.ReadLine();
                                    double valor = ;
                                    Console.WriteLine("Conta fechada e requisiçao encerrada! Total do pedido: \n"+xulambs.FecharConta(nome).ToString("0.00")+" R$");
                                    Console.ReadKey();
                                    break;
                                case 5:
                                    Console.WriteLine("Digite o nome do cliente por favor: ");
                                    nome = Console.ReadLine();
                                    tmp = VerificarCliente(nome);
                                    if (tmp != null)
                                    {
                                        ApresentarCardapioRestaurante();
                                        Console.WriteLine("Digite o id do produto a ser adicionado ao pedido");
                                        int idProduto = int.Parse(Console.ReadLine());
                                        xulambs.incluirProduto(idProduto, nome);
                                        Console.WriteLine("Produto inserido com sucesso!!");
                                        Console.ReadKey();
                                    }
                                    else
                                        throw new ArgumentNullException("Cliente não existente!");

                                    break;
                                case 6:
                                    Console.WriteLine("Lista de clientes atuais do restaurante");
                                    foreach (Cliente cliente in clientes)
                                    {
                                        Console.WriteLine(cliente.ToString());
                                    }
                                    Console.ReadKey();
                                    break;

                                case 7:
                                    Console.WriteLine("Dados do Restaurante");
                                    Console.WriteLine(xulambs.ToString());
                                    Console.ReadKey();
                                    break;
                                    
                                case 0:
                                    break;


                            }
                        } while (opcao != 0);
                        break;
                    case 2:

                        do
                        {
                            Console.Clear();
                            Console.WriteLine("Menu da Cafeteria");
                            Console.WriteLine("==============================");
                            Console.WriteLine("1 - Receber Cliente");
                            Console.WriteLine("2 - Adicionar Pedido à Comanda");
                            Console.WriteLine("3 - Verificar pedidos do cliente");
                            Console.WriteLine("4 - Fechar comanda");
                            Console.WriteLine("5 - Lista de clientes");
                            Console.WriteLine("0 - Sair");
                            Console.Write("Digite sua opção: ");
                            int.TryParse(Console.ReadLine(), out opcao);


                            switch (opcao)
                            {
                                case 1:
                                    bool nomeLivre = true;
                                    do
                                    {
                                        Console.WriteLine("Digite o nome do cliente: ");
                                        nome = Console.ReadLine();
                                        nomeLivre = VerificarNomeCafeteria(nome);
                                        if (nomeLivre == true)
                                        {
                                            Cliente cliente1 = new Cliente(nome);
                                            clientesCafeteria.Add(cliente1);
                                            Console.WriteLine("Cliente adicionado com sucesso!");
                                            cafeteria.CriarComanda(cliente1);
                                            Console.ReadKey();
                                        }
                                        else
                                        {
                                            Console.WriteLine("Nome invalido, tente outro");
                                            Console.ReadKey();
                                        }

                                    }
                                    while (nomeLivre == false);
                                    break;

                                case 2:
                                    Console.WriteLine("Digite o nome do cliente por favor: ");
                                    nome = Console.ReadLine();
                                    tmp = VerificarClienteCafeteria(nome);
                                    if (tmp != null)
                                    {
                                        ApresentarCardapioCafeteria();
                                        Console.WriteLine("Digite o id do produto a ser adicionado ao pedido");
                                        int idProduto = int.Parse(Console.ReadLine());
                                        cafeteria.incluirProduto(idProduto, nome);
                                        Console.WriteLine("Produto inserido com sucesso!!");
                                        Console.ReadKey();
                                    }
                                    else
                                        throw new ArgumentNullException("Cliente não existente!");
                                    break;

                                case 3:
                                    Console.WriteLine("Digite o nome do Cliente: ");
                                    nome = Console.ReadLine();
                                    tmp = VerificarClienteCafeteria(nome);
                                    if (tmp != null)
                                    {
                                        Console.WriteLine(cafeteria.BuscarPedidos(tmp));
                                        Console.ReadKey();
                                    }
                                    else
                                        throw new ArgumentNullException("Cliente inexistente");

                                    break;

                                case 4:
                                    Console.WriteLine("Digite o nome do cliente para fechar a Comanda");
                                    nome = Console.ReadLine();
                                    tmp = VerificarClienteCafeteria(nome);
                                    if (tmp != null)
                                    {
                                        Console.WriteLine("Comanda fechada com sucesso! total do pedido: " + cafeteria.FecharComanda(nome).ToString("0.00")+" R$");
                                        Console.ReadKey();
                                    }
                                    else
                                        throw new ArgumentNullException("Cliente inexistente");
                                    break;

                                case 5:
                                    Console.WriteLine("Lista de clientes atuais da cafeteria: ");
                                    foreach(Cliente cliente in clientesCafeteria)
                                    {
                                        Console.WriteLine(cliente.ToString());
                                    }
                                    Console.ReadKey();
                                    break;

                                case 0:
                                    break;
                            }



                        } while (opcao != 0);
                        break;
                    case 0:
                        break;
                }

            } while (escolha != 0);






            

        }
        }
    }
