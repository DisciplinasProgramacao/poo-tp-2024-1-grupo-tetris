using Tetris.Model;

namespace Tetris
{
    internal class Program
    {
        static Estabelecimento estabelecimento;
        static List<Cliente> clientes = new List<Cliente>();


        internal static void ApresentarCardapio()
        {
            estabelecimento.ApresentarCardapio();
        }
        internal static void cabecalho()
        {
            Console.Clear();
            Console.WriteLine("Projeto: OO Comidinhas Veganas");
            Console.WriteLine("==============================");
        }

        internal static Cliente VerificarCliente(string nome)
        {
            return clientes.Where(x => x.GetNome() == nome).SingleOrDefault();
        }

        internal static bool VerificarNome(string nome)
        {
            if (nome == null || nome == " ")
                return false;
            else
            {


                if (clientes != null)
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

        }


        internal static void Main(string[] args)
        {
            string tentativa;
            int escolha;
            int opcao;
            Cliente tmp;
            string nome;
            bool entradaValida;

            do
            {
                cabecalho();
                Console.WriteLine("Qual menu deseja acessar? ");
                Console.WriteLine("1 - Restaurante Xulambs");
                Console.WriteLine("2 - Cafeteria Xulambs");
                Console.WriteLine("0 - Sair");
                int.TryParse(Console.ReadLine(), out escolha);

                switch (escolha)
                {
                    case 1:

                        estabelecimento = new Restaurante();
                        Restaurante restaurante = (Restaurante)estabelecimento;
                        clientes = new List<Cliente>();
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

                                    do
                                    {
                                        Console.WriteLine("Digite o nome do cliente: ");
                                        nome = Console.ReadLine();
                                        entradaValida = VerificarNome(nome);
                                        if (entradaValida == true)
                                        {
                                            Cliente cliente1 = new Cliente(nome);
                                            clientes.Add(cliente1);
                                            Console.WriteLine("Cliente adicionado com sucesso!!");
                                            Console.ReadKey();
                                        }
                                        else
                                        {
                                            Console.WriteLine("Nome invalido, tente outro");
                                            Console.ReadKey();
                                        }

                                    }
                                    while (entradaValida == false);
                                    break;
                                case 2:
                                    do
                                    {

                                        Console.WriteLine("Digite o nome do Cliente: ");
                                        nome = Console.ReadLine();
                                        tmp = VerificarCliente(nome);
                                        try
                                        {
                                            if (tmp != null)
                                            {
                                                Console.WriteLine(restaurante.BuscarPedidos(tmp));
                                                entradaValida = true;
                                                Console.ReadKey();
                                            }
                                            else
                                            {
                                                Console.WriteLine("Cliente inexistente, favor crie um cliente!!");
                                                break;
                                            }
                                        }
                                        catch (NullReferenceException)
                                        {
                                            Console.WriteLine("Não existem pedidos para esse cliente, Adicione um pedido primeiro!!");
                                            entradaValida = false;
                                            break;
                                        }


                                    } while (entradaValida == false);
                                    break;
                                case 3:
                                    do
                                    {
                                        //Criar requisição

                                        Console.WriteLine("Digite o nome do cliente a ser criado a requisicao");
                                        Console.WriteLine("Lista de Clientes atuais: ");
                                        clientes.ForEach(Console.WriteLine);
                                        nome = Console.ReadLine();
                                        tmp = VerificarCliente(nome);

                                        if (tmp != null)
                                        {
                                            if (restaurante.TemRequisicao(tmp) == true)
                                            {
                                                Console.WriteLine("O cliente já tem uma requisição!");
                                                entradaValida = true;

                                            }
                                            else
                                            {
                                                int quantidade;
                                                do
                                                {
                                                    Console.WriteLine("Para quantas pessoas? ");
                                                    quantidade = int.Parse(Console.ReadLine());
                                                    if (quantidade <= 0 || quantidade > 8)
                                                    {
                                                        Console.WriteLine("Capacidade das mesas vão de 1 a 8!");
                                                    }

                                                } while (quantidade <= 0 || quantidade > 8);
                                                restaurante.solicitarMesa(tmp, quantidade);
                                                entradaValida = true;
                                                Console.ReadKey();
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("Cliente inexistente, primeiro adicione um cliente com esse nome!");
                                            entradaValida = false;
                                            break;

                                        }


                                    } while (entradaValida == false);

                                    break;
                                case 4:

                                    do
                                    {
                                        Console.WriteLine("Digite o nome do cliente para fechar o pedido: ");
                                        nome = Console.ReadLine();
                                        tmp = VerificarCliente(nome);

                                        if (tmp != null)
                                        {
                                            try
                                            {
                                                Console.WriteLine("Conta fechada e requisiçao encerrada! Total do pedido: \n" + restaurante.FecharConta(nome).ToString("0.00") + " R$");
                                                clientes.Remove(tmp);
                                                entradaValida = true;
                                                Console.ReadKey();
                                            }
                                            catch (NullReferenceException)
                                            {
                                                Console.WriteLine("Esse cliente não tem uma requisicão ainda por favor crie uma!");
                                                break;

                                            }

                                        }
                                        else
                                        {
                                            Console.WriteLine("Cliente inexistente, primeiro adicione um cliente!");
                                            entradaValida = false;
                                            break;
                                        }
                                    } while (entradaValida == false);

                                    break;
                                case 5:
                                    Console.WriteLine("Digite o nome do cliente por favor: ");
                                    nome = Console.ReadLine();
                                    tmp = VerificarCliente(nome);
                                    if (VerificarNome(nome) == false)
                                    {
                                        Console.WriteLine("Nome invalido!");
                                        break;
                                    }

                                    do
                                    {
                                        try
                                        {
                                            if (tmp != null)
                                            {
                                                ApresentarCardapio();
                                                Console.WriteLine("Digite o id do produto a ser adicionado ao pedido");
                                                int idProduto = int.Parse(Console.ReadLine());
                                                restaurante.incluirProduto(idProduto, nome);
                                                Console.WriteLine("Produto inserido com sucesso!!");
                                                entradaValida = true;
                                                Console.ReadKey();
                                            }
                                            else
                                            {
                                                Console.WriteLine("Cliente inexistente! Deseja criar um(a) com esse nome?(s/n)");
                                                tentativa = Console.ReadLine().ToLower();

                                                if (tentativa == "s")
                                                {
                                                    tmp = new Cliente(nome);
                                                    clientes.Add(tmp);
                                                    int quantidade;
                                                    Console.WriteLine("Cliente criado com sucesso!");
                                                    do
                                                    {
                                                        Console.WriteLine("Para quantas pessoas será a mesa? (entre 1 e 8)");
                                                        quantidade = int.Parse(Console.ReadLine());

                                                        if (quantidade <= 0 || quantidade >= 8)
                                                        {
                                                            Console.WriteLine("Quantidade invalida!");
                                                        }

                                                    } while (quantidade <= 0 || quantidade >= 8);

                                                    restaurante.solicitarMesa(tmp, quantidade);
                                                    entradaValida = true;

                                                }
                                                else if (tentativa == "n")
                                                {
                                                    break;
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Opcao inválida, tente novamente");
                                                    entradaValida = false;
                                                }


                                            }

                                        }
                                        catch (NullReferenceException)
                                        {
                                            Console.WriteLine("Não existe uma requisição para esse cliente! Deseja criar uma?");
                                            tentativa = Console.ReadLine().ToLower();
                                            if (tentativa == "s")
                                            {
                                                int quantidade;
                                                do
                                                {
                                                    Console.WriteLine("Para quantas pessoas será a mesa? (entre 1 e 8)");
                                                    quantidade = int.Parse(Console.ReadLine());

                                                    if (quantidade <= 0 || quantidade >= 8)
                                                    {
                                                        Console.WriteLine("Quantidade invalida!");
                                                    }

                                                } while (quantidade <= 0 || quantidade >= 8);

                                                restaurante.solicitarMesa(tmp, quantidade);
                                                entradaValida = true;
                                            }
                                            else if (tentativa == "n")
                                            {
                                                break;
                                            }
                                            else
                                            {
                                                Console.WriteLine("Opcao inválida tente novamente");
                                                entradaValida = false;
                                            }


                                        }


                                    } while (entradaValida == false);


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
                                    Console.WriteLine(restaurante.ToString());
                                    Console.ReadKey();
                                    break;

                                case 0:
                                    break;


                            }
                        } while (opcao != 0);
                        break;
                    case 2:

                        estabelecimento = new Cafeteria();
                        Cafeteria cafeteria = (Cafeteria)estabelecimento;
                        clientes = new List<Cliente>();
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
                                        nomeLivre = VerificarNome(nome);
                                        if (nomeLivre == true)
                                        {
                                            Cliente cliente1 = new Cliente(nome);
                                            clientes.Add(cliente1);
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
                                    tmp = VerificarCliente(nome);
                                    if (tmp != null)
                                    {
                                        ApresentarCardapio();
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
                                    tmp = VerificarCliente(nome);
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
                                    tmp = VerificarCliente(nome);
                                    if (tmp != null)
                                    {
                                        Console.WriteLine("Comanda fechada com sucesso! total do pedido: " + cafeteria.FecharConta(nome).ToString("0.00") + " R$");
                                        Console.ReadKey();
                                    }
                                    else
                                        throw new ArgumentNullException("Cliente inexistente");
                                    break;

                                case 5:
                                    Console.WriteLine("Lista de clientes atuais da cafeteria: ");
                                    clientes.ForEach(Console.WriteLine);
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
