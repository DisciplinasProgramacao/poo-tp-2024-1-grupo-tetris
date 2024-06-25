using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.Model
{
    public class Pedido : Entidade
    {
        private List<Produto> Itens;
        private bool StatusPedidoAberto = false;
        private const double TX_SERVICO = 0.10;

        public Pedido()
        {
            Itens = new List<Produto>();
        }

        public List<Produto> GetPedido()
        {
            Console.WriteLine("Valor atual do pedido "+CalcularValorTotal());
            return Itens;
        }

        public void AdicionarItem(Produto novo)
        {
            Itens.Add(novo);
        }

        public void GerarPedido(Produto produto)
        {
            StatusPedidoAberto = true;
        }

        public double CalcularValorTotal()
        {
            double valorTotal = 0;
            foreach(var item in this.Itens)
            {
                valorTotal += item.valor;
            }

            return valorTotal;
        }

        public double CalcularDivisaoValor(int quantidadeDivisões)
        {
            return CalcularValorTotal() / quantidadeDivisões;
        }

        public void FecharPedido()
        {
            StatusPedidoAberto = false;
        }

        public override string ToString()
        {
            string tmp ="";
            foreach(var item in this.Itens)
            {
                tmp+= item.ToString()+"\n ";
            }
            return tmp;
        }
    }
}
