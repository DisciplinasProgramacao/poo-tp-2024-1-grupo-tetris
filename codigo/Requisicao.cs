using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoPratico
{
    public class Requisicao
    {
        private int idRequisicao;
        private int qtdPessoas;
        private int mesasOcupadas;
        private DateTime entradaCliente;
        private Datetime saidaCliente;


        /// <summary>
        /// Gerencia as entras, se entrar cliente ele soma na variavel de mesas 
        /// </summary>
        /// <returns>True para mesa disponivel</returns>
        public bool gerenciarEntrada(int maxMesas)
        {
            if (mesasOcupadas < maxMesas)
            {
                mesasOcupadas++;
                entradaCliente = DateTime.Now; 
                return true; 
            }
            else
            {
                return false; 
            }
        }

        /// <summary>
        /// Método para gerenciar Saida do restaurante. 
        /// </summary>
        public void gerenciarSaida()
        {
            if (mesasOcupadas > 0)
            {
                mesasOcupadas--; // Decrementa o número de mesas ocupadas
                return true; // Cliente saiu com sucesso
            }
            else
            {
                return false; // Não há clientes para sair
            }
        }
    }



}