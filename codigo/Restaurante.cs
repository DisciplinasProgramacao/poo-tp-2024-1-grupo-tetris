using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoPratico
{
    internal class Restaurante
    {
        /// <summary>
        /// Classe que representa um restaurante.
        /// </summary>
        public class Restaurante
        {
            private List<Cliente> clientes;            // Lista de clientes do restaurante
            private Queue<Requisicao> filaEspera;      // Fila de espera para as requisições de mesa
            private Dictionary<int, Mesa> mesas;       // Dicionário de mesas, onde a chave é o ID da mesa
            private const int MAX_MESAS = 10;          // Número máximo de mesas no restaurante

            /// <summary>
            /// Construtor da classe Restaurante.
            /// Inicializa as estruturas de dados.
            /// </summary>
            public Restaurante()
            {
                clientes = new List<Cliente>();
                filaEspera = new Queue<Requisicao>();
                mesas = new Dictionary<int, Mesa>();
            }

            /// <summary>
            /// Adiciona um cliente à lista de clientes do restaurante.
            /// </summary>
            /// <param name="cliente">Cliente a ser adicionado.</param>
            public void AdicionarCliente(Cliente cliente)
            {
                clientes.Add(cliente);
            }

            /// <summary>
            /// Adiciona uma requisição de mesa à fila de espera.
            /// </summary>
            /// <param name="cliente">Cliente que solicitou a mesa.</param>
            /// <param name="qtdPessoas">Quantidade de pessoas para a mesa.</param>
            public void SolicitarMesa(Cliente cliente, int qtdPessoas)
            {
                Requisicao requisicao = CriarRequisicao(cliente, qtdPessoas);
                filaEspera.Enqueue(requisicao);
                InserirFila();
            }

            /// <summary>
            /// Cria uma nova requisição de mesa com um ID aleatório.
            /// </summary>
            /// <param name="cliente">Cliente que solicitou a mesa.</param>
            /// <param name="qtdPessoas">Quantidade de pessoas para a mesa.</param>
            /// <returns>Objeto Requisicao criado.</returns>
            public Requisicao CriarRequisicao(Cliente cliente, int qtdPessoas)
            {
                int idRequisicao = new Random().Next();
                return new Requisicao(idRequisicao, cliente, qtdPessoas);
            }

            /// <summary>
            /// Verifica se há requisições na fila de espera e aloca uma mesa se disponível.
            /// </summary>
            public void InserirFila()
            {
                if (filaEspera.Count > 0)
                {
                    Requisicao proxRequisicao = filaEspera.Peek();
                    Mesa mesaDisponivel = ProcurarMesaDisponivel(proxRequisicao.QtdPessoas);
                    if (mesaDisponivel != null)
                    {
                        filaEspera.Dequeue(); // Remove da fila de espera
                        AlocarMesa(mesaDisponivel);
                    }
                    else
                    {
                        Console.WriteLine("Não há mesas disponíveis no momento.");
                    }
                }
            }

            /// <summary>
            /// Procura por uma mesa disponível que atenda à capacidade necessária.
            /// </summary>
            /// <param name="qtdPessoas">Quantidade de pessoas para a mesa.</param>
            /// <returns>Mesa disponível encontrada ou null se não houver.</returns>
            private Mesa ProcurarMesaDisponivel(int qtdPessoas)
            {
                foreach (var mesa in mesas.Values)
                {
                    if (!mesa.Ocupada && mesa.Capacidade >= qtdPessoas)
                    {
                        return mesa;
                    }
                }
                return null;
            }

            /// <summary>
            /// Aloca uma mesa para o cliente.
            /// </summary>
            /// <param name="mesa">Mesa a ser alocada.</param>
            public void AlocarMesa(Mesa mesa)
            {
                if (mesas.Count < MAX_MESAS)
                {
                    mesas.Add(mesa.Id, mesa);
                    mesa.Ocupada = true;
                    Console.WriteLine($"Mesa {mesa.Id} alocada para o cliente.");
                }
                else
                {
                    Console.WriteLine("Todas as mesas estão ocupadas no momento.");
                }
            }

            /// <summary>
            /// Fecha a requisição, liberando a mesa associada.
            /// </summary>
            /// <param name="idRequisicao">ID da requisição a ser fechada.</param>
            /// <returns>1 se a requisição foi fechada com sucesso, -1 se não.</returns>
            public int FecharRequisicao(int idRequisicao)
            {
                if (mesas.Count > 0)
                {
                    foreach (var mesa in mesas.Values)
                    {
                        if (mesa.Ocupada)
                        {
                            mesa.Ocupada = false; // Libera a mesa
                            Console.WriteLine($"Requisição com ID {idRequisicao} fechada com sucesso.");
                            return 1; // Requisição fechada com sucesso
                        }
                    }
                    Console.WriteLine($"Não há mesas alocadas para fechar a requisição com ID {idRequisicao}.");
                    return -1; // Não há mesas alocadas para a requisição
                }
                else
                {
                    Console.WriteLine($"Não há mesas alocadas para fechar a requisição com ID {idRequisicao}.");
                    return -1; // Não há mesas alocadas para a requisição
                }
            }

            /// <summary>
            /// Adiciona uma nova mesa ao restaurante.
            /// </summary>
            /// <param name="mesa">Mesa a ser adicionada.</param>
            public void AdicionarMesa(Mesa mesa)
            {
                if (!mesas.ContainsKey(mesa.Id))
                {
                    mesas.Add(mesa.Id, mesa);
                }
                else
                {
                    Console.WriteLine($"Mesa com ID {mesa.Id} já existe no restaurante.");
                }
            }
        }

    }
}
