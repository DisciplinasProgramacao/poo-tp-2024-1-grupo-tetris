﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.Model
{
    internal abstract class Estabelecimento : Entidade
    {
        protected Cardapio cardapio;

        

        public virtual void ApresentarCardapio()
        {
            cardapio.apresentarCardapio();
        }

        public virtual Produto BuscarProduto(int idProduto)
        {
            return cardapio.BuscarProduto(idProduto);
        }
        
    }
}