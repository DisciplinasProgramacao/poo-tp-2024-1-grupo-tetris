using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.Model
{
    internal interface IPedidoRestaurante
    {
        Produto incluirProduto(int idProduto, int idRequisicao);
    }
}
