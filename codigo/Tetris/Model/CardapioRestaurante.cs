using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.Model
{

    
    internal class CardapioRestaurante : Cardapio
    {

        public CardapioRestaurante() 
        {
            itens = new Dictionary<int, Produto>();
            InicializarCardapio();

        }
        public override void InicializarCardapio()
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
                itens.Add(produto.GetId(), produto);
            }
        }

    }

    
}
