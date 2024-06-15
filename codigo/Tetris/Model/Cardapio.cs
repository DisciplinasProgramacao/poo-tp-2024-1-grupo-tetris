using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.Model
{
    public class Cardapio : Entidade
    {
        // Criando um dicionario para ajudar a pesquisar. 
        private Dictionary<int, Produto> itens;

        public Cardapio()
        {
            itens = new Dictionary<int, Produto>();
            InicializarCardapio();
        }

        /// <summary>
        /// Inicializa o cardápio com alguns produtos.
        /// </summary>
        private void InicializarCardapio()
        {
            var produtos = new (string Nome, double Valor)[]
            {
                ("Hambúrguer", 15.00),
                ("Batata Frita", 8.00),
                ("Refrigerante", 5.00)
                
            };

            foreach (var (nome, valor) in produtos)
            {
                Produto produto = new Produto(nome, valor);

                itens.Add(produto.Id, produto);
            }
        }

        /// <summary>
        /// Busca um produto pelo id no cardápio e retorna seus dados.
        /// </summary>
        /// <param name="idProduto">ID do produto a ser buscado.</param>
        /// <returns>Produto encontrado ou null se não encontrado.</returns>
        public Produto BuscarProduto(int idProduto)
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
        public string apresentarCardapio()
        {
            StringBuilder cardapio = new StringBuilder();
            cardapio.AppendLine("----- Cardápio -----");
            foreach (var item in itens.Values) 
            {
                cardapio.AppendLine(item.Id + " - " + item.ToString());
            }

            return cardapio.ToString();
        }
    }

  

}
