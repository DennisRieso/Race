using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rennen
{
    internal class Tier : Lebewesen
    {

        private static char aktuellesSymbol = '1'; // Start mit Symbol '1'
        private static Dictionary<char, string> symbolFarben = new Dictionary<char, string>();
        private static List<string> verfuegbareFarben = new List<string> { "DarkBlue", "DarkCyan ", "DarkMagenta", "DarkRed", "DarkYellow", "Gray" };
        private static int farbIndex = 0;

        public char Symbol { get; private set; }
        public string Farbe { get; private set; }

        // Generiere das nächste Symbol und inkrementiere die statische Variable
        private static char GeneriereNaechstesSymbol()
        {
            char zeichen = aktuellesSymbol;

            if (!symbolFarben.ContainsKey(zeichen))
            {
                symbolFarben[zeichen] = verfuegbareFarben[farbIndex % verfuegbareFarben.Count];
                farbIndex++;
            }

            aktuellesSymbol = aktuellesSymbol < '9' ? (char)(aktuellesSymbol + 1) : '1';
            return zeichen;
        }


        public Tier() : base( GeneriereNaechstesSymbol() )
        {
            
        }

        public Tier(float in_pos_x, float in_pos_y) : base( GeneriereNaechstesSymbol() )
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
                case "DarkBlue":
                    consoleFarbe = ConsoleColor.DarkBlue;
                    break;
                case "DarkCyan":
                    consoleFarbe = ConsoleColor.DarkCyan;
                    break;
                case "DarkMagenta":
                    consoleFarbe = ConsoleColor.DarkMagenta;
                    break;
                case "DarkRed":
                    consoleFarbe = ConsoleColor.DarkRed;
                    break;
                case "DarkYellow":
                    consoleFarbe = ConsoleColor.DarkYellow;
                    break;
                case "Gray":
                    consoleFarbe = ConsoleColor.Gray;
                    break;
                    // Füge weitere Farben hinzu
            }

            Console.ForegroundColor = consoleFarbe;
            base.zeichne(); // Rufe die Basisimplementierung auf, um das Symbol zu zeichnen
            Console.ResetColor(); // Setzt die Farbe wieder auf die Standardfarbe zurück
        }

    }
}
