namespace estoque;

public class EstoqueManager
{
    private static EstoqueManager _instance;
    private static readonly object _lock = new object();
    private Dictionary<int, int> _estoque = new Dictionary<int, int>();

    private EstoqueManager()
    {
        // Inicialização do dicionário de estoque
        _estoque = new Dictionary<int, int>();

        // Aqui você poderia adicionar código para carregar o estoque inicial de um banco de dados ou arquivo
        CarregarEstoqueInicial();   
    }

    public static EstoqueManager GetInstance()
    {
        if (_instance == null)
        {
            lock (_lock)
            {
                if (_instance == null)
                {
                    _instance = new EstoqueManager();
                }
            }
        }
        return _instance;
    }
    
    private void CarregarEstoqueInicial()
    {
        // Este método simularia o carregamento do estoque de uma fonte de dados
        // Em um sistema real, você carregaria esses dados de um banco de dados ou arquivo
        _estoque[1] = 100; // Produto 1 tem 100 unidades
        _estoque[2] = 50;  // Produto 2 tem 50 unidades
        // Adicione mais produtos conforme necessário
    }

    public bool VerificarDisponibilidade(int produtoId, int quantidade)
    {
        if (_estoque.TryGetValue(produtoId, out int quantidadeDisponivel))
        {
            return quantidadeDisponivel >= quantidade;
        }
        return false;
    }

    public void DiminuirEstoque(int produtoId, int quantidade)
    {
        if (_estoque.ContainsKey(produtoId))
        {
            _estoque[produtoId] -= quantidade;
            if (_estoque[produtoId] < 0)
            {
                _estoque[produtoId] = 0; // Evita estoque negativo
            }
        }
    }
    
    public void AumentarEstoque(int produtoId, int quantidade)
    {
        if (_estoque.ContainsKey(produtoId))
        {
            _estoque[produtoId] += quantidade;
        }
        else
        {
            _estoque[produtoId] = quantidade;
        }
    }

    public int ConsultarEstoque(int produtoId)
    {
        return _estoque.TryGetValue(produtoId, out int quantidade) ? quantidade : 0;
    }

    public void AtualizarEstoque(int produtoId, int novaQuantidade)
    {
        _estoque[produtoId] = novaQuantidade;
    }
    
    // Método para listar todo o estoque (útil para depuração ou relatórios)
    public Dictionary<int, int> ListarEstoque()
    {
        return new Dictionary<int, int>(_estoque);
    }
}