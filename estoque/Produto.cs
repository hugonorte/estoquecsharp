using estoque.Interfaces;

namespace estoque;

public class Produto
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public decimal PrecoBase { get; set; }
    private IEstrategiaPrecificacao _estrategiaPrecificacao;

    public void SetEstrategiaPrecificacao(IEstrategiaPrecificacao estrategia)
    {
        _estrategiaPrecificacao = estrategia;
    }

    public decimal CalcularPrecoFinal()
    {
        return _estrategiaPrecificacao.CalcularPreco(PrecoBase);
    }
}