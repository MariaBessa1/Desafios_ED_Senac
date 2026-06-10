using System;
using Spectre.Console;


    public abstract class Pokemon
    {
        public string Nome { get; set; }
        public int Ataque { get; set; }
        public int Defesa { get; set; }
        public int Vida { get; set; }
        public int VidaMaxima { get; set; }
        public TipoPokemon Tipo { get; protected set; }
        public static readonly Random _random = new Random();

        public Pokemon(string nome, int ataque, int defesa, int vida, TipoPokemon tipo)
        {
            this.Nome = nome.ToUpper();
            this.Ataque = ataque;
            this.Defesa = defesa;
            this.Vida = vida;
            this.VidaMaxima = vida;
            this.Tipo = tipo;
        }

        public void ExibirStatus()
        {
            Console.WriteLine($"-> {Nome} [{Tipo}] | HP: {Vida} | ATK: {Ataque} | DEF: {Defesa}");
        }

        public abstract string AtacaAtaca(Pokemon alvo);

        public Panel MontarPainelStatus(bool ehMeuAlpha)
        {
            double porcentagemHP = (double)Vida / VidaMaxima;
            int quadradinhosDeVida = (int)Math.Ceiling(porcentagemHP * 12);
            if (quadradinhosDeVida < 0) quadradinhosDeVida = 0;

            string barraHP = new string('█', quadradinhosDeVida) + new string('░', 12 - quadradinhosDeVida);
            
   
            string corHP = porcentagemHP > 0.5 ? "green on #FFDEAD" : "red on #FFDEAD";

        
            string bgGameBoy = "on #FFDEAD"; 
            
            
            string dadosNaTela = $"[{bgGameBoy}]" +
                                 $"[bold black]{Nome}[/] [blue on #FFDEAD]♂[/]       [bold black]Lv5[/]\n" +
                                 $"[bold black on green] HP [/] [{corHP}]{barraHP}[/]\n";
            
            if (ehMeuAlpha)
            {
                dadosNaTela += $"[bold black] {Vida}/ {VidaMaxima}[/]";
            }
            
            dadosNaTela += "[/]"; 

            return new Panel(new Markup(dadosNaTela))
                .Border(BoxBorder.Rounded)
                .BorderColor(Color.Grey);
        }

        protected string CalcularEAplicarDano(Pokemon alvo, int poderAtaqueModificado)
        {
            double daNaCara = this.Tipo.PegarVantagem(alvo.Tipo);
            double tomaNaCara = alvo.Tipo.VaiSeLascarNaBatalha(this.Tipo);

            double multiplicadorFinal = (daNaCara != 1.0) ? daNaCara : tomaNaCara;

            int danoBase = poderAtaqueModificado - alvo.Defesa;
            int danoFinal = (int)(danoBase * multiplicadorFinal);

            if (danoFinal < 1) danoFinal = 1;

            alvo.Vida -= danoFinal;
            if (alvo.Vida < 0) alvo.Vida = 0;

            string feedback = multiplicadorFinal == 2.0 ? " (Jantou o betinha!)" :
                             multiplicadorFinal == 0.5 ? " (Ih nem doeu...)" : "";

            return $"{Nome} atacou {alvo.Nome} e meteu {danoFinal} de dano no rabo dele!{feedback}";
        }
    }
