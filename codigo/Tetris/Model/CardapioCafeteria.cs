using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.Model
{
    internal class CardapioCafeteria : Cardapio
    {
        public CardapioCafeteria()
        {
            itens = new Dictionary<int, Produto>();
            InicializarCardapio();
        }
        public override void InicializarCardapio()
        {
            var produtos = new (string Nome, double Valor)[]
            {
                ("Cheesecake de frutas vermelhas", 15.00),
                ("Bolinha de cogumelo", 7.00),
                ("Não de queijo", 5.00),
                ("Biscoito amanteigado", 3.00),
                ("Rissole de palmito", 7.00),
                ("Coxinha de carne de jaca", 8.00),
                ("Fatia de queijo de caju", 9.00)

            };

            foreach (var (nome, valor) in produtos)
            {
                Produto produto = new Produto(nome, valor);
                itens.Add(produto.GetId(), produto);
            }
        }
    }
}
