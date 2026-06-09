
public class NoAVL
{
  public int Altura { get; set; }
  public int Chave { get; set; }

  public int FatorDeBalanceamento
  {
    get
    {
      int esquerda = 0, direita = 0;
      if (Esq != null) esquerda = Esq.Altura;
      if (Dir != null) direita = Dir.Altura;
      return esquerda - direita;
    }
  }
  public NoAVL Esq { get; set; }
  public NoAVL Dir { get; set; }

  public NoAVL(int valor)
  {
    this.Chave = valor;
    this.Altura = 1;
  }

  public void CalculaAltura()
  {
    //this.Altura = Math.Max(this.Esq?.Altura ?? 0, this.Dir?.Altura ?? 0) + 1;
    int alturaEsq = 0, alturaDir = 0;
    if (this.Esq != null) alturaEsq = this.Esq.Altura;
    if (this.Dir != null) alturaDir = this.Dir.Altura;

    this.Altura = 1 + Math.Max(alturaDir, alturaEsq);
  }

}