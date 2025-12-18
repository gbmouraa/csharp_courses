using Calculadora.Modelos;

namespace Calculadora;

internal class Program
{
    static void Main(string[] args)
    {
        var Calculadora = new Modelos.Calculadora();
        Calculadora.ExibirMenu();
    }
}
