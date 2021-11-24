using System;

namespace DotNet_Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            string opcaoUser = ObterOpcaoUsuario();
            while(opcaoUser.ToUpper() != "X"){
                switch(opcaoUser){
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
                        throw new ArgumentOutOfRangeException("Opção inválida");
                }
                opcaoUser = ObterOpcaoUsuario();
            }
            Console.WriteLine("Obrigado por utilizar nossos serviços");
            Environment.Exit(0);
        }

        private static void ListarSerie(){
            Console.WriteLine("Lista das séries: ");
            var lista = repositorio.Lista();
            if(lista.Count == 0){
                Console.WriteLine("Nenhuma série cadastrada");
                return;
            }
            foreach(var serie in lista){
                var excluido = serie.retornaExcluido();
                if(!excluido){
                    Console.WriteLine("#ID {0}: - {1} {2} ", serie.retornaId(), serie.retornaTitulo(), (excluido ? "*Excluido*" : ""));
                }else{
                    Console.WriteLine("Espaço vazio");
                }
                
            }
        }

        private static void InserirSerie(){
            Console.WriteLine("Inserir nova série: ");
            foreach(int i in Enum.GetValues(typeof(Genero))){
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.WriteLine("Digite o gênero entre as ações acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite o Título da Série: ");
            string entradaTitulo = Console.ReadLine();
            Console.WriteLine("Digite o Ano de Início da Série: ");
            int entradaAno = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite a Descrição da Série: ");
            string entradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie(id: repositorio.ProximoId(),
            genero: (Genero)entradaGenero, titulo: entradaTitulo,
            ano: entradaAno, descricao: entradaDescricao
            );
            repositorio.Insere(novaSerie);
        }

        private static void AtualizarSerie(){
            Console.WriteLine("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());
             foreach(int i in Enum.GetValues(typeof(Genero))){
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.WriteLine("Digite o gênero entre as ações acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite o Título da Série: ");
            string entradaTitulo = Console.ReadLine();
            Console.WriteLine("Digite o Ano de Início da Série: ");
            int entradaAno = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite a Descrição da Série: ");
            string entradaDescricao = Console.ReadLine();

            Serie atualizaSerie = new Serie(id: repositorio.ProximoId(),
            genero: (Genero)entradaGenero, titulo: entradaTitulo,
            ano: entradaAno, descricao: entradaDescricao
            );
            repositorio.Atualiza(indiceSerie, atualizaSerie);
        }
        
        private static void ExcluirSerie(){
            Console.WriteLine("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());
            repositorio.Exclui(indiceSerie);
        }

        private static void VisualizarSerie(){
            Console.WriteLine("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());
            var serie = repositorio.RetornaPorId(indiceSerie);
            Console.WriteLine(serie);
        }
        
        private static string ObterOpcaoUsuario(){
            Console.WriteLine();
            Console.WriteLine("Séries a seu dispor!!!");
            Console.WriteLine("Informe a opção desejada");
            Console.WriteLine("1 - Listar séries");
            Console.WriteLine("2 - Inserir nova série");
            Console.WriteLine("3 - Atualizar série");
            Console.WriteLine("4 - Excluir série");
            Console.WriteLine("5 - Visualizar série");
            Console.WriteLine("C - Limpar tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();
            string opcaoUser = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUser;
        }

    }
}
