using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.Model
{

    
    internal class CardapioRestaurante : Cardapio
    {
        // Construtor da classe CardapioRestaurante
        public CardapioRestaurante() 
        {
            comidas = new Dictionary<int, Produto>();
            bebidas = new Dictionary<int, Produto>();
            InicializarCardapio();

        }
        // Método protegido sobrescrito da classe base para inicializar o cardápio
        protected override void InicializarCardapio()
        {
           
            (string, double)[] comida = new (string Nome, double Valor)[]
            {
                ("Moqueca de Palmito", 32.00),
                ("Falafel Assado", 20.00),
                ("Salada Primavera com Macarrão Konjac", 25.00),
                ("Escondidinho de Inhame", 18.00),
                ("Strogonoff de Cogumelos", 35.00),
                ("Caçarola de legumes", 22.00)

            };

            (string, double)[] bebida = new (string Nome, double Valor)[]
            {
                ("Agua", 3.00),
                ("Copo de suco", 7.00),
                ("Refrigerante Organico", 7.00),
                ("Cerveja vegana", 9.00),
                ("Taça de vinho vegano", 18.00)

            };


            foreach ((string nome, double valor) in comida)
            {
                Produto produto = new Produto(nome, valor);
                comidas.Add(produto.GetId(), produto);
            }

            foreach ((string nome, double valor) in bebida)
            {
                Produto produto = new Produto(nome, valor);
                bebidas.Add(produto.GetId(), produto);
            }

        }

    }

    
}
