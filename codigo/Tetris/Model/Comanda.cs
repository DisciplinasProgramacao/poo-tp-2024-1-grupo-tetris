using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.Model
{
    internal class Comanda : Entidade
    {
        Cliente cliente;
        Pedido pedido;

        public Comanda(Cliente cliente)
        {
            this.cliente = cliente;
            
        }

        public double TotalPedido()
        {
            return pedido.CalcularValorTotal();
        }
        public Produto ReceberProduto(Produto produto)
        {
            pedido.AdicionarItem(produto);
            return produto;
        }
    }
}
