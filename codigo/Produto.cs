using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoPratico
{
    public class Produto
    {
        private int idProduto;
        private string descricao;
        private double valor;
        private int quant;

        // Construtor da classe Produto
        public Produto(int idProduto, string descricao, double valor, int quantidadeDisponivel)
        {
            IdProduto = idProduto;
            Descricao = descricao;
            Valor = valor;
            QuantidadeDisponivel = quantidadeDisponivel;
        }

        //Sobrescreve o ToString levando todos os dados do produto.
        public override string ToString()
        {
            return $"ID: {IdProduto} | Descrição: {Descricao} | Valor: {Valor:C2} | Quantidade Disponível: {QuantidadeDisponivel}";
        }
    }
}

