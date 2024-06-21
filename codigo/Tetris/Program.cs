using Tetris.Model;

namespace Tetris
{
    public class Program
    {
        public static void pausa()
        {
            Console.Write("\nTecle Enter para continuar.");
            Console.ReadKey();
        }
        
        public static void cabecalho()
        {
            Console.Clear();
            Console.WriteLine("Projeto: OO Comidinhas Veganas");
            Console.WriteLine("==============================");
        }

        public static int MenuPrincipal()
        {
            int opcao;
            cabecalho();
            Console.WriteLine("1 - Cadastrar Cliente");
            Console.WriteLine("2 - Localizar Cliente");
            Console.WriteLine("3 - Criar Requisição");
            Console.WriteLine("4 - Finalizar Requisição");
            Console.WriteLine("5 - ");
            Console.WriteLine("0 - Sair");
            Console.Write("Digite sua opção: ");
            int.TryParse(Console.ReadLine(), out opcao);
            return opcao;
        }

        private static Cliente cadastrarCliente(Restaurante restaurante)
        {
            string nome;
            int qtdPessoas;
            Cliente novo;
            cabecalho();
            Console.Write("Qual é o nome do novo cliente? ");
            nome = Console.ReadLine();
            var novoCliente = new Cliente(nome);
            restaurante.adicionarCliente(novoCliente);

            Console.Write("Qual é a quantidade de pessoas? ");
            qtdPessoas = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine($"\nCliente cadastrado:\n {novoCliente.ToString()}");
            pausa();
            return novoCliente;
        }

        private static Cliente localizarCliente(Restaurante restaurante)
        {
            int idCli;
            Cliente quem;

            cabecalho();
            Console.Write("Digite o id do cliente: ");
            idCli = int.Parse(Console.ReadLine());
            quem = restaurante.LocalizarCliente(idCli);
            return quem;
        }

        public static Requisicao criarRequisicao(Restaurante restaurante, Cliente? cliente)
        {
            Requisicao req;
            try {
                Console.WriteLine("Digite a quantidade de pessoas");
                var qnt = Convert.ToInt32(Console.ReadLine());
                req = new Requisicao(cliente, qnt);
                Console.WriteLine($"\n{novaRequisicao} adicionada com sucesso.");

                return novaRequisicao;
            }
            catch (ArgumentNullException argEx)           {
                Console.WriteLine("Não pode abrir uma requisiçãõ sem ter cadastrado um cliente");
            }
            return 
        }
        
        public static void Main(string[] args)
        {
            Cliente ultimoClienteRegistrado = null;
            int opcao;
            Restaurante restaurante = new Restaurante();

            do
            {
                opcao = MenuPrincipal();
                switch (opcao)
                {
                    case 1:
                        ultimoClienteRegistrado = cadastrarCliente(restaurante);

                        pausa();
                        break;
                    case 2:
                        var clienteAtual = localizarCliente(restaurante);
                        if (clienteAtual != null)
                        {
                            Console.WriteLine($"\n{clienteAtual}");
                        }
                        else
                        {
                            Console.WriteLine("Cliente não encontrado.");
                        }
                        pausa();
                        break;
                    case 3:
                            criarRequisicao(restaurante, ultimoClienteRegistrado);
                        pausa();
                        break;
                    case 4:
                        if (idRequisicao != null)
                        {
                            idRequisicao = finalizarRequisicao();
                        }
                        else
                        {
                            Console.WriteLine($"Requisição de nº {idRequisicao} não encontrada!");
                        }
                        pausa();
                        break;
                }
            } while (opcao != 0);

        }
    }
}
