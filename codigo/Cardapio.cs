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

        public Cardapio()
        {
            itens = new List<Produto>();
        }

        public string apresentarCardapio()
        {
            foreach (Produto item in itens) 
            {
                minhaString += (idProduto) + " - " + item.ToString();
                return minhaString;
            }
        }
    }
}
