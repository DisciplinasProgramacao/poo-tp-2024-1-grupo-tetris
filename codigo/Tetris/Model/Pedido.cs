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

        // Construtor da classe Pedido
        public Pedido()
        {
            Itens = new List<Produto>();
        }
        // Método para obter a lista de itens do pedido
        public List<Produto> GetPedido()
        {
            return Itens;
        }
        // Método para adicionar um item ao pedido
        public void AdicionarItem(Produto novo)
        {
            Itens.Add(novo);
        }
        // Método para gerar um pedido (abrir o status do pedido)
        public void GerarPedido(Produto produto)
        {
            StatusPedidoAberto = true;
        }
        // Método para calcular o valor total do pedido, incluindo a taxa de serviço
        public double CalcularValorTotal() => this.Itens.Sum(x => x.valor + (x.valor * TX_SERVICO));
        // Método para calcular a divisão do valor total por uma quantidade de divisões
        public double CalcularDivisaoValor(int quantidadeDivisões)
        {
            return CalcularValorTotal() / quantidadeDivisões;
        }
        // Método para fechar o pedido (mudar o status para fechado)
        public void FecharPedido()
        {
            StatusPedidoAberto = false;
        }
        // Método sobrescrito da classe Object para retornar uma representação em string do pedido
        public override string ToString()
        {
            string tmp ="";
            foreach(Produto item in this.Itens)
            {
                tmp+= item.ToString()+"\n ";
            }
            return tmp;
        }
    }
}
