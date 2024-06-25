﻿using System;
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
            comidas = new Dictionary<int, Produto>();
            bebidas = new Dictionary<int, Produto>();
            InicializarCardapio();
        }
        protected override void InicializarCardapio()
        {
            var comida = new (string Nome, double Valor)[]
            {
                ("Cheesecake de frutas vermelhas", 15.00),
                ("Bolinha de cogumelo", 7.00),
                ("Não de queijo", 5.00),
                ("Biscoito amanteigado", 3.00),
                ("Rissole de palmito", 7.00),
                ("Coxinha de carne de jaca", 8.00),
                ("Fatia de queijo de caju", 9.00)

            };

            var bebida = new (string Nome, double Valor)[]
            {
                ("Agua", 3.00),
                ("Copo de suco", 7.00),
                ("Café expresso organico", 6.00)

            };

            foreach (var (nome, valor) in comida)
            {
                Produto produto = new Produto(nome, valor);
                comidas.Add(produto.GetId(), produto);
            }

            foreach (var (nome, valor) in bebida)
            {
                Produto produto = new Produto(nome, valor);
                bebidas.Add(produto.GetId(), produto);
            }
        }
    }
}
