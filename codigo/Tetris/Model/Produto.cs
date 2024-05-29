using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.Model
{
    public class Produto : Entidade
    {
        private int idProduto;
        private string descricao;
        private double valor;
        private int quant;

        public int IdProduto
        {
            get { return idProduto; }
        }

        public Produto()
        {

        }
    }
}


