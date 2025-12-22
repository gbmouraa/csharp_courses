using ScreenSound.Modelos;

namespace ScreenSound.Menus;

internal class MenuAvaliarBanda : Menu
{
    // override para sobrescrever o método Executar no Menu (pai)
    public override void Executar(Dictionary<string, Banda> bandasRegistradas)
    {
        // indica que é pra executar o que está em Executar da classe Menu
        base.Executar(bandasRegistradas);
        ExibirTituloDaOpcao("Avaliar Banda");

        Console.Write("Digite o nome da banda que deseja avaliar: ");
        string nomeDaBanda = Console.ReadLine()!;

        if (bandasRegistradas.ContainsKey(nomeDaBanda))
        {
            Banda banda = bandasRegistradas[nomeDaBanda];
            Console.Write($"Qual a nota que a banda {nomeDaBanda} merece: ");

            Avaliacao nota = Avaliacao.Parse(Console.ReadLine()!); // Avaliação.Parse retorna uma Avaliacao recebendo nota
            banda.AdicionarNota(nota); // aponta para bandasRegistradas[nomeDaBanda]
            Console.WriteLine(
                $"\nA nota {nota.Nota} foi registrada com sucesso para a banda {nomeDaBanda}"
            );
            Thread.Sleep(2000);
            Console.Clear();
        }
        else
        {
            Console.WriteLine($"\nA banda {nomeDaBanda} não foi encontrada!");
            Console.WriteLine("Digite uma tecla para voltar ao menu principal");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
