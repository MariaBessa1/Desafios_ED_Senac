    public enum TipoPokemon
    {
        Fogo,
        Agua,
        Grama
    }

    public static class TipoPokemonExtension
    {
        public static double PegarVantagem(this TipoPokemon batendo, TipoPokemon apanhando)
        {
            if (batendo == TipoPokemon.Fogo && apanhando == TipoPokemon.Grama) return 2.0;
            if (batendo == TipoPokemon.Agua && apanhando == TipoPokemon.Fogo) return 2.0;
            if (batendo == TipoPokemon.Grama && apanhando == TipoPokemon.Agua) return 2.0;
            return 1.0;
        }

        public static double VaiSeLascarNaBatalha(this TipoPokemon apanhando, TipoPokemon batendo)
        {
            if (batendo == TipoPokemon.Fogo && apanhando == TipoPokemon.Agua) return 0.5;
            if (batendo == TipoPokemon.Agua && apanhando == TipoPokemon.Grama) return 0.5;
            if (batendo == TipoPokemon.Grama && apanhando == TipoPokemon.Fogo) return 0.5;
            return 1.0;
        }
    }