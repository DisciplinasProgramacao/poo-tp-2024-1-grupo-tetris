using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Requisicao
{
    class Program
    {
        private int idRequisicao;
        private int qtdPessoas; // Para verificar na classe Mesa se podemos alocar
        private dateTime entradaCliente;
        private Datetime saidaCliente;
 

        /// <summary>
        /// Construtor 
        /// </summary>
        /// <param name="Requisicao"> Número da Mesa </param>
        /// <param name="qtdPessoas"> Qtd de clientes por Mesa</param>
        /// <param name="entradaCliente"> Data que o cliente entrou </param>
        /// <param name="saidaCliente">Date que cliente saiu </param>
        public Requisicao(int Requisicao, int qtdPessoas, datetime entradaCliente, dateTime saidaCliente)
        {
            this.idRequisicao = Requisicao;
            this.qtdPessoas = qtdPessoas;
            this.entradaCliente = entradaCliente;
            this.saidaCliente = saidaCliente;
        }


        /// <summary>
        /// Gerenciar entrada de cliente, se entrar cliente ele chama a Clase Mesa e ocupa a Mesa IdRequisicao
        /// </summary>
        /// <param name="qtdPessoas"> Quantidade de cliente por mesa </param>
        /// <param name="mesa"> Mesa disponivel para ocupar</param>
        public void GerenciarEntrada(int qtdPessoas, Mesa mesa)
        {
            if (mesa.VerificarDisponibilidade(qtdPessoas))
            {
                // A mesa esta disponivel e pode ser alocada
                idRequisicao = mesa.Numero; // Supondo que Mesa tem uma propriedade Numero
                entradaCliente = DateTime.Now; // Registra a data e hora de entrada
                mesa.ocuparMesa();
            }
            else
            {
                // Temos que chamar a Fila de Espera, Clase Restaurante. 
                restaurante.inserirFila();
            }
        }

        /// <summary>
        /// Método para gerenciar Saida do restaurante. 
        /// </summary>
        /// <param name="numeroMesa"> Mesa que deseja desocupar </param>
        public void GerenciarSaida(int numeroMesa)
        {

            saidaCliente = DateTime.Now;

            // Liberando a mesa
            mesa.liberarMesa();
        }
        
    
    }
}



