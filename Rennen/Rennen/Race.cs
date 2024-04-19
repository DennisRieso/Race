using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Rennen
{
    internal class Race
    {
        private int             game_speed      = 1000 / 10;
        private int             anzahl          = 12; // Maximal nur 12 Teilnehmer!!!!!
        // Lebewesen in Array speichern
        private Lebewesen[]     array_lebewesen = null;
        private bool            running         = false;

        private int             ziel_x_pos      = 50;

        public Race() 
        {
            this.Benutzereingaben();
        }

        private void Benutzereingaben()
        {
            Console.WriteLine("Hallo. Willkommen zum Rennen!");
            Console.WriteLine("=============================");
            Console.WriteLine("Wieviele Teilnehmer (max. 12) soll das Rennen haben?");
            Console.Write("Bitte geben Sie die Anzahl an: ");
            this.anzahl = Convert.ToInt32(Console.ReadLine());

            Console.Clear();
            Console.CursorVisible = false;

            this.erzeugeLebewesen();
            this.zeichneSpielfeld();
        }

        private void zeichneSpielfeld()
        {
            for (int i = 0; i < this.array_lebewesen.Length; i++)
            {
                Console.SetCursorPosition(0, i * 2 + 1 );
                Console.WriteLine(new string('-' , this.ziel_x_pos ) );
            }
            for (int i = 0; i < this.array_lebewesen.Length * 2 ; i++)
            {
                Console.SetCursorPosition( this.ziel_x_pos - 1 , i );
                Console.WriteLine('|');
            }
        }

        public void start()
        {
            this.running = true;
            while (this.running)
            {
                for (int i = 0; i < this.array_lebewesen.Length; i++)
                {
                    this.array_lebewesen[i].zeichne();
                    this.array_lebewesen[i].bewegen();

                    if (this.array_lebewesen[i].getPos_x() > this.ziel_x_pos)
                    {
                        Console.Beep();
                        this.running = false;
                        break;
                    }
                }

                this.leaderboard();

                Thread.Sleep(this.game_speed);

            }
        }

        private void erzeugeLebewesen()
        {
            this.array_lebewesen = new Lebewesen[this.anzahl];

            for (int i = 0; i < this.array_lebewesen.Length; i++)
            {
                if (i % 2 == 0)
                    this.array_lebewesen[i] = new Mensch(0f, i * 2.0f);
                else
                    this.array_lebewesen[i] = new Tier(0f, i * 2.0f);

                this.array_lebewesen[i].bahn_nr = i + 1;

                // Prüfe, ob das Lebewesen ein Mensch ist, und rufe dann mensch.zeichne() auf
                if (this.array_lebewesen[i] is Mensch mensch)
                {
                    mensch.zeichne(); // Nur wenn es ein Mensch ist, rufe die Methode auf
                }
            }
        }

        private void leaderboard()
        {
            Lebewesen[] lb_array = sort_Lebewesen_Array_By_XPos( );

            for (int i = 0; i < lb_array.Length; i++)
            {
                Console.SetCursorPosition(0, 2 + (this.anzahl * 2) + i);
                Console.Write("#" + (i + 1) + ": Bahn " + lb_array[i].bahn_nr + " ");
            }
        }

        private Lebewesen[] sort_Lebewesen_Array_By_XPos( )
        {
            Lebewesen[] new_lw_array = new Lebewesen[this.array_lebewesen.Length];

            this.array_lebewesen.CopyTo(new_lw_array, 0);

            // bubble sort
            for (int x = 0; x < new_lw_array.Length; x++)
            {
                for (int y = 0; y < new_lw_array.Length - 1; y++)
                {
                    if (new_lw_array[y + 1].getPos_x() > new_lw_array[y].getPos_x())
                    {
                        Lebewesen tmp_lw = new_lw_array[y];
                        new_lw_array[y] = new_lw_array[y + 1];
                        new_lw_array[y + 1] = tmp_lw;
                    }
                }
            }

            return new_lw_array;
        }



    }
}
