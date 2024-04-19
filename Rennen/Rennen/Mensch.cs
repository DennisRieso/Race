using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rennen
{
    internal class Mensch : Lebewesen
    {
        private static char aktuellesSymbol = 'A'; // Start mit Symbol 'A'
        private static string horse = "\U0001F3C7"; // Start mit Symbol '🏇'

        private static Dictionary<char, string> symbolFarben = new Dictionary<char, string>();
        private static List<string> verfuegbareFarben = new List<string> { "Rot", "Grün", "Blau", "Gelb", "Cyan", "Magenta" };
        private static int farbIndex = 0;

        public char Symbol { get; private set; }
        public string Farbe { get; private set; }

        // Generiere das nächste Symbol
        private static char GeneriereNaechstesSymbol()
        {
            char zeichen = aktuellesSymbol;

            if (!symbolFarben.ContainsKey(zeichen))
            {
                symbolFarben[zeichen] = verfuegbareFarben[farbIndex % verfuegbareFarben.Count];
                farbIndex++;
            }

            aktuellesSymbol = aktuellesSymbol < 'Z' ? (char)(aktuellesSymbol + 1) : 'A';
            return zeichen;
        }

        public Mensch() : base( GeneriereNaechstesSymbol() ) 
        {
            Farbe = symbolFarben[Symbol];
        }

        public Mensch( float in_pos_x, float in_pos_y) : base( GeneriereNaechstesSymbol() )
        {
            this.setPos_x(in_pos_x);
            this.setPos_y(in_pos_y);
            this.Symbol = base.getSymbol(); // Stelle sicher, dass Symbol gesetzt wird.
            Farbe = symbolFarben[this.Symbol]; // Verwende nun `this.Symbol`
        }

        // Überschreibe die zeichne Methode aus Lebewesen
        public override void zeichne()
        {
            ConsoleColor consoleFarbe = ConsoleColor.White; // Standardfarbe
            switch (Farbe)
            {
                case "Rot":
                    consoleFarbe = ConsoleColor.Red;
                    break;
                case "Grün":
                    consoleFarbe = ConsoleColor.Green;
                    break;
                case "Blau":
                    consoleFarbe = ConsoleColor.Blue;
                    break;
                case "Gelb":
                    consoleFarbe = ConsoleColor.Yellow;
                    break;
                case "Cyan":
                    consoleFarbe = ConsoleColor.Cyan;
                    break;
                case "Magenta":
                    consoleFarbe = ConsoleColor.Magenta;
                    break;
                    // Füge weitere Farben hinzu
            }

            Console.ForegroundColor = consoleFarbe;
            base.zeichne(); // Rufe die Basisimplementierung auf, um das Symbol zu zeichnen
            Console.ResetColor(); // Setzt die Farbe wieder auf die Standardfarbe zurück
        }

        // Wird nicht mehr benötigt -> Reserve
      /*  public void DruckeSymbolMitFarbe()
        {
            // Übersetze die Farbzeichenkette in eine ConsoleColor
            ConsoleColor consoleFarbe = ConsoleColor.White; // Standardfarbe
            switch (Farbe)
            {
                case "Rot":
                    consoleFarbe = ConsoleColor.Red;
                    break;
                case "Grün":
                    consoleFarbe = ConsoleColor.Green;
                    break;
                case "Blau":
                    consoleFarbe = ConsoleColor.Blue;
                    break;
                case "Gelb":
                    consoleFarbe = ConsoleColor.Yellow;
                    break;
                    // Füge weitere Farben hinzu
            }

            Console.ForegroundColor = consoleFarbe;
            Console.WriteLine(Symbol);
            Console.ResetColor(); // Setzt die Farbe wieder auf die Standardfarbe zurück
        } */


    }
}
