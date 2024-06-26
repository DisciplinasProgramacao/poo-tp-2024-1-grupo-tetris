using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.Model
{
    internal abstract class Estabelecimento : Entidade
    {
        protected Cardapio cardapio;
        List<Requisicao> requisicoesAtuais;

        

        public virtual void ApresentarCardapio()
        {
            cardapio.apresentarCardapio();
        }

        public virtual Produto BuscarProduto(int idProduto)
        {
            return cardapio.BuscarProduto(idProduto);
        }

        protected abstract Requisicao buscaRequisicao(string nome);

        public abstract Requisicao CriarRequisicao(Cliente cliente, int quantidade);

        public abstract Produto incluirProduto(int idProduto, string nome);

        public abstract Pedido BuscarPedidos(Cliente cliente);

        public abstract double FecharConta(string nome);

        public abstract bool TemRequisicao(Cliente Cliente);


    }
}
