public class BST
{
    
    private No Raiz { get; set; }

    public BST()
    {
        this.Raiz = null;
    }

    private No InsertRecursivo(No raiz, int valor)
    {
        if (raiz == null)
        {
            return new No(valor);
        }

        if (valor > raiz.Key)
        {
            raiz.Direito = this.InsertRecursivo(raiz.Direito, valor);
        }
        else
        {
            raiz.Esquerdo = this.InsertRecursivo(raiz.Esquerdo, valor);
        }

        return raiz;
    }

    public void Insert(int valor)
    {
        this.Raiz = this.InsertRecursivo(this.Raiz, valor);
    }
    

    private No SearchRecursivo(No raiz, int valor)
    {
        if (raiz == null)
        {
            return null;
        }

        if (raiz.Key == valor)
            return raiz;
        else if (valor > raiz.Key)
            return this.SearchRecursivo(raiz.Direito, valor);
        else
            return this.SearchRecursivo(raiz.Esquerdo, valor);
    }

    public No Search(int valor)
    {
        return this.SearchRecursivo(this.Raiz, valor);
    }
    
    public int? Max()
    {
        No aux = this.Raiz;
        while (aux != null && aux.Direito != null)
        {
            aux = aux.Direito;
        }

        return aux == null ? null : aux.Key;
    }
    
    private int? MaxRecursivo(No aux)
    {
        if (aux == null)
        {
            return null;
        }
        else if (aux.Direito == null)
        {
            return aux.Key;
        }
        else 
        return MaxRecursivo(aux.Direito);
    }
    
    public int? MaxRec()
    {
        return this.MaxRecursivo(this.Raiz);
    }

    public int? Min()
    {
        No aux = this.Raiz;
        while (aux != null && aux.Esquerdo != null)
        {
            aux = aux.Esquerdo;
        }

        return aux == null ? null : aux.Key;
    }
    
    private int? MinRecursivo(No aux)
    {
        if (aux == null)
        {
            return null;
        }
        else if (aux.Esquerdo == null)
        {
            return aux.Key;
        }
        else 
            return MinRecursivo(aux.Esquerdo);
    }
    
    public int? MinRec()
    {
        return this.MinRecursivo(this.Raiz);
    }
    
    private void printInOrder(No node)
    {
        if (node != null)
        {
            this.printInOrder(node.Esquerdo);
            Console.Write(node.Key + " ");
            this.printInOrder(node.Direito);
        }
    }
    public void PrintInOrder()
    {
        this.printInOrder(this.Raiz);
    }
    
    private void printNicely(No node, string spacing)
    {
        if (node != null)
        {
            Console.WriteLine(spacing + node.Key);
            this.printNicely(node.Esquerdo, spacing + "..");
            this.printNicely(node.Direito, spacing + "..");
        }
    }
    
    public void PrintNicely()
    {
        this.printNicely(this.Raiz, ".");
    }
    
   

    
}