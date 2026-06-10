 public class PokemonAgua : Pokemon
    {
        public PokemonAgua(string nome, int ataque, int defesa, int vida) 
            : base(nome, ataque, defesa, vida, TipoPokemon.Agua) { }

        public override string AtacaAtaca(Pokemon alvo)
        {
            string textoAtaque = CalcularEAplicarDano(alvo, Ataque);
            this.Vida += 2;
            if (this.Vida > this.VidaMaxima) this.Vida = this.VidaMaxima;
            return textoAtaque + $"\n{Nome} foi tomar um copo de água e recuperou +2 de Vida! Viva a hidratação!";
        }
    }