using ScreenSound.Menus;
using ScreenSound.Modelos;

Banda Slipknot = new("Slipknot");
Banda LinkinPark = new("Linkin Park");
Banda Ira = new("Ira");

Ira.AdicionarNota(new Avaliacao(5));
Ira.AdicionarNota(new Avaliacao(7));

Slipknot.AdicionarNota(new Avaliacao(8));
Slipknot.AdicionarNota(new Avaliacao(10));
Slipknot.AdicionarNota(new Avaliacao(10));

Dictionary<string, Banda> bandasRegistradas = new Dictionary<string, Banda>();
bandasRegistradas.Add(Slipknot.Nome, Slipknot);
bandasRegistradas.Add(LinkinPark.Nome, LinkinPark);
bandasRegistradas.Add(Ira.Nome, Ira); 

Dictionary<int, Menu> opcoes = new Dictionary<int, Menu>();
opcoes.Add(1, new MenuRegistrarBanda());
opcoes.Add(2, new MenuRegistrarAlbum());
opcoes.Add(3, new MenuMostrarBandasRegistradas());
opcoes.Add(4, new MenuAvaliarBanda());
opcoes.Add(5, new MenuExibirDetalhes());
opcoes.Add(6 , new MenuAvaliarAlbum()); 
opcoes.Add(-1, new MenuSair());

void ExibirLogo()
{
    Console.WriteLine(
        @"

░██████╗░█████╗░██████╗░███████╗███████╗███╗░░██╗  ░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░
██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝████╗░██║  ██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗
╚█████╗░██║░░╚═╝██████╔╝█████╗░░█████╗░░██╔██╗██║  ╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║
░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══╝░░██║╚████║  ░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║
██████╔╝╚█████╔╝██║░░██║███████╗███████╗██║░╚███║  ██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝
╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░╚══╝  ╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░
"
    );
    Console.WriteLine("Boas vindas ao Screen Sound 2.0!");
}

void ExibirOpcoesDoMenu()
{
    ExibirLogo();
    Console.WriteLine("\nDigite 1 para registrar uma banda");
    Console.WriteLine("Digite 2 para registrar o álbum de uma banda");
    Console.WriteLine("Digite 3 para mostrar todas as bandas");
    Console.WriteLine("Digite 4 para avaliar uma banda");
    Console.WriteLine("Digite 5 para exibir os detalhes de uma banda");
    Console.WriteLine("Digite 6 para avaliar um álbum");
    Console.WriteLine("Digite -1 para sair");

    Console.Write("\nDigite a sua opção: ");
    string opcaoEscolhida = Console.ReadLine()!;
    int opcaoEscolhidaNumerica = int.Parse(opcaoEscolhida);

    if (opcoes.ContainsKey(opcaoEscolhidaNumerica))
    {
        Menu menuASerExibido = opcoes[opcaoEscolhidaNumerica];
        if (opcaoEscolhidaNumerica == -1)
        {
        menuASerExibido.Sair();
        }
        else
        {
            menuASerExibido.Executar(bandasRegistradas);
        }

        if (opcaoEscolhidaNumerica > 0) ExibirOpcoesDoMenu();
    }
    else
    {
        Console.WriteLine("Opção inválida");
    }
}

ExibirOpcoesDoMenu();
