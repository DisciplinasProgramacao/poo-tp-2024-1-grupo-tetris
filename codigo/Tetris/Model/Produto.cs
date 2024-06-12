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


        // Construtor da classe Produto, valor não pode ser menor que  0.
        public Produto(string descricao, double valor)
        {
            if (valor < 0)
            {
                throw new ArgumentException(nameof(valor), "O valor não pode ser menor que zero");
            }

            this.descricao = descricao;
            this.valor = valor;
        
        }

        // Sobrescrevendo o ToString. 
        public override string ToString()
        {
            return $"ID: {Id} | Descrição: {descricao} | Valor: {valor:C2} | Quantidade Disponível: {quantidade}";
        }

    }
}


