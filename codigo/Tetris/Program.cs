using Tetris.Model;

namespace Tetris
{
    internal class Program
    {
        #region Atributos
        static Estabelecimento estabelecimento;
        static List<Cliente> clientes = new List<Cliente>();
        static string tentativa;
        static int escolha;
        static int opcao;
        static Cliente tmp;
        static string nome;
        static bool entradaValida;

        #endregion
        // Método que chama a função ApresentarCardapio do objeto estabelecimento
        internal static void ApresentarCardapio()
        {
            estabelecimento.ApresentarCardapio();
        }
        // Método que limpa a tela e imprime o cabeçalho do projeto
        internal static void cabecalho()
        {
            Console.Clear();
            Console.WriteLine("Projeto: OO Comidinhas Veganas");
            Console.WriteLine("==============================");
        }

        // Método que adiciona um cliente à lista de clientes
        internal static void AdicionarCliente()
        {
            do
            {
                Console.WriteLine("Digite o nome do cliente: ");
                nome = Console.ReadLine();
                entradaValida = VerificarNome(nome);

                if (entradaValida == true && !String.IsNullOrWhiteSpace(nome))
                {
                    Cliente cliente1 = new Cliente(nome);
                    clientes.Add(cliente1);
                    Console.WriteLine("Cliente adicionado com sucesso!!");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Nome invalido, tente outro");
                    entradaValida = false;
                    Console.ReadKey();
                }

            }
            while (entradaValida == false);
        }
        // Método sobrecarregado para adicionar um cliente e criar uma requisição com uma quantidade específica
        internal static void AdicionarCliente(int quantidade)
        {
            do
            {
                Console.WriteLine("Digite o nome do cliente: ");
                nome = Console.ReadLine();
                entradaValida = VerificarNome(nome);

                if (entradaValida == true && !String.IsNullOrWhiteSpace(nome))
                {
                    Cliente cliente1 = new Cliente(nome);
                    clientes.Add(cliente1);
                    estabelecimento.CriarRequisicao(cliente1, quantidade);
                    Console.WriteLine("Cliente adicionado com sucesso!!");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Nome invalido, tente outro");
                    entradaValida = false;
                    Console.ReadKey();
                }

            }
            while (entradaValida == false);
        }
        // Método que verifica os pedidos de um cliente específico
        internal static void VerificarPedidos()
        {
            do
            {

                Console.WriteLine("Digite o nome do Cliente: ");
                nome = Console.ReadLine();
                tmp = VerificarCliente(nome);
                try
                {
                    if (tmp != null)
                    {
                        Console.WriteLine("Pedidos atuais do cliente");
                        Console.WriteLine(estabelecimento.BuscarPedidos(tmp));
                        entradaValida = true;
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("Cliente inexistente, favor crie um cliente!!");
                        Console.ReadKey();
                        break;
                    }
                }
                catch (NullReferenceException)
                {
                    Console.WriteLine("Não existem pedidos para esse cliente, Adicione um pedido primeiro!!");
                    entradaValida = false;
                    Console.ReadKey();
                    break;
                }


            } while (entradaValida == false);
            
        }
        // Método que fecha os pedidos de um cliente específico
        internal static void FecharPedidos()
        {
            do
            {
                Console.WriteLine("Digite o nome do cliente para fechar o pedido: ");
                nome = Console.ReadLine();
                tmp = VerificarCliente(nome);

                if (tmp != null)
                {
                    try
                    {
                        Console.WriteLine("Conta fechada e requisiçao encerrada! Total do pedido: \n" + estabelecimento.FecharConta(nome).ToString("0.00") + " R$");
                        clientes.Remove(tmp);
                        entradaValida = true;
                        Console.ReadKey();
                    }
                    catch (NullReferenceException)
                    {
                        Console.WriteLine("Esse cliente não tem uma requisicão ainda por favor crie uma!");
                        Console.ReadKey();
                        break;

                    }

                }
                else
                {
                    Console.WriteLine("Cliente inexistente, primeiro adicione um cliente!");
                    entradaValida = false;
                    Console.ReadKey();
                    break;
                }
            } while (entradaValida == false);
        }
        // Método que verifica se um cliente está na lista de clientes
        internal static Cliente VerificarCliente(string nome)
        {
            return clientes.Where(x => x.GetNome() == nome).SingleOrDefault();
        }
        // Método que verifica se o nome do cliente é válido
        internal static bool VerificarNome(string nome) => clientes.FirstOrDefault(x => x.GetNome() == nome) != null ? false : true;

