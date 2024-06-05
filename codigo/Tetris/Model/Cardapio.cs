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
        /// Adiciona um novo produto ao cardápio.
        /// </summary>
        /// <param name="produto">Produto a ser adicionado.</param>
        public void AdicionarProduto(Produto produto)
        {
            itens.Add(produto);
        }

        /// <summary>
        /// Busca um produto pelo id no cardápio e retorna seus dados.
        /// </summary>
        /// <param name="idProduto">ID do produto a ser buscado.</param>
        /// <returns>Produto encontrado ou null se não encontrado.</returns>
        public Produto BuscarProduto(int idProduto)
        {
            foreach (var produto in itens)
            {
                if (produto.Id == idProduto)
                {
                    return produto;
                }
            }
            return null; // Produto não encontrado;
        }

        public string apresentarCardapio()
        {
            StringBuilder cardapio = new StringBuilder();
            cardapio.AppendLine("----- Cardápio -----");
            foreach (Produto item in itens) 
            {
                cardapio.AppendLine(item.IdProduto + " - " + item.ToString());
            }

            return cardapio.ToString();
        }
    }
}
