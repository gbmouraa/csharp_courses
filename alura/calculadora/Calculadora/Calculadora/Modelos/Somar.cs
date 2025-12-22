namespace Calculadora.Modelos;

internal class Somar : Menu
{
    public override void Executar()
    {
        base.Executar();

        Console.WriteLine("*****");
        Console.WriteLine("Somar");
        Console.WriteLine("*****");

        var nums = base.PegaNumeros();

        Console.WriteLine($"{nums[0]} + {nums[1]} = {nums[0] + nums[1]}");
    }

}
