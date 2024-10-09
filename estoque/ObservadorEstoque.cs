using estoque.Interfaces;

namespace estoque;

public class ObservadorEstoque
{
    private List<IObservadorEstoque> _observadores = new List<IObservadorEstoque>();
    private Dictionary<int, int> _estoque = new Dictionary<int, int>();

    public void AdicionarObservador(IObservadorEstoque observador)
    {
        _observadores.Add(observador);
    }

    public void RemoverObservador(IObservadorEstoque observador)
    {
        _observadores.Remove(observador);
    }

    public void AtualizarEstoque(int produtoId, int novaQuantidade)
    {
        _estoque[produtoId] = novaQuantidade;
        NotificarObservadores(produtoId, novaQuantidade);
    }

    private void NotificarObservadores(int produtoId, int novaQuantidade)
    {
        foreach (var observador in _observadores)
        {
            observador.Atualizar(produtoId, novaQuantidade);
        }
    }
}