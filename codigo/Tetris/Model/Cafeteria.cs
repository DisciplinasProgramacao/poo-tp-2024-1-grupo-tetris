using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.Model
{
    internal class Cafeteria : Estabelecimento
    {
        List<Requisicao> requisicoesAtuais;
        public Cafeteria() 
        {
            requisicoesAtuais = new List<Requisicao>();
            cardapio = new CardapioCafeteria();
            
        }

        public override Requisicao CriarRequisicao(Cliente cliente, int quantidade)
        {
            Requisicao tmp = new Requisicao(cliente, quantidade);
            requisicoesAtuais.Add(tmp);
            return tmp;
        }

        public override double FecharConta(string nome)
        {
            Requisicao tmp = buscaRequisicao(nome);
            requisicoesAtuais.Remove(tmp);
            Console.WriteLine(tmp.ToString());
            return tmp.fecharConta();

        }

        protected override Requisicao buscaRequisicao(string nome)
        {
            Requisicao? requisicao = requisicoesAtuais.FirstOrDefault(x => x.GetCliente().GetNome() == nome);

            if (requisicao != null)
                return requisicao;
            else
                throw new NullReferenceException();
        }
        
        public override Produto incluirProduto(int idProduto, string nome)
        {
            Produto produto = cardapio.BuscarProduto(idProduto);
            Requisicao comanda = buscaRequisicao(nome);
            if (comanda != null && produto != null)
            {
                comanda.ReceberProduto(produto);
                return produto;
            }
            else
            {
                throw new NullReferenceException();
            }
        }

        public override Pedido BuscarPedidos(Cliente cliente)
        {
            Pedido? pedido = requisicoesAtuais.FirstOrDefault(x => x.GetCliente() == cliente)?.GetPedido();
            
            if (pedido == null)
            {
                throw new NullReferenceException();
            }
            else
                return pedido;
        }

        public override bool TemRequisicao(Cliente cliente)
        {
            foreach (Requisicao requisicao in requisicoesAtuais)
            {
                if (requisicao.GetCliente() == cliente)
                {
                    return true;
                }
            }
            
            return false;
        }
    }
}
