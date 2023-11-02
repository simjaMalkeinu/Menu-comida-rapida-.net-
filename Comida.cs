using System;
public class Comida
{
    public string Nombre
    {
        set;
        get;
    }

    public double Precio
    {
        set;
        get;
    }

    public Comida()
    {

    }

    public Comida(string nombre, double precio)
    {
        Nombre = nombre;
        Precio = precio;
    }

    public override string ToString()
    {
        return string.Format("{0:C2} {1}", Precio, Nombre);

    }
}