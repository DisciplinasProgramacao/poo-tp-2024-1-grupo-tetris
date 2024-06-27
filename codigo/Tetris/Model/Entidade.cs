using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.Model
{
    public abstract class Entidade
    {
        private static Dictionary<Type, int> _proximosIds = new Dictionary<Type, int>();

        protected int Id;
        // Construtor protegido da classe Entidade
        protected Entidade()
        {
            Id = GerarId();
        }
        // Método privado para gerar um ID único para a instância
        private int GerarId()
        {
            Type tipo = GetType();
            if (!_proximosIds.ContainsKey(tipo))
            {
                _proximosIds[tipo] = 1;
            }

            int idAtual = _proximosIds[tipo];
            _proximosIds[tipo]++;
            return idAtual;
        }
        // Método virtual para obter o ID da instância
        public virtual int GetId()
        {
            return Id;
        }
    }
}
