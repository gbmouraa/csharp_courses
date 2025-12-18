namespace Calculadora.Modelos;

internal class Calculadora
{
    string[] opcoes = { "1 - Somar", "2 - Subtrair", "3 - Multiplicar", "4 - Dividir",
        "5 - Potenciação","6 - Raiz Quadrada", "7 - Sair" };

    public void ExibirMenu()
    {
        Console.Clear();

        Console.WriteLine("***********");
        Console.WriteLine("Calculadora");
        Console.WriteLine("***********");
        Console.WriteLine();

        foreach (string op in opcoes)
        {
            Console.WriteLine(op);
        }

        Console.WriteLine();
        Console.Write("Digite a opção escolhida: ");
        int opcaoEscolhida = int.Parse(Console.ReadLine()!);

        switch (opcaoEscolhida)
        {
            case 1:
                Somar();
                break;
            case 2:
                Subtrair();
                break;
            case 3:
                Multiplicar();
                break;
            case 4:
                Dividir();
                break;
            case 5:
                Potencia();
                break;
            case 6:
                RaizQuadrada();
                break;
            case 7:
                Console.WriteLine("Saindo...");
                Thread.Sleep(2000);
                break;
            default:
                Console.WriteLine("Opção inválida");
                break;
        }
    }

    public void Somar()
    {
        var numeros = PegaNumeros();
        double num1 = numeros[0], num2 = numeros[1];

        Console.WriteLine($"A soma de {num1} com {num2} é {num1 + num2}");
        Thread.Sleep(2000);

        ExibirMenu();
    }

    public void Subtrair()
    {
        var numeros = PegaNumeros();
        double num1 = numeros[0], num2 = numeros[1];

        Console.WriteLine($"A subtração de {num1} com {num2} é {num1 - num2}");
        Thread.Sleep(2000);

        ExibirMenu();
    }

    public void Multiplicar()
    {
        var numeros = PegaNumeros();
        double num1 = numeros[0], num2 = numeros[1];

        Console.WriteLine($"A multiplicação de {num1} com {num2} é {num1 * num2}");
        Thread.Sleep(2000);

        ExibirMenu();
    }

    public void Dividir()
    {
        var numeros = PegaNumeros();
        double num1 = numeros[0], num2 = numeros[1];

        Console.WriteLine($"A divisão de {num1} por {num2} é {num1 / num2}");
        Thread.Sleep(2000);

        ExibirMenu();
    }

    public void RaizQuadrada()
    {
        double[] num = PegaNumeros("true");

        Console.WriteLine($"A raiz de {num[0]} é {Math.Sqrt(num[0])}");
        Thread.Sleep(2000);

        ExibirMenu();
    }

    public void Potencia()
    {
        var numeros = PegaNumeros();
        double num1 = numeros[0], num2 = numeros[1];

        Console.WriteLine($"A potência de {num1} ao {num2} é {Math.Pow(num1, num2)}");
        Thread.Sleep(2000);

        ExibirMenu();
    }

    public double[] PegaNumeros(string raiz = "false")
    {
        double[] numeros = new double[2];

        Console.Write("Digite o um número: ");
        numeros[0] = (double.Parse(Console.ReadLine()!));

        if (raiz == "true") return numeros;

        Console.Write("Digite o outro número: ");
        numeros[1] = (double.Parse(Console.ReadLine()!));

        return numeros;

    }

}

