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
        private Mesa mesa;
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

        //Getters

        
        public int GetQtdPessoas()
        {
            return qtdPessoas;
        }

        public Pedido GetPedido() 
        {
            return pedido;
        }

        public Mesa GetMesa()
        {
            return mesa;
        }

        public Cliente GetCliente()
        {
            return cliente;
        }
        //Consultas
        public bool BuscarCliente(string nome)
        {
            if (nome == cliente.GetNome())
                return true;
            else
                return false;
        }

        //Fechar conta
        public double fecharConta()
        {
            this.ToString();
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

        public override string ToString()
        {
            return "\n Nome: " + cliente.GetNome() + " ID: " + cliente.GetId() + " total do pedido: " + pedido.CalcularValorTotal()+ " Mesa ocupada: "+mesa.GetId();
        }


    }



}
