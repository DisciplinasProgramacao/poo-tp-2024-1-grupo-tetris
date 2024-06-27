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
        
        // Construtor da classe Cliente que inicializa o nome do cliente
        public Cliente(string nome)
        {
            this.nome = nome;
        }
         // Método público para obter o nome do cliente
        public string GetNome()
        {
            return nome;
        }
        // Método sobrescrito da classe Object para retornar uma representação em string do cliente
        public override string ToString()
        {
            return "\n Cliente nº " + Id + ": " + nome;
        }
    }
}
