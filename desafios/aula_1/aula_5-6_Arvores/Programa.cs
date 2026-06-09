public class Programa {

    public static void Main(string[] args)
    {
       BST tree = new BST();
        tree.Insert(23);
        tree.Insert(3);
        tree.Insert(12);
        tree.Insert(7);
        tree.Insert(13);
        tree.Insert(4);

        var maior = tree.MaxRec();
        var menor = tree.MinRec();

        Console.WriteLine("Valores ordenados:\n");
        tree.PrintInOrder();
        Console.WriteLine($"\nO menor valor da árvore é {menor} e o maior é {maior}\n");
        Console.WriteLine("Visualização bonita:\n");
        tree.PrintNicely();
    }
}