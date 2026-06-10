public class No {
    public int Key { get; set; }
    public No Esquerdo { get; set; }
    public No Direito { get; set; }
    

    public No(int valor) {
        this.Key = valor;
    }
}