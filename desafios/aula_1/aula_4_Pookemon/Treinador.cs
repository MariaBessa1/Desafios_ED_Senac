
    public class Treinador
    {
        public string Nome { get; set; }
        public LinkedList<Pokemon> Pokemons { get; set; }

        public Treinador(string nome)
        {
            Nome = nome;
            Pokemons = new LinkedList<Pokemon>();
        }

        public void AdicionarPokemon(Pokemon p)
        {
            Pokemons.AddLast(p);
        }

        public void ListarPokemons()
        {
            Console.WriteLine($"\nPokémons de {Nome}:");
            int i = 0;
            foreach (var pokemon in Pokemons)
            {
                Console.Write($"[{i}] ");
                pokemon.ExibirStatus();
                i++;
            }
        }

        public Pokemon EscolherPokemon(int indice)
        {
            if (indice < 0 || indice >= Pokemons.Count)
            {
                Console.WriteLine("Esse indice nem existe aqui! Chapou. Mas toma um pokemon de brinde ai, assim voce nao parece burro.\n\n\n\n\n...Se tiver ne, capaz que tu nem Pokemon tem.");
                if (Pokemons.Count < 1)
                {
                    Console.WriteLine("Ai tu quebra minhas pernas, né cara. Vai caçar pokemon e para de encher o saco");
                    return null;
                }
                return Pokemons.First.Value;
            }
            LinkedListNode<Pokemon> atual = Pokemons.First;
            for (int i = 0; i < indice; i++)
            {
                atual = atual.Next;
            }
            return atual.Value;
        }
    }