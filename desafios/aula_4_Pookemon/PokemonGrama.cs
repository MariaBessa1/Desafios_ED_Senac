using System;


    public class PokemonGrama : Pokemon
    {
        public PokemonGrama(string nome, int ataque, int defesa, int vida) 
            : base(nome, ataque, defesa, vida, TipoPokemon.Grama) { }

        public override string AtacaAtaca(Pokemon alvo)
        {
            bool meteuCritico = _random.Next(100) < 20;
            int ataqueFinal = meteuCritico ? Ataque * 2 : Ataque;

            string textoAtaque = CalcularEAplicarDano(alvo, ataqueFinal);
            return meteuCritico ? $"METEU CRÍTICO! As folhas folhearam tudo!\n{textoAtaque}" : textoAtaque;
        }
    }