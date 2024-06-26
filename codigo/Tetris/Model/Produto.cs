using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.Model
{
    public class Produto : Entidade
    {
        private string nome;
        public double valor { get; private set; }


        // Construtor da classe Produto, valor não pode ser menor que  0.
        public Produto(string nome, double valor)
        {
            if (valor < 0)
            {
                throw new ArgumentException(nameof(valor));
            }

            this.nome = nome;
            this.valor = valor;
            
        
        }

        // Sobrescrevendo o ToString. 
        public override string ToString()
        {
            return $"ID: {Id} | Descrição: {nome} | Valor: {valor:C2}";
        }

    }
}
