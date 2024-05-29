using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoPratico
{
    public class Cardapio
    {
        private List<Produto> itens;

        /// <summary>
        /// Construtor da classe Cardapio.
        /// </summary>
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
        /// Mostra todos os produtos cadastrados no cardápio.
        /// </summary>
        public string apresentarCardapio()
        {
            Console.WriteLine("----- Cardápio -----");
            foreach (var produto in itens)
            {
                Console.WriteLine($"ID: {produto.IdProduto} | Descrição: {produto.Descricao} | Valor: {produto.Valor:C2}");
            }
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
                if (produto.IdProduto == idProduto)
                {
                    return produto;
                }
            }
            return null; // Produto não encontrado;
        }
        
    }
}
