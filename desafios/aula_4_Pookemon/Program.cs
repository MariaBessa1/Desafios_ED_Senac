
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Treinador ash = new Treinador("Ash");
            Treinador misty = new Treinador("Misty");

            ash.AdicionarPokemon(new PokemonFogo("Charmander", 14, 7, 45));
            ash.AdicionarPokemon(new PokemonGrama("Bulbasaur", 12, 10, 50));

            misty.AdicionarPokemon(new PokemonAgua("Squirtle", 13, 9, 48));
            misty.AdicionarPokemon(new PokemonAgua("Starmie", 16, 8, 40));

            Console.WriteLine("=== PREPARAÇÃO PARA A BATALHA ====");
            ash.ListarPokemons();
            misty.ListarPokemons();
            Console.WriteLine("\n==========================================");

            Console.Write($"\n{ash.Nome}, escolha o índice do seu Pokémon da lista acima: ");
            int indiceDigitado = int.Parse(Console.ReadLine() ?? "0");
            Pokemon pAsh = ash.EscolherPokemon(indiceDigitado);

            Random dados = new Random();
            int indiceInimigo = dados.Next(0, misty.Pokemons.Count);
            Pokemon pMisty = misty.EscolherPokemon(indiceInimigo);

            TelaBatalha.DesenharArena(pAsh, pMisty, $"Go! {pAsh.Nome}!");
            Thread.Sleep(2500);

            int turno = 1;

            while (pAsh.Vida > 0 && pMisty.Vida > 0)
            {
                string resultadoTurno = pAsh.AtacaAtaca(pMisty);
                TelaBatalha.DesenharArena(pAsh, pMisty, $"[Turno {turno}]\n{resultadoTurno}");
                Thread.Sleep(2500);

                if (pMisty.Vida <= 0) break;

                resultadoTurno = pMisty.AtacaAtaca(pAsh);
                TelaBatalha.DesenharArena(pAsh, pMisty, $"[Turno {turno}]\n{resultadoTurno}");
                Thread.Sleep(2500);

                turno++;
            }

            Console.WriteLine();
            if (pAsh.Vida > 0)
            {
                TelaBatalha.DesenharArena(pAsh, pMisty, $"🏆 {pMisty.Nome} foi mogado! {ash.Nome} é o grande vencedor!");
            }
            else
            {
                TelaBatalha.DesenharArena(pAsh, pMisty, $"🏆 {ash.Nome} foi mogado!! {misty.Nome} é a grande vencedora!");
            }
        }
    }
    