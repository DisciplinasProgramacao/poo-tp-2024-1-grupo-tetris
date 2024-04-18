using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Requisicao
{
    class Program
    {
        private int idRequisicao;
        private int qtdPessoas;
        private int mesasocupadas;
        private dateTime entradacliente;
        private Datetime saidacliente;


        /// <summary>
        /// Gerencia as entras, se entrar cliente ele soma na variavel de mesas 
        /// </summary>
        /// <returns>True para mesa disponivel</returns>
        public bool GerenciasEntrada(maxMesas)
        {
            if (mesasocupadas < maxMesas)
            {
                mesasocupadas++;
                entradacliente = DateTime.Now; 
                return true; 
            }
            else
            {
                return false; 
            }
        }

        /// <summary>
        /// Método para gerencias Saida do restaurante. 
        /// </summary>
        public void GerenciarSaida()
        {
            if (Mesas_ocupadas > 0)
            {
                Mesas_ocupadas--; // Decrementa o número de mesas ocupadas
                return true; // Cliente saiu com sucesso
            }
            else
            {
                return false; // Não há clientes para sair
            }
        }
    }



}