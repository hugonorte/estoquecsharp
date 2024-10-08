namespace estoque;

public class AdicionarItemCommand
{
    private Carrinho _carrinho;
    private Produto _produto;
    private int _quantidade;

    public AdicionarItemCommand(Carrinho carrinho, Produto produto, int quantidade)
    {
        _carrinho = carrinho;
        _produto = produto;
        _quantidade = quantidade;
    }

    public void Executar()
    {
        _carrinho.AdicionarItem(_produto, _quantidade);
    }

    public void Desfazer()
    {
        _carrinho.RemoverItem(_produto, _quantidade);
    }
}