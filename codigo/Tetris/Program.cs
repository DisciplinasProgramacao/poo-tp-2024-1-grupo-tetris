using System;
using Tetris.Model;

namespace Tetris
{
    public class Program
    {
        // Método para pausar a execução e aguardar Enter
        public static void Pausa()
        {
            Console.Write("\nTecle Enter para continuar.");
            Console.ReadKey();
        }

        // Método para exibir o cabeçalho do programa
        public static void Cabecalho()
        {
            Console.Clear();
            Console.WriteLine("Projeto: OO Comidinhas Veganas");
            Console.WriteLine("==============================");
        }

        // Método para exibir o menu principal e obter a opção escolhida pelo usuário
        public static int MenuPrincipal()
        {
            int opcao;
            Cabecalho();
            Console.WriteLine("1 - Cadastrar Cliente");
            Console.WriteLine("2 - Localizar Cliente");
            Console.WriteLine("3 - Criar Requisição");
            Console.WriteLine("4 - Finalizar Requisição");
            Console.WriteLine("5 - Ver Cardápio");
            Console.WriteLine("6 - Selecionar Produto");
            Console.WriteLine("7 - Incluir Produto na Requisição");
            Console.WriteLine("8 - Fechar Conta e Mostrar Conta");
            Console.WriteLine("0 - Sair");
            Console.Write("Digite sua opção: ");
            int.TryParse(Console.ReadLine(), out opcao);
            return opcao;
        }

        // Método para cadastrar um novo cliente
        private static Cliente CadastrarCliente(Restaurante restaurante)
        {
            string nome;
            Cliente novoCliente;
            Cabecalho();
            Console.Write("Qual é o nome do novo cliente? ");
            nome = Console.ReadLine();
            novoCliente = new Cliente(nome);

            Console.WriteLine($"\nCliente cadastrado:\n{novoCliente}");
            Pausa();
            return novoCliente;
        }

        // Método para localizar um cliente pelo nome
        private static Cliente LocalizarCliente(Restaurante restaurante)
        {
            Cabecalho();
            Console.Write("Digite o nome do cliente: ");
            string nome = Console.ReadLine();
            Cliente cliente = restaurante.BuscarCliente(nome);
            if (cliente != null)
            {
                Console.WriteLine($"Cliente encontrado:\n{cliente}");
            }
            else
            {
                Console.WriteLine("Cliente não encontrado.");
            }
            Pausa();
            return cliente;
        }

        // Método para criar uma requisição de mesa
        public static Requisicao CriarRequisicao(Restaurante restaurante, Cliente cliente)
        {
            Requisicao req = null;
            try
            {
                Console.WriteLine("Digite a quantidade de pessoas:");
                int qnt = Convert.ToInt32(Console.ReadLine());
                req = new Requisicao(cliente, qnt);
                Console.WriteLine($"\n{req} adicionada com sucesso.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao criar requisição: {ex.Message}");
            }
            return req;
        }

        // Método para exibir o cardápio
        public static void VerCardapio(Restaurante restaurante)
        {
            Cabecalho();
            Console.WriteLine(restaurante.Cardapio.ApresentarCardapio());
        }

        // Método para selecionar um produto do cardápio
        public static Produto SelecionarProduto(Restaurante restaurante)
        {
            VerCardapio(restaurante);
            Console.Write("\nDigite o ID do produto que deseja selecionar: ");
            int idProduto = Convert.ToInt32(Console.ReadLine());
            return restaurante.Cardapio.BuscarProduto(idProduto);
        }

        // Método para incluir um produto na requisição
        public static void IncluirProdutoNaRequisicao(Requisicao requisicao, Produto produto)
        {
            requisicao.ReceberProduto(produto);
            Console.WriteLine($"\nProduto '{produto.Nome}' incluído na requisição.");
        }

        // Método para fechar a conta de uma requisição e mostrar a conta
        public static void FecharContaEMostrarConta(Restaurante restaurante, int idRequisicao)
        {
            try
            {
                double valorConta = restaurante.FecharConta(idRequisicao);
                Console.WriteLine($"\nConta da requisição nº {idRequisicao} fechada com sucesso.");
                Console.WriteLine($"Valor total da conta: R$ {valorConta:F2}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao fechar a conta: {ex.Message}");
            }
        }

        // Método principal do programa
        public static void Main(string[] args)
        {
            Cliente ultimoClienteRegistrado = null;
            int opcao;
            Restaurante restaurante = new Restaurante();
            Requisicao req = null;

            do
            {
                opcao = MenuPrincipal();
                switch (opcao)
                {
                    case 1:
                        ultimoClienteRegistrado = CadastrarCliente(restaurante);
                        Pausa();
                        break;
                    case 2:
                        ultimoClienteRegistrado = LocalizarCliente(restaurante);
                        Pausa();
                        break;
                    case 3:
                        req = CriarRequisicao(restaurante, ultimoClienteRegistrado);
                        Pausa();
                        break;
                    case 4:
                        if (req != null)
                        {
                            req.EncerrarRequisicao();
                        }
                        else
                        {
                            Console.WriteLine("Requisição não encontrada.");
                        }
                        Pausa();
                        break;
                    case 5:
                        VerCardapio(restaurante);
                        Pausa();
                        break;
                    case 6:
                        Produto produtoSelecionado = SelecionarProduto(restaurante);
                        Console.WriteLine($"\nProduto selecionado: {produtoSelecionado}");
                        Pausa();
                        break;
                    case 7:
                        if (req != null)
                        {
                            Produto produto = SelecionarProduto(restaurante);
                            if (produto != null)
                            {
                                IncluirProdutoNaRequisicao(req, produto);
                            }
                            else
                            {
                                Console.WriteLine("Produto não encontrado.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Crie uma requisição antes de adicionar produtos.");
                        }
                        Pausa();
                        break;
                    case 8:
                        if (req != null)
                        {
                            FecharContaEMostrarConta(restaurante, req.Id);
                        }
                        else
                        {
                            Console.WriteLine("Crie uma requisição antes de fechar a conta.");
                        }
                        Pausa();
                        break;
                }
            } while (opcao != 0);
        }
    }
}

