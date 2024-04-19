using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Race_Interface
{

    // Welche Informationen brauchen wir von einem Objekt das bei Rennen dabei sein soll!!
    // - Symbol
    // - x_pos
    // - muss sich bewegen können
    interface Race_Element
    {
        char getSymbol();
        int getPos_x();
        string getName();
        void move();
    }



    internal class Race
    {
        private int             game_speed      = 1000 / 10;
        private int             anzahl          = 8; // Maximal nur 12 Teilnehmer!!!!!
        // Lebewesen in Array speichern
        private Race_Element[]  array_elements  = null;
        private bool            running         = false;

        private int             ziel_x_pos      = 80;
        private int             elem_count      = 0;

        public Race() 
        {
            this.anzahl = 8;
            this.erzeugeLebewesen();
        }

        public void init()
        {
            Console.Clear();
            Console.CursorVisible = false;

            this.zeichneSpielfeld();
        }

        private void zeichneSpielfeld()
        {
            // die grenzen zwischen den bahnen
            for (int i = 0; i < this.elem_count; i++)
            {
                Console.SetCursorPosition(0, i * 2 + 1 );
                Console.WriteLine(new string('-' , this.ziel_x_pos ) );
            }
            // zeichne ziellinie
            for (int i = 0; i < this.elem_count * 2 ; i++)
            {
                Console.SetCursorPosition( this.ziel_x_pos - 1 , i );
                Console.WriteLine('|');
            }
        }

        public void start()
        {
            this.running = true;
            int ziel_counter = 0;
            while (this.running)
            {
                ziel_counter = 0;
                for (int i = 0; i < this.elem_count; i++)
                {
                    Console.SetCursorPosition(this.array_elements[i].getPos_x(), i * 2);
                    Console.Write(this.array_elements[i].getSymbol() );

                    // überschreiben der alten position mit einem leerzeichen
                    if(this.array_elements[i].getPos_x() > 0)
                    {
                        Console.SetCursorPosition(this.array_elements[i].getPos_x() - 1, i * 2);
                        Console.Write(" ");
                    }

                    if (this.array_elements[i].getPos_x() >= this.ziel_x_pos)
                    {
                        ziel_counter++;
                        Console.Beep();
                      
                    }
                    else
                        this.array_elements[i].move();

                }

                if (ziel_counter >= this.elem_count)
                {
                    Console.WriteLine("ENDE");
                    this.running = false;
                }

                this.leaderboard();

                Thread.Sleep(this.game_speed);

            }
        }

        private void erzeugeLebewesen()
        {
            this.array_elements = new Race_Element[this.anzahl];
        }

        public void addElementToRace( Race_Element in_element )
        {
            for( int x = 0; x < this.array_elements.Length; x++ )
            {
                if (this.array_elements[x] == null)
                {
                    this.array_elements[x] = in_element;
                    this.elem_count = x + 1;
                    return;
                }
            }
            Console.WriteLine("Das Rennen ist schon voll belegt!");
        }

        private void leaderboard()
        {
            Race_Element[] lb_array = sort_Lebewesen_Array_By_XPos( );

            for (int i = 0; i < this.elem_count; i++)
            {
                Console.SetCursorPosition(0, 2 + (this.elem_count * 2) + i);
                Console.Write("#" + (i + 1) + ": " + lb_array[i].getName() + " ");
            }
        }

        private Race_Element[] sort_Lebewesen_Array_By_XPos( )
        {
            Race_Element[] new_lw_array = new Race_Element[this.array_elements.Length];

            this.array_elements.CopyTo(new_lw_array, 0);

            // bubble sort
            for (int x = 0; x < this.elem_count; x++)
            {
                for (int y = 0; y < this.elem_count - 1; y++)
                {
                    if (new_lw_array[y + 1].getPos_x() > new_lw_array[y].getPos_x())
                    {
                        Race_Element tmp_lw = new_lw_array[y];
                        new_lw_array[y] = new_lw_array[y + 1];
                        new_lw_array[y + 1] = tmp_lw;
                    }
                }
            }

            return new_lw_array;
        }



    }
}