        // Método principal que exibe o menu e executa as funcionalidades do programa
        internal static void Main(string[] args)
        {
            
            do
            {
                cabecalho();
                Console.WriteLine("Qual menu deseja acessar? ");
                Console.WriteLine("1 - Restaurante OO Comidinhas Veganas");
                Console.WriteLine("2 - Cafeteria OO Comidinhas Veganas");
                Console.WriteLine("0 - Sair");
                int.TryParse(Console.ReadLine(), out escolha);

                switch (escolha)
                {
                    #region Menu Restaurante
                    case 1:

                        estabelecimento = new Restaurante();
                        //Restaurante restaurante = (Restaurante)estabelecimento;
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
                            Console.WriteLine("7 - Exibir mesas ocupadas/livres e clientes na fila de espera");
                            Console.WriteLine("0 - Sair");
                            Console.Write("Digite sua opção: ");
                            int.TryParse(Console.ReadLine(), out opcao);


                            switch (opcao)
                            {
                                #region Adicionar Cliente
                                case 1: 

                                    AdicionarCliente();
                                    break;
                                #endregion

                                #region Verificar Pedidos
                                case 2:
                                
                                    VerificarPedidos();
                                    break;
                                #endregion

                                #region Criar Requisicao
                                case 3: //Criar Requisição de mesa
                                    do
                                    {
                                        

                                        Console.WriteLine("Digite o nome do cliente a ser criado a requisicao");
                                        Console.WriteLine("Lista de Clientes atuais: ");
                                        clientes.ForEach(Console.WriteLine);
                                        nome = Console.ReadLine();
                                        tmp = VerificarCliente(nome);

                                        if (tmp != null)
                                        {
                                            if (estabelecimento.TemRequisicao(tmp) == true)
                                            {
                                                Console.WriteLine("O cliente já tem uma requisição!");
                                                entradaValida = true;
                                                Console.ReadKey();

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
                                                estabelecimento.CriarRequisicao(tmp, quantidade);
                                                Console.WriteLine("Requisicao para {0} pessoas criada com sucesso",quantidade);
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
                                #endregion

                                #region Fechar Pedido
                                case 4:

                                    FecharPedidos();
                                    break;

                                #endregion

                                #region Adicionar Pedidos
                                case 5:
                                    Console.WriteLine("Digite o nome do cliente por favor: ");
                                    nome = Console.ReadLine();
                                    tmp = VerificarCliente(nome);
                                    
                                    do
                                    {
                                            if (tmp != null)
                                            {
                                                try
                                                {
                                                    do
                                                    {
                                                        Console.Clear();
                                                        ApresentarCardapio();
                                                        Console.WriteLine("Digite o id do produto a ser adicionado ao pedido");
                                                        int idProduto = int.Parse(Console.ReadLine());
                                                        estabelecimento.incluirProduto(idProduto, nome);
                                                        Console.WriteLine("Produto inserido com sucesso!!");
                                                        entradaValida = true;
                                                        Console.WriteLine("Deseja adicionar mais um produto? (s/n)");
                                                        tentativa = Console.ReadLine();
                                                        if (tentativa == "s")
                                                        {
                                                            continue;
                                                        }
                                                        else if (tentativa == "n")
                                                        {
                                                            break;
                                                        }
                                                        else
                                                        {
                                                            Console.WriteLine("Opcao inválida, tente novamente");
                                                            entradaValida = false;
                                                            continue;
                                                        }
                                                        
                                                    } while (true);
                                                    
                                                }
                                                catch (NullReferenceException ex)
                                                {
                                                    Console.WriteLine("O cliente não tem uma requisiçao para adicionar o pedido, deseja criar uma? (s/n)");
                                                    tentativa = Console.ReadLine();
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

                                                        estabelecimento.CriarRequisicao(tmp, quantidade);
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
                                                    Console.ReadKey();
                                                    break;
                                                }
                                                catch (Exception ex)
                                                {
                                                    Console.WriteLine("Ocorreu um erro");
                                                    Console.ReadKey();
                                                    break;
                                                }
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

                                                    estabelecimento.CriarRequisicao(tmp, quantidade);
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

                                    } while (entradaValida == false);
                                    

                                    break;
                                    #endregion

                                case 6:
                                    Console.WriteLine("Lista de clientes atuais do restaurante");
                                    foreach (Cliente cliente in clientes)
                                    {
                                        Console.WriteLine(cliente.ToString());
                                    }
                                    Console.ReadKey();
                                    break;

                                case 7:
                                    Console.WriteLine("Mesas Ocupadas e Clientes em fila de espera atualmente");
                                    Console.WriteLine(estabelecimento.ToString());
                                    Console.ReadKey();
                                    break;

                                case 0:
                                    break;


                            }
                        } while (opcao != 0);
                        break;

#endregion
                    case 2:

                        estabelecimento = new Cafeteria();
                        clientes = new List<Cliente>();
                        do
                        {
                            Console.Clear();
                            Console.WriteLine("Menu da Cafeteria");
                            Console.WriteLine("==============================");
                            Console.WriteLine("1 - Receber Cliente");
                            Console.WriteLine("2 - Verificar pedidos do cliente");
                            Console.WriteLine("3 - Fechar pedido do cliente");
                            Console.WriteLine("4 - Adicionar pedido");
                            Console.WriteLine("5 - Lista de clientes");
                            Console.WriteLine("0 - Sair");
                            Console.Write("Digite sua opção: ");
                            int.TryParse(Console.ReadLine(), out opcao);


                            switch (opcao)
                            {
                                case 1:
                                    AdicionarCliente(1);
                                    break;

                                case 2:
                                    VerificarPedidos();
                                    break;

                                case 3:
                                    FecharPedidos();

                                    break;

                                case 4:
                                    Console.WriteLine("Digite o nome do cliente por favor: ");
                                    nome = Console.ReadLine();
                                    tmp = VerificarCliente(nome);

                                    do
                                    {
                                        if (tmp != null)
                                        {
                                            try
                                            {
                                                do
                                                {
                                                    Console.Clear();
                                                    ApresentarCardapio();
                                                    Console.WriteLine("Digite o id do produto a ser adicionado ao pedido");
                                                    int idProduto = int.Parse(Console.ReadLine());
                                                    estabelecimento.incluirProduto(idProduto, nome);
                                                    Console.WriteLine("Produto inserido com sucesso!!");
                                                    entradaValida = true;
                                                    Console.WriteLine("Deseja adicionar mais um produto? (s/n)");
                                                    tentativa = Console.ReadLine();
                                                    if (tentativa == "s")
                                                    {
                                                        continue;
                                                    }
                                                    else if (tentativa == "n")
                                                    {
                                                        break;
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("Opcao inválida, tente novamente");
                                                        entradaValida = false;
                                                        continue;
                                                    }

                                                } while (true);

                                            }
                                            catch (NullReferenceException ex)
                                            {
                                                Console.WriteLine("O cliente não tem uma requisiçao para adicionar o pedido, deseja criar uma? (s/n)");
                                                tentativa = Console.ReadLine();
                                                if (tentativa == "s")
                                                {

                                                    estabelecimento.CriarRequisicao(tmp, 1);
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
                                                Console.ReadKey();
                                                break;
                                            }
                                            catch (Exception ex)
                                            {
                                                Console.WriteLine("Ocorreu um erro");
                                                Console.ReadKey();
                                                break;
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("Cliente inexistente! Deseja criar um(a) com esse nome?(s/n)");
                                            tentativa = Console.ReadLine().ToLower();

                                            if (tentativa == "s")
                                            {
                                                tmp = new Cliente(nome);
                                                clientes.Add(tmp);
                                                Console.WriteLine("Cliente criado com sucesso!");
                                                estabelecimento.CriarRequisicao(tmp, 1);
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

                                    } while (entradaValida == false);
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
