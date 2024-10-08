using estoque.Interfaces;

namespace estoque;

public class PrecoNormal : IEstrategiaPrecificacao
{
    public decimal CalcularPreco(decimal precoBase)
    {
        return precoBase;
    }
}