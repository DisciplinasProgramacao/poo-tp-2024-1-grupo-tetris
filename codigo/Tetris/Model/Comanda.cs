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
        private Cliente cliente;
        private Pedido pedido;

        public Comanda(Cliente cliente)
        {
            this.cliente = cliente;
            pedido = new Pedido();
            
        }

        //Getters

        public Cliente GetCliente()
        {
            return cliente;
        }

        public Pedido GetPedido()
        {
            return pedido;
        }

        //Soma do pedido
        public double TotalPedido()
        {
            pedido.ToString();
            return pedido.CalcularValorTotal();
        }

        //Adicionar novo produto ao pedido
        public Produto ReceberProduto(Produto produto)
        {
            pedido.AdicionarItem(produto);
            return produto;
        }

        public override string ToString()
        {
            return "\nCliente: "+cliente.ToString() + "\n "+pedido.ToString();
        }
    }
}
