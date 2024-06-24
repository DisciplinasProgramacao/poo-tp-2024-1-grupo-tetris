using Tetris.Model;

namespace Tetris
{
    internal class Program
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
            Console.Write("Qual é a quantidade de pessoas? ");
            qtdPessoas = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine($"\nCliente cadastrado:\n {novoCliente.ToString()}");
            pausa();
            return novoCliente;
        }

        private static void localizarCliente()
        {
            
        }

        public static Requisicao criarRequisicao(Restaurante restaurante, Cliente? cliente)
        {
            Requisicao req;
            try {
                Console.WriteLine("Digite a quantidade de pessoas");
                var qnt = Convert.ToInt32(Console.ReadLine());
                req = new Requisicao(cliente, qnt);
                Console.WriteLine($"\n{req} adicionada com sucesso.");

                return req;
            }
            catch (ArgumentNullException argEx)           {
                Console.WriteLine("Não pode abrir uma requisiçãõ sem ter cadastrado um cliente");
            }
            return null;
        }

        public static void Main(string[] args)
        {
            Cliente ultimoClienteRegistrado = null;
            int opcao;
            Restaurante restaurante = new Restaurante();
            Requisicao req = null;

        }
        }
    }
