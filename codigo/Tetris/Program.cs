using Tetris.Model;

namespace Tetris
{
    internal class Program
    {
        static Restaurante xulambs = new Restaurante();
        static List<Cliente> clientes = new List<Cliente>();

        internal static void ApresentarCardapio()
        {
            xulambs.ApresentarCardapio();
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
        

        internal static void Main(string[] args)
        {

            int opcao;
            cabecalho();
            do
            {
                Console.WriteLine("==============================");
                Console.WriteLine("1 - Cadastrar Cliente");
                Console.WriteLine("2 - Localizar Pedidos do Cliente");
                Console.WriteLine("3 - Criar Requisição de mesa");
                Console.WriteLine("4 - Finalizar Requisição");
                Console.WriteLine("5 - Adicionar Pedido ao cliente");
                Console.WriteLine("0 - Sair");
                Console.Write("Digite sua opção: ");
                int.TryParse(Console.ReadLine(), out opcao);

                Cliente tmp;
                string nome;
                switch (opcao) 
                {
                    case 1:
                        
                        
                        bool nomeLivre = true;
                        do
                        {
                            Console.WriteLine("Digite o nome do cliente: ");
                            nome = Console.ReadLine();
                            nomeLivre = VerificarNome(nome);
                            if(nomeLivre == true)
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
                        nome = Console.ReadLine();
                        tmp = VerificarCliente(nome);
                        if (tmp != null)
                        {
                            Console.WriteLine("Digite a quantidade de pessoas que irão sentar na mesa: ");
                            int quantidade = int.Parse(Console.ReadLine());
                            xulambs.solicitarMesa(tmp, quantidade);
                            Console.WriteLine("Requisicao criada com sucesso");
                            Console.ReadKey();
                        }
                        else
                            throw new ArgumentNullException("Cliente inexistente");
                        
                        break;
                    case 4:
                        Console.WriteLine("Digite o nome do cliente para fechar o pedido: ");
                        nome = Console.ReadLine();
                        double valor = xulambs.FecharConta(nome);
                        Console.WriteLine("Conta fechada e requisiçao encerrada! Total do pedido: \n" + valor.ToString());
                        Console.ReadKey();
                        break;
                    case 5:
                        Console.WriteLine("Digite o nome do cliente por favor: ");
                        nome = Console.ReadLine();
                        tmp = VerificarCliente(nome);
                        if(tmp != null)
                        {
                            ApresentarCardapio();
                            Console.WriteLine("Digite o id do produto a ser adicionado ao pedido");
                            int idProduto = int.Parse(Console.ReadLine());
                            xulambs.incluirProduto(idProduto, nome);
                            Console.WriteLine("Produto inserido com sucesso!!");
                        }
                        else
                            throw new ArgumentNullException("Cliente não existente!");
                        
                        break;
                
                
                }
            }while(opcao != 0);
            
            

        }
        }
    }
