using System;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tetris.Model
{
    public class Restaurante : Entidade
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
        public void adicionarCliente(Cliente cliente)
        {
            clientes.Add(cliente);
        }

        /// <summary>
        /// Adiciona uma requisição de mesa à fila de espera.
        /// </summary>
        /// <param name="cliente">Cliente que solicitou a mesa.</param>
        /// <param name="qtdPessoas">Quantidade de pessoas para a mesa.</param>
        public void solicitarMesa(Cliente cliente, int qtdPessoas)
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
        public Requisicao criarRequisicao(Cliente cliente, int qtdPessoas)
        {
            int idRequisicao = new Random().Next();
            return new Requisicao(idRequisicao, cliente, qtdPessoas);
        }

        /// <summary>
        /// Verifica se há requisições na fila de espera e aloca uma mesa se disponível.
        /// </summary>
        public void inserirFila()
        {
            if (filaEspera.Count > 0)
            {
                Requisicao proxRequisicao = filaEspera.Peek();
                Mesa mesaDisponivel = procurarMesaDisponivel(proxRequisicao.qtdPessoas);
                if (mesaDisponivel != null)
                {
                    filaEspera.Dequeue(); // Remove da fila de espera
                    alocarMesa(mesaDisponivel);
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
        private Mesa procurarMesaDisponivel(int qtdPessoas)
        {
            foreach (var mesa in mesas.Values)
            {
                if (!mesa.VerificarDisponibilidade(qtdPessoas))
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
        public void alocarMesa(Mesa mesa)
        {
            if (mesas.Count < MAX_MESAS)
            {
                mesas.Add(mesa.id, mesa);
                mesa.ocuparMesa();
                Console.WriteLine($"Mesa {mesa.id} alocada para o cliente.");
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
        public int fecharRequisicao(int idRequisicao)
        {
            if (mesas.Count > 0)
            {
                foreach (var mesa in mesas.Values)
                {
                    if (mesa.isOcupada)
                    {
                        mesa.liberarMesa(); // Libera a mesa
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
        public void adicionarMesa(Mesa mesa)
        {
            if (!mesas.ContainsKey(mesa.id))
            {
                mesas.Add(mesa.id, mesa);
            }
            else
            {
                Console.WriteLine($"Mesa com ID {mesa.id} já existe no restaurante.");
            }
        }
        public void buscaRequisicao()
        {
            Requisicao requisicao = requisicaoOn.Find(r => r.idRequisicao == idRequisicao);
            if (requisicao == null)
            {
                Console.WriteLine("Requisição não encontrada.");
            }
            return requisicao;
        }

        public void exibirCardapio()
        {
            Console.WriteLine("----- Cardápio -----");
            System.Console.WriteLine(cardapio.apresentarCardapio());
        }

        public void incluirProdutoRequisicao(int idProduto, int idRequisicao)
        {
            Produto produto = cardapio.buscarProduto(idProduto);
            Requisicao requisicao = buscaRequisicao(idRequisicao);
            if (requisicao != null)
            {
                Pedido pedido = requisicao.Pedido;
                if (pedido != null)
                {
                    pedido.AdicionarItem(produto);
                }
            }
        }
    }
}
