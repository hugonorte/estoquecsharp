namespace estoque;

public class Carrinho
{
    private List<(Produto Produto, int Quantidade)> _itens = new List<(Produto, int)>();

    public void AdicionarItem(Produto produto, int quantidade)
    {
        _itens.Add((produto, quantidade));
    }

    public void RemoverItem(Produto produto, int quantidade)
    {
        var item = _itens.FirstOrDefault(i => i.Produto == produto);
        if (item.Produto != null)
        {
            if (item.Quantidade <= quantidade)
            {
                _itens.Remove(item);
            }
            else
            {
                _itens[_itens.IndexOf(item)] = (item.Produto, item.Quantidade - quantidade);
            }
        }
    }
}