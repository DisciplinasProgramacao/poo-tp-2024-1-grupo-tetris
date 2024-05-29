﻿using Tetris.Model;

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
            Console.WriteLine("3 - ");
            Console.WriteLine("4 - ");
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
            qtdPessoas = Convert.ToInt32(Console.ReadLine());

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
            Requisicao novaRequisicao = new Requisicao();

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

        public static void alocarRequisicao()
        {

        }

        public static void finalizarRequisicao()
        {

        }

        public static Requisicao atualizarFila()
        {

        }

        public static void Main(string[] args)
        {
            Cliente = new Cliente();
            int opcao;

            Cliente clienteAtual;

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

                        break;
                    case 4:

                        break;
                }
            } while (opcao != 0);

        }
    }
}