using Calculadora.Modelos;

namespace Calculadora;

internal class Program
{
    static void Main(string[] args)
    {
        Dictionary<int, Menu> opcoes = new Dictionary<int, Menu>();
        opcoes.Add(1, new Somar());
        opcoes.Add(2, new Subtrair());

        void ExibirMenu()
        {
            Console.WriteLine("***********");
            Console.WriteLine("Calculadora");
            Console.WriteLine("***********");
            Console.WriteLine();

            Console.WriteLine("Digite 1 para somar");
            Console.WriteLine("Digite 2 para subtrair");

            Console.Write("Digite a opção escolhida: ");
            int opcaoEscolhida = int.Parse(Console.ReadLine()!);

            Menu menuASerExibido = opcoes[opcaoEscolhida];
            menuASerExibido.Executar();
        }

        ExibirMenu();
    }
}
