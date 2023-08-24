using System.Globalization;

namespace ControleEstoque
{
    class Livro
    {
        public string Titulo { get; set; }
        public double Preco { get; set; }
        public string Autor { get; set; }
        public string Genero { get; set; }
        public int Quantidade { get; set; }
    }

    class Program
    {
        static List<Livro> estoque = new List<Livro>();

        static void Main(string[] args)
        {
            bool executando = true;

            while (executando)
            {
                Console.WriteLine("CONTROLE DE ESTOQUE - LUK'S BOOKS");
                Console.WriteLine("[1] Novo");
                Console.WriteLine("[2] Listar Produtos");
                Console.WriteLine("[3] Remover Produtos");
                Console.WriteLine("[4] Entrada Estoque");
                Console.WriteLine("[5] Saída Estoque");
                Console.WriteLine("[0] Sair");
                Console.Write("Escolha uma opção: ");
                int opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        AdicionarLivro();
                        break;
                    case 2:
                        ListarProdutos();
                        break;
                    case 3:
                        RemoverProduto();
                        break;
                    case 4:
                        EntradaEstoque();
                        break;
                    case 5:
                        SaidaEstoque();
                        break;
                    case 0:
                        executando = false;
                        break;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
            }
        }

static void AdicionarLivro()
            {
                Console.Write("Informe o nome do Livro: ");
                string titulo = Console.ReadLine();

                Console.Write("Informe o preço: ");
                string precoInput = Console.ReadLine();
                double preco;

                if (!Double.TryParse(precoInput.Replace(',', '.'), NumberStyles.Float, CultureInfo.InvariantCulture, out preco))
                {
                    Console.WriteLine("Preço inválido.");
                    return;
                }

                Console.Write("Informe o autor(a): ");
                string autor = Console.ReadLine();

                Console.Write("Informe o Gênero: ");
                string genero = Console.ReadLine();

                Livro novoLivro = new Livro
                {
                    Titulo = titulo,
                    Preco = preco,
                    Autor = autor,
                    Genero = genero,
                    Quantidade = 0
                };

                estoque.Add(novoLivro);
                Console.WriteLine("Livro adicionado!");
            }
static void ListarProdutos()
{
    if (estoque.Count == 0)
    {
        Console.WriteLine("Estoque vazio");
        return;
    }

    for (int i = 0; i < estoque.Count; i++)
    {
        Livro livro = estoque[i];
        string quantidadeStr = livro.Quantidade > 0 ? livro.Quantidade.ToString() : "Estoque vazio";
        string precoStr = livro.Preco.ToString("C");
        Console.WriteLine($"{i + 1}. {livro.Titulo} ({precoStr}) – {quantidadeStr}");
    }
}
        static void RemoverProduto()
        {
            Console.Write("Informe a posição do livro a ser removido: ");
            int posicao = int.Parse(Console.ReadLine()) - 1;

            if (posicao >= 0 && posicao < estoque.Count)
            {
                estoque.RemoveAt(posicao);
                Console.WriteLine("Livro removido!");
            }
            else
            {
                Console.WriteLine("Posição inválida.");
            }
        }
        static void EntradaEstoque()
        {
            Console.Write("Informe a posição do livro: ");
            int posicao = int.Parse(Console.ReadLine()) - 1;

            if (posicao >= 0 && posicao < estoque.Count)
            {
                Console.Write("Informe a quantidade de Entrada: ");
                int quantidadeEntrada = int.Parse(Console.ReadLine());

                estoque[posicao].Quantidade += quantidadeEntrada;
                Console.WriteLine("Entrada de estoque registrada.");
            }
            else
            {
                Console.WriteLine("Posição inválida.");
            }
        }

        static void SaidaEstoque()
        {
            Console.Write("Informe a posição do livro: ");
            int posicao = int.Parse(Console.ReadLine()) - 1;

            if (posicao >= 0 && posicao < estoque.Count)
            {
                Console.Write("Informe a quantidade de Saída: ");
                int quantidadeSaida = int.Parse(Console.ReadLine());

                if (quantidadeSaida <= estoque[posicao].Quantidade)
                {
                    estoque[posicao].Quantidade -= quantidadeSaida;
                    Console.WriteLine("Saída de estoque registrada.");
                }
                else
                {
                    Console.WriteLine("Quantidade insuficiente em estoque.");
                }
            }
            else
            {
                Console.WriteLine("Posição inválida.");
            }
        }
    }
}
