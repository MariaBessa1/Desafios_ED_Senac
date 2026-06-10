using System;

public class NasAlturas
{
    public static void Main()
    {

        int opcao = 0;

        while (opcao != 2)
        {
            Console.WriteLine("Olá! Vamos fazer um simulador de cálculo de altura em árvores :) Sente-se!!");
            Console.WriteLine("Menu: 1) Nova Simulação, 2) Sair");

            opcao = int.Parse(Console.ReadLine());

            if (opcao == 1)
            {
                Console.WriteLine("Digite a quantidade de amostras:");
                int A = int.Parse(Console.ReadLine());

                Console.WriteLine("Digite a quantidade de nós:");
                int N = int.Parse(Console.ReadLine());

                Random random = new Random();

                double somaBST = 0;
                double somaAVL = 0;

                for (int i = 0; i < A; i++)
                {
                    BST bst = new BST();
                    AVL avl = new AVL();

                    for (int j = 0; j < N; j++)
                    {
                        int numeroAleatorio = random.Next(1, 1000);

                        bst.Insert(numeroAleatorio);
                        avl.Insert(numeroAleatorio);
                    }

                    somaBST += bst.Altura();
                    somaAVL += avl.Altura();
                }

                double mediaBST = somaBST / A;
                double mediaAVL = somaAVL / A;
                double mediaGeral = (mediaBST + mediaAVL) / 2;

                Console.WriteLine();
                Console.WriteLine("------------------------------");
                Console.WriteLine("Resultado");
                Console.WriteLine($"A Altura média das BST geradas é: {mediaBST}");
                Console.WriteLine($"A Altura média das AVL geradas é: {mediaAVL}");
                Console.WriteLine($"A Altura média geral é: {mediaGeral}");
                Console.WriteLine("------------------------------");
            }
            else if (opcao == 2)
            {
                Console.WriteLine("Então tchau!");
            }
            else
            {
                Console.WriteLine("Opção inválida.");
            }
        }
    }
}