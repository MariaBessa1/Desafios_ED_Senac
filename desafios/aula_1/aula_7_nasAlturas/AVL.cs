
public class AVL
{
  private NoAVL Raiz { get; set; }

  private void printNicely(NoAVL no, string spacing)
  {
    if (no != null)
    {
      Console.WriteLine(spacing + no.Chave);
      this.printNicely(node.Esq, spacing + "..");
      this.printNicely(node.Dir, spacing + "..");
    }
  }

  public void PrintNicely()
  {
    this.printNicely(this.Raiz, ".");
  }

  private NoAVL BuscaRecursivo(NoAVL raiz, int chave)
  {
    if (raiz == null)
    {
      return null;
    }

    if (raiz.Chave == chave)
      return raiz;
    else if (chave > raiz.Chave)
      return BuscaRecursivo(raiz.Dir, chave);
    else
      return BuscaRecursivo(raiz.Esq, chave);
  }

  public NoAVL Busca(int valor)
  {
    return BuscaRecursivo(Raiz, valor);
  }

  private NoAVL RotacionaEsquerda(NoAVL raiz)
  {
    if (raiz == null) return raiz;

    NoAVL novaRaiz = raiz.Dir;
    raiz.Dir = novaRaiz.Esq;
    novaRaiz.Esq = raiz;
    raiz.CalculaAltura();
    novaRaiz.CalculaAltura();

    return novaRaiz;
  }
  private NoAVL RotacionaDireita(NoAVL raiz)
  {
    if (raiz == null) return raiz;

    NoAVL novaRaiz = raiz.Esq;
    raiz.Esq = novaRaiz.Dir;
    novaRaiz.Dir = raiz;
    raiz.CalculaAltura();
    novaRaiz.CalculaAltura();

    return novaRaiz;
  }
  private NoAVL InserirRecursivo(NoAVL raiz, int chave)
  {
    if (raiz == null) return new NoAVL(chave);

    // Igual BST padrão: vamos buscar onde inserir o nó
    // navegando pela árvore
    if (chave > raiz.Chave)
      raiz.Dir = InserirRecursivo(raiz.Dir, chave);
    else
      raiz.Esq = InserirRecursivo(raiz.Esq, chave);

    // Aqui nós modificamos a raiz, adicionando algo à direita ou 
    // à esquerda. Por isso, recalculamos sua altura.
    raiz.CalculaAltura();
    // Agora, vamos verificar se o nó está desbalanceado
    if (raiz.FatorDeBalanceamento == 2)
    {
      if (raiz.Esq?.FatorDeBalanceamento < 0)
        raiz.Esq = RotacionaEsquerda(raiz.Esq);

      raiz = RotacionaDireita(raiz);
    }
    else if (raiz.FatorDeBalanceamento == -2)
    {
      if (raiz.Dir.FatorDeBalanceamento > 0)
        raiz.Dir = RotacionaDireita(raiz.Dir);

      raiz = RotacionaEsquerda(raiz);
    }

    return raiz;
  }

  public void Insert(int valor)
  {
    Raiz = InserirRecursivo(Raiz, valor);
  }


}