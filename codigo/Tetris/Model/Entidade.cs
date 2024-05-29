﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.Model
{
    public abstract class Entidade
    {
        private static Dictionary<Type, int> _proximosIds = new Dictionary<Type, int>();

        public int Id { get; private set; }

        protected Entidade()
        {
            Id = GerarId();
        }

        private int GerarId()
        {
            var tipo = GetType();
            if (!_proximosIds.ContainsKey(tipo))
            {
                _proximosIds[tipo] = 1;
            }

            int idAtual = _proximosIds[tipo];
            _proximosIds[tipo]++;
            return idAtual;
        }
    }
}