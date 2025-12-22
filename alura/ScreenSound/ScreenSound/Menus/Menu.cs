using ScreenSound.Modelos;
using System.ComponentModel.Design;

namespace ScreenSound.Menus;
internal class Menu // classe pai
{
    public void ExibirTituloDaOpcao(string titulo)
    {
        int quantidadeDeLetras = titulo.Length;
        string asteriscos = string.Empty.PadLeft(quantidadeDeLetras, '*');
        Console.WriteLine(asteriscos);
        Console.WriteLine(titulo);
        Console.WriteLine(asteriscos + "\n");
    }

    // virtual indica que o método pode ser sobrescrito
    public virtual void Executar(Dictionary<string, Banda> bandasRegistradas)
    {
        Console.Clear();
    }

    public virtual void Sair()
    {
        Console.WriteLine("Tchau Tchau");
        Thread.Sleep(2000);
    }
}
