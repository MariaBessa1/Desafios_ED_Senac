using Spectre.Console;

    public static class TelaBatalha
    {
        public static void DesenharArena(Pokemon meuAlpha, Pokemon betinhaInimigo, string logDeCombate)
        {
            Console.Clear();

            var cenarioGeral = new Grid();
            cenarioGeral.AddColumn();
            cenarioGeral.AddColumn();

            var hudInimigo = betinhaInimigo.MontarPainelStatus(ehMeuAlpha: false);
            var bonecoInimigo = new Panel(new Markup($"[blue]   🐢 {betinhaInimigo.Nome}[/]")).Border(BoxBorder.None);
            cenarioGeral.AddRow(hudInimigo, bonecoInimigo);

            cenarioGeral.AddRow(new Text(""), new Text(""));
            cenarioGeral.AddRow(new Text(""), new Text(""));

            var meuBoneco = new Panel(new Markup($"[red]  🔥 {meuAlpha.Nome} (Costas)[/]")).Border(BoxBorder.None);
            var meuHud = meuAlpha.MontarPainelStatus(ehMeuAlpha: true);
            cenarioGeral.AddRow(meuBoneco, meuHud);

      
         var legendaDeBaixo = new Panel(new Markup($"[bold white]{Markup.Escape(logDeCombate)}[/]"))               
          .Padding(1, 1, 1, 1)
                .Border(BoxBorder.Double)
                .BorderColor(Color.Yellow)
                .Expand();

          
            var telaGeral = new Panel(new Rows(cenarioGeral, new Text("\n"), legendaDeBaixo))
                .Border(BoxBorder.Square)
                .BorderColor(Color.DarkBlue);
            
            telaGeral.Width = 64; 

            AnsiConsole.Write(telaGeral);
        }
    }