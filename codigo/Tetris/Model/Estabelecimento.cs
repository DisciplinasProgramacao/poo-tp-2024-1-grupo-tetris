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

        
        // Método virtual para apresentar o cardápio do estabelecimento
        public virtual void ApresentarCardapio()
        {
            cardapio.apresentarCardapio();
        }
        // Método virtual para buscar um produto no cardápio pelo ID
        public virtual Produto BuscarProduto(int idProduto)
        {
            return cardapio.BuscarProduto(idProduto);
        }
        // Método abstrato para buscar uma requisição pelo nome do cliente
        protected abstract Requisicao buscaRequisicao(string nome);
        // Método abstrato para criar uma nova requisição para um cliente com uma quantidade especificada
        public abstract Requisicao CriarRequisicao(Cliente cliente, int quantidade);
        // Método abstrato para incluir um produto em uma requisição pelo nome do cliente
        public abstract Produto incluirProduto(int idProduto, string nome);
        // Método abstrato para buscar os pedidos de um cliente
        public abstract Pedido BuscarPedidos(Cliente cliente);
        // Método abstrato para fechar a conta de um cliente pelo nome
        public abstract double FecharConta(string nome);
        // Método abstrato para verificar se existe uma requisição de um cliente específico
        public abstract bool TemRequisicao(Cliente Cliente);


    }
}
