namespace MeuSiteEmMVC.Models;

public class Botao
{
    private int _count = 0;

    public Botao(){}
    public Botao(int count)
    {
        _count = count;
    }

    public void Add()
    {
        _count++;
    }

    public void Sub()
    {
        if (_count > 0) _count--;
    }

    public int Total => _count;

}
