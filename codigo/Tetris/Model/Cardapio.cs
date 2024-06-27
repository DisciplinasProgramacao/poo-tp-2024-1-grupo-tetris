using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.Model
{
    public abstract class Cardapio : Entidade
    {
        // Criando um dicionario para ajudar a pesquisar. 
        protected Dictionary<int, Produto> comidas;
        protected Dictionary<int, Produto> bebidas;

        public Cardapio()
        {
            comidas = new Dictionary<int, Produto>();
            bebidas = new Dictionary<int, Produto>();
        }

        /// <summary>
        /// Inicializa o cardápio com alguns produtos.
        /// </summary>
        protected abstract void InicializarCardapio();

        /// <summary>
        /// Busca um produto pelo id no cardápio e retorna seus dados.
        /// </summary>
        /// <param name="idProduto">ID do produto a ser buscado.</param>
        /// <returns>Produto encontrado ou null se não encontrado.</returns>
        public virtual Produto BuscarProduto(int idProduto)
        {
            if (comidas.ContainsKey(idProduto))
            {
                return comidas[idProduto];
            }

            if(bebidas.ContainsKey(idProduto))
            { 
                return bebidas[idProduto];
            }

            throw new NullReferenceException(); // Produto não encontrado
        }

        /// <summary>
        /// Concatena todos os produtos para ser exibido
        /// </summary>
        /// <returns>To String para impressão.</returns>
        public virtual void apresentarCardapio()
        {
            StringBuilder cardapio = new StringBuilder();
            cardapio.AppendLine("----- Cardápio -----");
            foreach (Produto item in comidas.Values) 
            {
                cardapio.AppendLine(item.GetId() + " - " + item.ToString());
            }

            foreach (Produto item in bebidas.Values)
            {
                cardapio.AppendLine(item.GetId() + " - " + item.ToString());
            }
            
            Console.WriteLine(cardapio);
            
        }
    }
}
