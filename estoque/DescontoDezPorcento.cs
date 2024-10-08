using estoque.Interfaces;

namespace estoque;

public class DescontoDezPorcento : IEstrategiaPrecificacao
{
    public decimal CalcularPreco(decimal precoBase)
    {
        return precoBase * 0.9m;
    }
}