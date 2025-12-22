namespace Calculadora.Modelos;

internal class Menu : ICalculadora
{
    public virtual void Executar()
    {
        Console.Clear();
    }

    public virtual double[] PegaNumeros(bool raiz = false)
    {

        double[] numeros = new double[2];

        Console.Write("Digite o um número: ");
        numeros[0] = (double.Parse(Console.ReadLine()!));

        Console.Write("Digite o outro número: ");
        numeros[1] = (double.Parse(Console.ReadLine()!));

        return numeros;
    }

}

