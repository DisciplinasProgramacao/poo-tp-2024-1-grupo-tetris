using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.Model
{
    public class Requisicao : Entidade
    {
        private Cliente cliente;
        private Pedido pedido;
        private int qtdPessoas;
        Mesa mesa;
        private DateTime entradaCliente;
        private DateTime saidaCliente;

        public int QtdPessoas
        {
            get { return QtdPessoas; }
        }


        //Construtor
        public Requisicao(Cliente cliente, int quantidadePessoas)
        {
            this.cliente = cliente;
            qtdPessoas = quantidadePessoas;
            entradaCliente = DateTime.Now;
            pedido = new Pedido();

        }

        //Atualização da classe Requisição para fechar a conta e exibir valor pro cliente
        public double fecharConta()
        {
            return pedido.CalcularValorTotal();
        }

        //Adição de um produto ao pedido
        public Produto ReceberProduto(Produto produto)
        {
            pedido.AdicionarItem(produto);

            return produto;
        }

        //Método para receber uma mesa após a lista de espera no Restaurante rodar
        public Mesa AlocarMesa(Mesa tmpMesa)
        {
            mesa = tmpMesa;
            return mesa;
        }

        public DateTime EncerrarRequisicao()
        {
            saidaCliente = DateTime.Now;
            return saidaCliente;
        }




    }



}
