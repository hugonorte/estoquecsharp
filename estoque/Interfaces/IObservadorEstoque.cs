namespace estoque.Interfaces;

public interface IObservadorEstoque
{
    void Atualizar(int produtoId, int novaQuantidade);
}