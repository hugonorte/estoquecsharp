namespace estoque;
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        // Inicialização do sistema
        var estoqueManager = EstoqueManager.GetInstance();
        var gerenciadorEstoque = new GerenciadorEstoque();
        var interfaceUsuario = new InterfaceUsuario();
        gerenciadorEstoque.AdicionarObservador(interfaceUsuario);
        
        // Criação de alguns produtos
        var produto1 = new Produto { Id = 1, Nome = "Camiseta", PrecoBase = 29.99m };
        var produto2 = new Produto { Id = 2, Nome = "Calça", PrecoBase = 59.99m };
        
        // Definição de estratégias de precificação
        produto1.SetEstrategiaPrecificacao(new PrecoNormal());
        produto2.SetEstrategiaPrecificacao(new DescontoDezPorcento());

        // Simulação de adição de estoque
        estoqueManager.AtualizarEstoque(produto1.Id, 100);
        estoqueManager.AtualizarEstoque(produto2.Id, 50);

        // Criação do carrinho
        var carrinho = new Carrinho();

        // Loop principal do programa
        while (true)
        {
            Console.WriteLine("\n--- Sistema de Vendas ---");
            Console.WriteLine("1. Adicionar item ao carrinho");
            Console.WriteLine("2. Remover item do carrinho");
            Console.WriteLine("3. Visualizar carrinho");
            Console.WriteLine("4. Finalizar compra");
            Console.WriteLine("5. Sair");
            Console.Write("Escolha uma opção: ");

            string opcao = Console.ReadLine()!;

            switch (opcao)
            {
                case "1":
                    AdicionarItemAoCarrinho(carrinho, estoqueManager);
                    break;
                case "2":
                    RemoverItemDoCarrinho(carrinho);
                    break;
                case "3":
                    VisualizarCarrinho(carrinho);
                    break;
                case "4":
                    FinalizarCompra(carrinho, estoqueManager, gerenciadorEstoque);
                    break;
                case "5":
                    Console.WriteLine("Obrigado por usar o sistema de vendas!");
                    return;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }
        }
    }

    static void AdicionarItemAoCarrinho(Carrinho carrinho, EstoqueManager estoqueManager)
    {
        Console.Write("Digite o ID do produto: ");
        int produtoId = int.Parse(Console.ReadLine()!);
        Console.Write("Digite a quantidade: ");
        int quantidade = int.Parse(Console.ReadLine()!);

        if (estoqueManager.VerificarDisponibilidade(produtoId, quantidade))
        {
            // Aqui, você precisaria buscar o produto real baseado no ID
            var produto = new Produto { Id = produtoId, Nome = $"Produto {produtoId}", PrecoBase = 10.0m };
            var comando = new AdicionarItemCommand(carrinho, produto, quantidade);
            comando.Executar();
            Console.WriteLine("Item adicionado ao carrinho.");
        }
        else
        {
            Console.WriteLine("Produto não disponível em estoque na quantidade solicitada.");
        }
    }

    static void RemoverItemDoCarrinho(Carrinho carrinho)
    {
        // Implementação da remoção de item do carrinho
        Console.WriteLine("Funcionalidade não implementada neste exemplo.");
    }

    static void VisualizarCarrinho(Carrinho carrinho)
    {
        // Implementação da visualização do carrinho
        Console.WriteLine("Funcionalidade não implementada neste exemplo.");
    }

    static void FinalizarCompra(Carrinho carrinho, EstoqueManager estoqueManager, GerenciadorEstoque gerenciadorEstoque)
    {
        // Aqui você implementaria a lógica para finalizar a compra
        // Incluindo a atualização do estoque
        Console.WriteLine("Compra finalizada. Obrigado!");
    }
}