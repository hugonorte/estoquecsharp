namespace estoque.Interfaces;

public interface ICommand
{
    void Executar();
    void Desfazer();
}