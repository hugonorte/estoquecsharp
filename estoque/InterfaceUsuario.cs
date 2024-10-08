using estoque.Interfaces;

namespace estoque;

public class InterfaceUsuario : IObservadorEstoque
{
    public void Atualizar(int produtoId, int novaQuantidade)
    {
        Console.WriteLine($"Estoque do produto {produtoId} atualizado para {novaQuantidade}");
    }
}