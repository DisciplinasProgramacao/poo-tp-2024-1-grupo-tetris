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
        public List<Cliente> clientes { get; private set; }            // Lista de clientes do restaurante
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

        public Cliente LocalizarCliente(int id)
        {
            foreach(var cliente in clientes)
                if(cliente.LocalizarCliente(id))
                    return cliente;
            return null;
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
        public Requisicao CriarRequisicao(Cliente cliente, int qtdPessoas)
        {
            return new Requisicao(cliente, qtdPessoas);
        }

        /// <summary>
        /// Verifica se há requisições na fila de espera e aloca uma mesa se disponível.
        /// </summary>
        public void InserirFila()
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
            }
        }

        /// <summary>
        /// Fecha a requisição, liberando a mesa associada.
        /// </summary>
        /// <param name="idRequisicao">ID da requisição a ser fechada.</param>
        /// <returns>1 se a requisição foi fechada com sucesso, -1 se não.</returns>
        public void FecharRequisicao(int idRequisicao)
        {
            foreach (var mesa in mesas.Values)
            {
                if (mesa.IsOcupada)
                {
                    mesa.LiberarMesa(); // Libera a mesa
                    break;
                }
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
        }
        public Requisicao buscaRequisicao(int idRequisicao)
        {
            Requisicao requisicao = requisicaoOn.Find(r => r.idRequisicao == idRequisicao);
            return requisicao;
        }

        public void exibirCardapio()
        {
            cardapio.apresentarCardapio();
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
