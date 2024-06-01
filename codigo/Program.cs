using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoPratico
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

        private static Cliente cadastrarCliente()
        {
            string nome;
            int qtdPessoas;
            Cliente novo;
            cabecalho();
            Console.Write("Qual é o nome do novo cliente? ");
            nome = Console.ReadLine();
            novo = new Cliente(nome);
            clientes.adicionar(novo);

            Console.Write("Qual é a quantidade de pessoas? ");
            qtdPessoas = Console.ReadLine();

            Console.WriteLine($"\nCliente cadastrado:\n {novo.ToString()}");
            pausa();
            return novo;
        }

        private static Cliente localizarCliente()
        {
            int idCli;
            Cliente quem;
            cabecalho();
            Console.Write("Digite o id do cliente: ");
            idCli = int.Parse(Console.ReadLine());
            quem = clientes.localizar(idCli);
            return quem;

        }

        public static Requisicao criarRequisicao()
        {
            Requisicao novaRequisicao;

            if (novaRequisicao != null)
            {
                do
                {
                    addRequisicao(novaRequisicao);
                    Console.WriteLine($"\n{novaRequisicao} adicionada com sucesso.");
                    pausa();                    
                } while (novaRequisicao != null);
                
            }
            else
                novaRequisicao = null;
            
            return novaRequisicao;
        }

        public static void alocarRequisicao(Requisicao requisicao)
        {
            int alocarReq = 0;

            if (alocarReq < MAX_MESAS)
            {
                alocarRequisicao(requisicao);
                alocarReq++;
            }
            else
            {
                filaEspera.Enqueue(requisicao);
                InserirFila();
                Console.WriteLine("Todas as mesas estão ocupadas no momento. Requisição inserida na fila de espera!")
            } 

        }

        public static void finalizarRequisicao()
        {
            fecharRequisicao(idRequisicao);
            atualizarFila();
        }

        public static Requisicao atualizarFila()
        {

        }

        public static void Main(string[] args)
        {
            Cliente = new Cliente();
            Requisicao = new Requisicao();
            int opcao;

            Cliente clienteAtual;
            Requisicao novaRequisicao;

            do
            {
                opcao = MenuPrincipal();
                switch (opcao)
                {
                    case 1:
                        clienteAtual = localizarCliente();
                        if (clienteAtual == null)
                        {
                            clienteAtual = cadastrarCliente();
                        }
                        pausa();
                        break;
                    case 2:
                        clienteAtual = localizarCliente();
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
                        if (novaRequisicao != null)
                            novaRequisicao = criarRequisicao();
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
