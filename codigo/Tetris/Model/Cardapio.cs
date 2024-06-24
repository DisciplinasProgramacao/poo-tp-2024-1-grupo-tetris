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
        protected Dictionary<int, Produto> itens;

        public Cardapio()
        {
            itens = new Dictionary<int, Produto>();
        }

        /// <summary>
        /// Inicializa o cardápio com alguns produtos.
        /// </summary>
        public abstract void InicializarCardapio();

        /// <summary>
        /// Busca um produto pelo id no cardápio e retorna seus dados.
        /// </summary>
        /// <param name="idProduto">ID do produto a ser buscado.</param>
        /// <returns>Produto encontrado ou null se não encontrado.</returns>
        public virtual Produto BuscarProduto(int idProduto)
        {
            if (itens.ContainsKey(idProduto))
            {
                return itens[idProduto];
            }
            return null; // Produto não encontrado
        }



         /// <summary>
        /// Concatena todos os produtos para ser exibido
        /// </summary>
        /// <returns>To String para impressão.</returns>
        public virtual string apresentarCardapio()
        {
            StringBuilder cardapio = new StringBuilder();
            cardapio.AppendLine("----- Cardápio -----");
            foreach (var item in itens.Values) 
            {
                cardapio.AppendLine(item.GetId() + " - " + item.ToString());
            }

            return cardapio.ToString();
        }
    }

  

}
