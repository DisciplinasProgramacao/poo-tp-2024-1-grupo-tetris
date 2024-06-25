using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.Model
{
    internal class Cafeteria : Estabelecimento
    {
        List<Comanda> comandas;
        public Cafeteria() 
        {
            comandas = new List<Comanda>();
            cardapio = new CardapioCafeteria();
            
        }

        public Comanda CriarComanda(Cliente cliente)
        {
            Comanda tmp = new Comanda(cliente);
            comandas.Add(tmp);
            return tmp;
        }

        public double FecharComanda(string nome)
        {
            Comanda tmp = BuscaComanda(nome);
            comandas.Remove(tmp);
            Console.WriteLine(tmp.ToString());
            return tmp.TotalPedido();

        }

        private Comanda BuscaComanda(string nome)
        {
            foreach(Comanda tmp in comandas)
            {
                if(tmp.GetCliente().GetNome() == nome)
                {
                    return tmp;
                }
            }


            throw new NullReferenceException("Comanda inexistente");
        }
        public override Produto incluirProduto(int idProduto, string nome)
        {
            Produto produto = cardapio.BuscarProduto(idProduto);
            Comanda comanda = BuscaComanda(nome);
            if (comanda != null && produto != null)
            {
                comanda.ReceberProduto(produto);
                return produto;
            }
            else
            {
                throw new ArgumentNullException("Comanda não existente");
            }
        }

        public override Pedido BuscarPedidos(Cliente cliente)
        {
            foreach (Comanda tmp in comandas)
            {
                if (tmp.GetCliente() == cliente)
                {
                    return tmp.GetPedido();
                }
            }

            throw new ArgumentNullException("Não existe pedidos para o cliente ");
        }
    }
}
