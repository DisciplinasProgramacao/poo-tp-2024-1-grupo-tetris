using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.Model
{
    public class Cliente : Entidade
    {
        private string nome;

        public Cliente(string nome)
        {
            this.nome = nome;
        }

        public override string ToString()
        {
            return "Cliente nº " + Id + ": " + nome;
        }
    }
}
