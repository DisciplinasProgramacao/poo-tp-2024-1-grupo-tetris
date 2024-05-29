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

        public string apresentarCardapio()
        {
            StringBuilder cardapio = new StringBuilder();
            foreach (Produto item in itens) 
            {
                cardapio.AppendLine(item.IdProduto + " - " + item.ToString());
            }

            return cardapio.ToString();
        }
    }
}
