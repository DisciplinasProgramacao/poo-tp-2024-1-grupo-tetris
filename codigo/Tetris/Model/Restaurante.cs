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
        public Requisicao solicitarMesa(Cliente cliente, int qtdPessoas)
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

        
        public override double FecharConta(string nome)
        {
            Requisicao requisicao = null;
            foreach (Requisicao tmpRequisicao in requisicoesAtuais)
            {
                if (tmpRequisicao.GetCliente().GetNome() == nome)
                {
                    requisicao = tmpRequisicao;
                }
            }

            if (requisicao != null)
            {
                FecharRequisicao(requisicao);
                Console.WriteLine(requisicao.ToString());
                requisicao.GetMesa().LiberarMesa();
                RodarFila();
                return requisicao.fecharConta();
            }
            else
                throw new NullReferenceException("Requisicao inexistente.");
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

        public Requisicao RemoverListaEspera(int idRequisicao)
        {
            Requisicao requisicao = null;
            foreach(Requisicao tmprequisicao in listaEspera)
            {
                if(tmprequisicao.GetID() == idRequisicao)
                    requisicao = tmprequisicao;
            }

            if (requisicao != null)
            {
                listaEspera.Remove(requisicao);
                return requisicao;
            }
            else
                throw new NullReferenceException("Requisicao inexistente");
        }

        
        public Requisicao buscaRequisicao(string nome)
        {
            Requisicao requisicao = null;
            foreach (Requisicao tmpRequisicao in requisicoesAtuais)
            {
                if(tmpRequisicao.GetCliente().GetNome() == nome)
                {
                    requisicao= tmpRequisicao;
                }
            }
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
                throw new NullReferenceException("Requisicao não existe");
             
        }



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
                throw new NullReferenceException("Requisicao não existente");
            }
        }

        public override Pedido BuscarPedidos(Cliente cliente)
        {
            foreach(Requisicao tmp in requisicoesAtuais)
            {
                if(tmp.GetCliente() == cliente) 
                {
                    return tmp.GetPedido();
                }
            }

            foreach (Requisicao tmp in listaEspera)
            {
                if (tmp.GetCliente() == cliente)
                {
                    return tmp.GetPedido();
                }
            }

            throw new NullReferenceException("Não existe pedidos para o cliente ");
        }

        public override string ToString()
        {
            string mesa = "";
            
            foreach(Mesa tmpMesa in mesas)
            {
                mesa+=tmpMesa.ToString();
            }
            string listasEspera = "";
            foreach(Requisicao tmpRequisicao in listaEspera)
            {
                listasEspera+=tmpRequisicao.ToString();
            }

            string listasAtuais = "";

            foreach (Requisicao tmpRequisicao in listaEspera)
            {
                listasAtuais += tmpRequisicao.ToString();
            }

            string final = "\n" + mesa + "\n" + listasAtuais + "\n" + listasEspera;
            return final;
        }
    }
}
