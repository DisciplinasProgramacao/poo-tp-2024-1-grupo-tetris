using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.Model
{
    public class Produto : Entidade
    {
        private string descricao;
        public double valor { get; private set; }
        private int quantidade;

        // Construtor da classe Produto
        public Produto(string descricao, double valor, int quantidadeDisponivel)
        {
            this.descricao = descricao;
            this.valor = valor;
            this.quantidade = quantidadeDisponivel;
        }
    }
}


