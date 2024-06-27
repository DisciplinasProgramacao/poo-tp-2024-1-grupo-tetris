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
    internal class Restaurante : Estabelecimento
    {
        private const int MAX_MESAS = 10;
        private List<Requisicao> listaEspera; 
        private List<Requisicao> requisicoesAtuais;
        private List<Mesa> mesas;  
         
        
        

        /// <summary>
        /// Construtor da classe Restaurante.
        /// Inicializa as estruturas de dados.
        /// </summary>
        public Restaurante() 
        {
            listaEspera = new List<Requisicao>();
            mesas = new List<Mesa>();
            requisicoesAtuais = new List<Requisicao>();

            for(int i = 1; i < MAX_MESAS+1; i++) 
            {
                if (i <=4)
                    mesas.Add(new Mesa(4));
                else if (i >= 5 && i <=8)
                    mesas.Add(new Mesa(6));
                else 
                    mesas.Add(new Mesa(8));
            }

            cardapio = new CardapioRestaurante();
        }

        
        /// <summary>
        /// Adiciona uma requisição de mesa à fila de espera.
        /// </summary>
        /// <param name="cliente">Cliente que solicitou a mesa.</param>
        /// <param name="qtdPessoas">Quantidade de pessoas para a mesa.</param>
        public override Requisicao CriarRequisicao(Cliente cliente, int qtdPessoas)
        {
            Requisicao requisicao = new Requisicao(cliente, qtdPessoas);
            listaEspera.Add(requisicao);
            RodarFila();
            
            return requisicao;
        }



        /// <summary>
        /// Verifica se há requisições na fila de espera e aloca uma mesa se disponível.
        /// </summary>
        private void RodarFila()
        {
            List<Requisicao> atendidas = new List<Requisicao>();
            if(listaEspera.Any())
            {
                foreach (Requisicao tmpRequisicao in listaEspera)
                {
                    Mesa tmp = procurarMesaDisponivel(tmpRequisicao.GetQtdPessoas());
                    if (tmp != null)
                    {
                        requisicoesAtuais.Add(tmpRequisicao);
                        tmpRequisicao.AlocarMesa(tmp);
                        atendidas.Add(tmpRequisicao);
                        
                    }

                }
            }

            foreach(Requisicao tmpRequisicao in atendidas)
            {
                listaEspera.Remove(tmpRequisicao);
            }
            
        }

        /// <summary>
        /// Procura por uma mesa disponível que atenda à capacidade necessária.
        /// </summary>
        /// <param name="qtdPessoas">Quantidade de pessoas para a mesa.</param>
        /// <returns>Mesa disponível encontrada ou null se não houver.</returns>
        private Mesa procurarMesaDisponivel(int qtdPessoas)
        {
            foreach (Mesa mesa in mesas)
            {
                if (mesa.VerificarDisponibilidade(qtdPessoas) == true)
                {
                    mesa.OcuparMesa();
                    return mesa;
                }
            }
            return null;
        }
        /// <summary>
        /// Fecha a conta de um cliente especificado pelo nome.
        /// </summary>
        /// <param name="nome">Nome do cliente.</param>
        /// <returns>O valor total da conta fechada.</returns>
        
        public override double FecharConta(string nome)
        {
            Requisicao requisicao = null;

            requisicao = requisicoesAtuais.FirstOrDefault(x => x.GetCliente().GetNome() == nome);

            if (requisicao != null)
            {
                FecharRequisicao(requisicao);
                Console.WriteLine(requisicao.ToString());
                requisicao.GetMesa().LiberarMesa();
                RodarFila();
                return requisicao.fecharConta();
            }
            else
                throw new NullReferenceException();
        }
        /// <summary>
        /// Fecha a requisição, removendo a requisição da lista de Requisicoes sendo atendidas no momento e gera o horario de saída da requisiçao.
        /// </summary>
        /// <param name="idRequisicao">ID da requisição a ser fechada.</param>
        /// <returns>1 se a requisição foi fechada com sucesso, -1 se não.</returns>
        private Requisicao FecharRequisicao(Requisicao requisicao)
        {
            requisicao.EncerrarRequisicao();
            requisicoesAtuais.Remove(requisicao);
            return requisicao;
        }
        /// <summary>
        /// Remove uma requisição da lista de espera com base no ID da requisição.
        /// </summary>
        /// <param name="idRequisicao">ID da requisição a ser removida.</param>
        /// <returns>A requisição removida.</returns>
        public Requisicao RemoverListaEspera(int idRequisicao)
        {
            Requisicao requisicao = listaEspera.FirstOrDefault(x => x.GetId() == idRequisicao);

            if (requisicao != null)
            {
                listaEspera.Remove(requisicao);
                return requisicao;
            }
            else
                throw new NullReferenceException();
        }

        /// <summary>
        /// Busca uma requisição associada ao cliente pelo nome.
        /// </summary>
        /// <param name="nome">Nome do cliente.</param>
        /// <returns>A requisição encontrada.</returns>
        protected override Requisicao buscaRequisicao(string nome)
        {
            Requisicao requisicao = requisicoesAtuais.FirstOrDefault(x => x.GetCliente().GetNome() == nome);

            if(requisicao == null)
            {
                foreach(Requisicao tmpRequisicao in listaEspera)
                {
                    if (tmpRequisicao.GetCliente().GetNome() == nome)
                    {
                        requisicao = tmpRequisicao;
                    }
                }
            }
            
            if (requisicao != null)
                return requisicao;
            else
                throw new NullReferenceException();
        }

        /// <summary>
        /// Inclui um produto na requisição associada ao cliente pelo nome.
        /// </summary>
        /// <param name="idProduto">ID do produto a ser incluído.</param>
        /// <param name="nome">Nome do cliente.</param>
        /// <returns>O produto incluído na requisição.</returns>

        public override Produto incluirProduto(int idProduto, string nome)
        {
            Produto produto = cardapio.BuscarProduto(idProduto);
            Requisicao requisicao = buscaRequisicao(nome);
            if (requisicao != null)
            {
                requisicao.ReceberProduto(produto);
                return produto;
            }
            else
            {
                throw new NullReferenceException();
            }
        }

        /// <summary>
        /// Busca os pedidos associados ao cliente.
        /// </summary>
        /// <param name="cliente">Cliente cujo pedido será buscado.</param>
        /// <returns>O pedido encontrado.</returns>
        public override Pedido BuscarPedidos(Cliente cliente)
        {
            var pedido = requisicoesAtuais.FirstOrDefault(x => x.GetCliente() == cliente)?.GetPedido();
            if (pedido == null)
            {
                pedido = listaEspera.FirstOrDefault(x => x.GetCliente() == cliente)?.GetPedido();
            }
            if (pedido == null)
            {
                throw new NullReferenceException();
            }
            else
                return pedido;
        }

        /// <summary>
        /// Retorna uma representação em string do estado atual do restaurante.
        /// </summary>
        /// <returns>String com informações das mesas, requisições atuais e lista de espera.</returns>

        public override string ToString()
        {
            string mesa = "";
            
            foreach(Mesa tmpMesa in mesas)
            {
                mesa+=tmpMesa.ToString();
            }

            string listasAtuais = "";

            foreach (Requisicao tmpRequisicao in requisicoesAtuais)
            {
                listasAtuais += tmpRequisicao.ToString();
            }


            string listasEspera = "";
            foreach(Requisicao tmpRequisicao in listaEspera)
            {
                listasEspera+=tmpRequisicao.ToString();
            }

            
            string final = "\n" + mesa + "\n" + listasAtuais + "\n" + listasEspera;
            return final;
        }

        public override bool TemRequisicao(Cliente cliente)
        {
            foreach(Requisicao requisicao in requisicoesAtuais)
            {
                if(requisicao.GetCliente() == cliente)
                {
                    return true;
                }
            }
            foreach (Requisicao requisicao in listaEspera)
            {
                if (requisicao.GetCliente() == cliente)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
