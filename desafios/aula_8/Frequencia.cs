
using System;
using System.Collections.Generic;
using System.Linq;

int opcao = 0;

//Criação do dicionário para contar a ocorrência de cada palavra (string = palavra, int = frequencia de vezes q apareceu)
Dictionary<string, int> frequencia = new Dictionary<string, int>();

//Usado posteriormente para a comparação entre textos
List<HashSet<string>> textos = new List<HashSet<string>>();

while (opcao != 4) {
    Console.WriteLine("\n== Vamos montar um sistema de busca em um dicionário! Para iniciar, selecione uma das opções abaixo:\n");
    Console.WriteLine("1) Novo texto");
    Console.WriteLine("2) Buscar palavra");
    Console.WriteLine("3) Comparar textos");
    Console.WriteLine("4) Sair");

    opcao = int.Parse(Console.ReadLine());

    if (opcao == 1) {

        frequencia.Clear();

        //Recebe um texto do usuario que so termina qnd ele digita uma linha vazia
        string guardaTexto = "";

        Console.WriteLine("\n== Digite um texto qualquer para validarmos nosso dicionário!! Se quiser encerrar, apenas digite uma linha vazia.\n");

        while (true) {
            string textoDigitado = Console.ReadLine();

            if (textoDigitado == "")
                break;

            guardaTexto += textoDigitado + " "; 
        }

        //Convertendo o texto para minusculo

        guardaTexto = guardaTexto.ToLower();

        //Removendo a pontuacao

        guardaTexto = guardaTexto.Replace(".", "");
        guardaTexto = guardaTexto.Replace(",", "");
        guardaTexto = guardaTexto.Replace("!", "");
        guardaTexto = guardaTexto.Replace("?", "");
        guardaTexto = guardaTexto.Replace(":", "");
        guardaTexto = guardaTexto.Replace(";", "");

        // Fazendo um array para separar palavras do texto para a busca no dicionario

        string[] palavras = guardaTexto.Split(' ');

        HashSet<string> conjunto = new HashSet<string>();

        foreach (string palavra in palavras)
        {
            if (palavra == "")
                continue;

            conjunto.Add(palavra);


            if (frequencia.ContainsKey(palavra)) //Se o dicionario ja tem a palavra, adiciona na conta
            {
                frequencia[palavra]++;
            }
            else
            {
                frequencia[palavra] = 1; //Se ainda nao tiver, adiciona a primeira
            }
        }

        int totalPalavras = palavras.Length -1 ;

        Console.WriteLine("-----------------------------------");
        Console.WriteLine("===Resultado por ordem de repetição===");
        Console.WriteLine("-----------------------------------");
        Console.WriteLine($"Total de palavras: {totalPalavras}");
        Console.WriteLine($"Palavras distintas: {frequencia.Count}");
        Console.WriteLine(" ");
        foreach (var item in frequencia.OrderByDescending(x => x.Value))
        {
            Console.WriteLine($"{item.Key} - {item.Value} ocorrência");
        }

        textos.Add(conjunto);
    }
    else if (opcao == 2) {
        
        Console.WriteLine("== Qual palavra deseja buscar?");

        string buscaPalavra = Console.ReadLine().ToLower();

        if (frequencia.ContainsKey(buscaPalavra))
        {
            Console.WriteLine($"\nA palavra {buscaPalavra} apareceu {frequencia[buscaPalavra]} vezes :).");
        }
        else
        {
            Console.WriteLine($"\nA palavra {buscaPalavra} não apareceu no texto que digitou :(.");
        }
    }
    else if (opcao == 3) {
        
        HashSet<string> texto1 = new HashSet<string>(textos[textos.Count - 2]); //primeiro texto

        HashSet<string> texto2 = textos[textos.Count - 1]; //segundo texto

        texto1.IntersectWith(texto2);

        Console.WriteLine("\n==Palavras em comum:==");

        foreach (string palavra in texto1)
        {
            Console.WriteLine(palavra);
        }
    }
    else if (opcao == 4) {

        Console.WriteLine("Então tchau!");
    }
}