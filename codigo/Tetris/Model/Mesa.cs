using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Tetris.Model
{
    public class Mesa : Entidade
    {
        /// <summary>
        /// Atributos referentes a capacidade de pessoas que cabem em uma mesa
        /// e se a mesa se encontra ocupada ou disponível.
        /// </summary>

        private int capacidade;
        public bool IsOcupada {  get; private set; }

        /// <summary>
        /// Construtor da classe Mesa, inicializando a capacidade e o estado de ocupação.
        /// </summary>
        /// <param name="capacidade">Capacidade de pessoas que a mesa pode acomodar</param>
        public Mesa(int capacidade)
        {
            this.capacidade = capacidade;
            this.IsOcupada = false;
        }

        /// <summary>
        /// Método que liberarMesa é responsável por verificar se determinada mesa está disponível.
        /// </summary>
        /// <returns> Retorna false caso a mesa esteja disponível.</returns>
        public bool LiberarMesa()
        {
            IsOcupada = true;
            if (!IsOcupada)
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// Método que ocuparMesa é responsável por verificar se determinada mesa está ocupada.
        /// </summary>
        /// <returns>Retorna true caso a mesa esteja ocupada.</returns>
        public void OcuparMesa()
        {
            IsOcupada = true;
        }
        /// <summary>
        /// Método verificarDisponibilidade é responsável por verificar se existem mesas disponíveis compatíveis
        /// com a capacidade de pessoas solicitadas.
        /// </summary>
        /// <param name="qtdPessoas"> Capacidade de pessoas referente ao tamanho da mesa </param>
        /// <returns> Retorna true caso exista alguma mesa disponível e false caso não tenha </returns>
        public bool VerificarDisponibilidade(int qtdPessoas)
        {
            if (!IsOcupada && qtdPessoas <= capacidade)
            {
                return true;
            }

            return false;
        }
    }
}
    