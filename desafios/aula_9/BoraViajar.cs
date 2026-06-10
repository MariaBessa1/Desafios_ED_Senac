using System;
using System.Collections.Generic;

class Program
{
    static Dictionary<string, List<string>> mapa = new Dictionary<string, List<string>>();

    static void Main(string[] args)
    {
        MontarMapa();

        int opcao = 0;

        while (opcao != 5)
        {
            Console.WriteLine("\n=== Bora Viajar ===");
            Console.WriteLine("1 - Listar cidades");
            Console.WriteLine("2 - Verificar conexão direta");
            Console.WriteLine("3 - Existe rota? (DFS)");
            Console.WriteLine("4 - Menor rota (BFS)");
            Console.WriteLine("5 - Sair");

            Console.Write("\nDigite uma opção: ");
            opcao = int.Parse(Console.ReadLine());

            if (opcao == 1)
            {
                ListarCidades();
            }
            else if (opcao == 2)
            {
                ConexaoDireta();
            }
            else if (opcao == 3)
            {
                ExisteRotaDFS();
            }
            else if (opcao == 4)
            {
                MenorRotaBFS();
            }
            else if (opcao == 5)
            {
                Console.WriteLine("\nBoa viagem!");
            }
            else
            {
                Console.WriteLine("\nOpção inválida.");
            }
        }
    }

    static void MontarMapa()
    {
        mapa.Add("São Paulo", new List<string>()
        {
            "Rio de Janeiro",
            "Curitiba",
            "Belo Horizonte"
        });

        mapa.Add("Rio de Janeiro", new List<string>()
        {
            "São Paulo",
            "Belo Horizonte",
            "Vitória"
        });

        mapa.Add("Belo Horizonte", new List<string>()
        {
            "São Paulo",
            "Rio de Janeiro",
            "Brasília"
        });

        mapa.Add("Curitiba", new List<string>()
        {
            "São Paulo",
            "Florianópolis"
        });

        mapa.Add("Florianópolis", new List<string>()
        {
            "Curitiba",
            "Porto Alegre"
        });

        mapa.Add("Porto Alegre", new List<string>()
        {
            "Florianópolis"
        });

        mapa.Add("Brasília", new List<string>()
        {
            "Belo Horizonte",
            "Goiânia"
        });

        mapa.Add("Goiânia", new List<string>()
        {
            "Brasília"
        });

        mapa.Add("Vitória", new List<string>()
        {
            "Rio de Janeiro"
        });

        mapa.Add("Salvador", new List<string>()
        {
            "Recife"
        });

        mapa.Add("Recife", new List<string>()
        {
            "Salvador",
            "Fortaleza"
        });

        mapa.Add("Fortaleza", new List<string>()
        {
            "Recife"
        });
    }

    // mostra todas as cidades e suas conexões
    static void ListarCidades()
    {
        Console.WriteLine();

        foreach (var cidade in mapa)
        {
            Console.Write(cidade.Key + ": ");

            foreach (string vizinho in cidade.Value)
            {
                Console.Write(vizinho + " ");
            }

            Console.WriteLine();
        }
    }

    static void ConexaoDireta()
    {
        Console.Write("\nCidade 1: ");
        string cidade1 = Console.ReadLine();

        Console.Write("Cidade 2: ");
        string cidade2 = Console.ReadLine();

        if (!mapa.ContainsKey(cidade1) || !mapa.ContainsKey(cidade2))
        {
            Console.WriteLine("\nCidade não encontrada.");
            return;
        }

        if (mapa[cidade1].Contains(cidade2))
        {
            Console.WriteLine($"\n{cidade1} possui ligação direta com {cidade2}.");
        }
        else
        {
            Console.WriteLine($"\n{cidade1} não possui ligação direta com {cidade2}.");
        }
    }

    // DFS recursiva
    static bool DFS(string atual, string destino, HashSet<string> visitados)
    {
        visitados.Add(atual);

        Console.Write(atual + " ");

        if (atual == destino)
        {
            return true;
        }

        foreach (string vizinho in mapa[atual])
        {
            if (!visitados.Contains(vizinho))
            {
                if (DFS(vizinho, destino, visitados))
                {
                    return true;
                }
            }
        }

        return false;
    }

    static void ExisteRotaDFS()
    {
        Console.Write("\nOrigem: ");
        string origem = Console.ReadLine();

        Console.Write("Destino: ");
        string destino = Console.ReadLine();

        if (!mapa.ContainsKey(origem) || !mapa.ContainsKey(destino))
        {
            Console.WriteLine("\nCidade não encontrada.");
            return;
        }

        HashSet<string> visitados = new HashSet<string>();

        Console.Write("\nDFS visitando: ");

        bool encontrou = DFS(origem, destino, visitados);

        Console.WriteLine();

        if (encontrou)
        {
            Console.WriteLine($"\nExiste uma rota entre {origem} e {destino}.");
        }
        else
        {
            Console.WriteLine($"\nNão existe rota entre {origem} e {destino}.");
        }
    }

    static void MenorRotaBFS()
    {
        Console.Write("\nOrigem: ");
        string origem = Console.ReadLine();

        Console.Write("Destino: ");
        string destino = Console.ReadLine();

        if (!mapa.ContainsKey(origem) || !mapa.ContainsKey(destino))
        {
            Console.WriteLine("\nCidade não encontrada.");
            return;
        }

        Queue<string> fila = new Queue<string>();
        HashSet<string> visitados = new HashSet<string>();

        // guarda quem levou até cada cidade
        Dictionary<string, string> anterior = new Dictionary<string, string>();

        fila.Enqueue(origem);
        visitados.Add(origem);

        bool encontrou = false;

        while (fila.Count > 0)
        {
            string atual = fila.Dequeue();

            if (atual == destino)
            {
                encontrou = true;
                break;
            }

            foreach (string vizinho in mapa[atual])
            {
                if (!visitados.Contains(vizinho))
                {
                    visitados.Add(vizinho);

                    anterior[vizinho] = atual;

                    fila.Enqueue(vizinho);
                }
            }
        }

        if (!encontrou)
        {
            Console.WriteLine($"\nNão existe rota entre {origem} e {destino}.");
            return;
        }

        List<string> caminho = new List<string>();

        string aux = destino;

        while (aux != origem)
        {
            caminho.Add(aux);
            aux = anterior[aux];
        }

        caminho.Add(origem);

        caminho.Reverse();

        Console.WriteLine("\nMenor rota encontrada:");

        for (int i = 0; i < caminho.Count; i++)
        {
            Console.Write(caminho[i]);

            if (i < caminho.Count - 1)
            {
                Console.Write(" -> ");
            }
        }

        Console.WriteLine();
        Console.WriteLine("Quantidade de paradas: " + (caminho.Count - 1));
    }
}