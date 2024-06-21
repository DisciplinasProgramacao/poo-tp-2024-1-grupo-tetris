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
    public class Restaurante : Estabelecimento
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
            foreach(var tmpRequisicao in listaEspera)
            {
                Mesa tmp = procurarMesaDisponivel(tmpRequisicao.GetQtdPessoas());
                if(tmp != null)
                {
                    requisicoesAtuais.Add(tmpRequisicao);
                    tmpRequisicao.AlocarMesa(tmp);
                    listaEspera.Remove(tmpRequisicao);
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
            foreach (var mesa in mesas)
            {
                if (mesa.VerificarDisponibilidade(qtdPessoas) == true)
                {
                    mesa.OcuparMesa();
                    return mesa;
                }
            }
            return null;
        }

        public double FecharConta(int idRequisicao)
        {
            Requisicao requisicao = null;
            foreach (var tmpRequisicao in requisicoesAtuais)
            {
                if (tmpRequisicao.GetID() == idRequisicao)
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
            foreach(var tmprequisicao in listaEspera)
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

        
        public Requisicao buscaRequisicao(int idRequisicao)
        {
            Requisicao requisicao = null;
            foreach (var tmpRequisicao in requisicoesAtuais)
            {
                if(tmpRequisicao.GetID() == idRequisicao)
                {
                    requisicao= tmpRequisicao;
                }
            }
            if(requisicao == null)
            {
                foreach(var tmpRequisicao in listaEspera)
                {
                    if (tmpRequisicao.GetID() == idRequisicao)
                    {
                        requisicao = tmpRequisicao;
                    }
                }
            }
            
            if (requisicao != null)
                return requisicao;
            else
                throw new ArgumentNullException("Requisicao não existe");
             
        }

        public void exibirCardapio()
        {
            cardapio.apresentarCardapio();
        }

        public Produto incluirProduto(int idProduto, int idRequisicao)
        {
            Produto produto = cardapio.BuscarProduto(idProduto);
            Requisicao requisicao = buscaRequisicao(idRequisicao);
            if (requisicao != null)
            {
                requisicao.ReceberProduto(produto);
                return produto;
            }
            else
            {
                throw new ArgumentNullException("Requisicao não existente");
            }
        }
    }
}
