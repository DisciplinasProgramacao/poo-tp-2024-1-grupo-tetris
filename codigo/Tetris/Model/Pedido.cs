using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.Model
{
    public class Pedido : Entidade
    {
        private int idPedido;
        private List<Produto> pedidos;
        private const double TX_SERVICO = 0.10;

        public Pedido()
        {
            pedidos = new List<Produto>();
        }

        public void AdicionarItem(Produto novo)
        {
            pedidos.Add(novo);
        }

        public void GerarPedido()
        {

        }

        public void CalcularValorTotal()
        {

        }

        public void CalcularDivisaoValor()
        {

        }

        public void FecharPedido()
        {

        }
    }
}
