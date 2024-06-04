using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoPratico
{
    public class Cliente
    {
        static int ultimoID = 0;
        private string nome;
        private int id;

        public Cliente(string nome)
        {
            this.nome = nome;
            id = ++ultimoID;
        }

        public override string ToString()
        {
            return "Cliente nº " + id + ": " + nome;
        }
    }
}
