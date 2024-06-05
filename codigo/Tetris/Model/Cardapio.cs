using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.Model
{
    public class Cardapio : Entidade
    {
        private List<Produto> itens;

        public Cardapio()
        {
            itens = new List<Produto>();
        }

        /// <summary>
        /// Adiciona um novo produto ao card·pio.
        /// </summary>
        /// <param name="produto">Produto a ser adicionado.</param>
        public void adicionarProduto(Produto produto)
        {
            itens.Add(produto);
        }


        /// <summary>
        /// Busca um produto pelo id no card√°pio e retorna seus dados.
        /// </summary>
        /// <param name="idProduto">ID do produto a ser buscado.</param>
        /// <returns>Produto encontrado ou null se n√£o encontrado.</returns>
        public Produto BuscarProduto(int idProduto)
        {
            foreach (var produto in itens)
            {
                if (produto.Id == idProduto)
                {
                    return produto;
                }
            }
            return null; // Produto n„o encontrado;
        }

        public string apresentarCardapio()
        {
            StringBuilder cardapio = new StringBuilder();
            cardapio.AppendLine("----- Card·pio -----");
            foreach (Produto item in itens) 
            {
                cardapio.AppendLine(item.Id + " - " + item.ToString());
            }

            return cardapio.ToString();
        }
    }
}
