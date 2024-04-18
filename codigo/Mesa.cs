sing System;
using System.Reflection;
class Mesa
{
    /// <summary>
    /// Atributos referentes a capacidade de pessoas que cabem em uma mesa
    /// e se a mesa se encontra ocupada ou disponível.
    /// </summary>
    int capacidade; 
    bool isOcupada;

    /// <summary>
    /// Método que liberarMesa é responsável por verificar se determinada mesa está ocupada ou não.
    /// Emitindo no sistema uma mensagem infomando o status da disponibilidade. 
    /// </summary>
    /// <returns> Retorna false caso a mesa NÃO esteja ocupada e true se estiver ocupada</returns>
    public bool liberarMesa()
    {
        isOcupada = true;
        if(!isOcupada){
            Console.WriteLine("Mesa Disponível!");
            return false;
        }
        else{
            Console.WriteLine("Mesa Ocupada!");
            return true;
        }
    }

    /// <summary>
    /// Método verificarDisponibilidade é responsável por verificar se existem mesas disponíveis compatíveis
    /// com a capacidade de pessoas solicitadas.
    /// </summary>
    /// <param name="qtdPessoas"> Capacidade de pessoas referente ao tamanho da mesa </param>
    /// <returns> Retorna true caso exista alguma mesa disponível e false caso não tenha </returns>
    public bool verificarDisponibilidade(int qtdPessoas)
    {
        if(!isOcupada && qtdPessoas <= capacidade){
            Console.WriteLine("Mesa Disponível!");
            return true;
        }
        else{
            Console.WriteLine("Capacidade Insuficiente!");
            return true;
        }
    }
}