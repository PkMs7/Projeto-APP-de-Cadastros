using System;
using ProjetoCadastroDeSeries.classes;
using Projeto_APP_de_Cadastros.Enum;
using Projeto_APP_de_Cadastros.classes;



class Program
{
    static SerieRepositorio repositorio = new SerieRepositorio();
    static void Main(string[] args)
    {
        string opcaoUsuario = ObterOpcaoUsuario();

        while (opcaoUsuario.ToUpper() != "X")
        {
            switch (opcaoUsuario)
            {
                case "1":
                    ListarSerie();
                    break;
                case "2":
                    InserirSerie();
                    break;
                case "3":
                    AtualizarSerie();
                    break;
                case "4":
                    ExcluirSerie();
                    break;
                case "5":
                    VisualizarSerie();
                    break;
                case "C":
                    Console.Clear();
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }
            
            opcaoUsuario = ObterOpcaoUsuario();
        }

        Console.WriteLine("Obrigado por utilizar nossos serviços.");
		Console.ReadLine();
    }
    private static void ListarSerie()
    {
        Console.WriteLine("Lista de séries:");

        var lista = repositorio.Lista();

        if (lista.Count == 0)
        {
            Console.WriteLine("Nenhuma série cadastrada.");
            return;
        }
        foreach (var serie in lista)
        {
            Console.WriteLine($"#ID {serie.retornaId()}: - {serie.retornaTitulo()} Excluído: [{serie.retornaExcluido()}]");
        }
    }
    private static void InserirSerie()
    {
        foreach (int i in Enum.GetValues(typeof(Genero)))
        {
            Console.WriteLine($"{i}-{Enum.GetName(typeof(Genero), i)}");
        }
        Console.WriteLine("Digite o gênero entre as opções acmima:");
        int entradaGenero = int.Parse(Console.ReadLine());

        Console.WriteLine("Digite o título da série:");
        string entradaTitulo = Console.ReadLine();

        Console.WriteLine("Digite o ano de início da série:");
        int entradaAno = int.Parse(Console.ReadLine());

        Console.WriteLine("Digite a descrição da série:");
        string entradaDescricao = Console.ReadLine();

        Series novaSerie = new Series(id: repositorio.ProximoId(), genero: (Genero)entradaGenero, titulo: entradaTitulo, ano: entradaAno, descricao: entradaDescricao);

        repositorio.Insere(novaSerie);
    }

    private static void AtualizarSerie()
    {
        Console.WriteLine("Digite o id da série:");
        int indiceSerie = int.Parse(Console.ReadLine());

        foreach (int i in Enum.GetValues(typeof(Genero)))
        {
            Console.WriteLine($"{i}-{Enum.GetName(typeof(Genero), i)}");
        }
        Console.WriteLine("Digite o gênero entre as opções acmima:");
        int entradaGenero = int.Parse(Console.ReadLine());

        Console.WriteLine("Digite o título da série:");
        string entradaTitulo = Console.ReadLine();

        Console.WriteLine("Digite o ano de início da série:");
        int entradaAno = int.Parse(Console.ReadLine());

        Console.WriteLine("Digite a descrição da série:");
        string entradaDescricao = Console.ReadLine();

        Series atualizaSerie = new Series(id: indiceSerie, genero: (Genero)entradaGenero, titulo: entradaTitulo, ano: entradaAno, descricao: entradaDescricao);

        repositorio.Atualiza(indiceSerie, atualizaSerie);
    }

    private static void ExcluirSerie()
    {
        Console.WriteLine("Digite o id da série:");
        int indiceSerie = int.Parse(Console.ReadLine());

        repositorio.Exclui(indiceSerie);
    }

    private static void VisualizarSerie()
    {
        Console.WriteLine("Digite o id da série:");
        int indiceSerie = int.Parse(Console.ReadLine());

        var serie = repositorio.RetornaPorId(indiceSerie);

        Console.WriteLine(serie);
    }

    private static string ObterOpcaoUsuario()
    {
        Console.WriteLine();
        Console.WriteLine("DIO-Patrick Séries a seu dispor!!!");
        Console.WriteLine("Informe a opção desejada:");
        Console.WriteLine();

        Console.WriteLine("1 - Listar séries");
        Console.WriteLine("2 - Inserir nova série");
        Console.WriteLine("3 - Atualizar série");
        Console.WriteLine("4 - Excluir série");
        Console.WriteLine("5 - Visualizar série");
        Console.WriteLine("C - Limpar tela");
        Console.WriteLine("X - Sair");
        Console.WriteLine();

        string opcaoUsuario = Console.ReadLine().ToUpper();
        Console.WriteLine();
        return opcaoUsuario;
    }
}