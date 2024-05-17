using System;

public class Cliente
{
    static int ultimoID=0;
    private string nome;
    private int id;

    public Cliente(string nome)
	{
		this.nome = nome;
        id = ++ultimoID;
	}

    public override string ToString(){
        return "Cliente nº "+id+": "+nome;
    }
}
