using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Race_Interface
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Race my_race = new Race();

            Race_Element my_auto = new Auto("BrumBrum");
            my_race.addElementToRace(my_auto);

            Mensch m1 = new Mensch("Klaus");
            my_race.addElementToRace(m1);

            Auto my_auto2 = new Auto("TütTüt");
            my_race.addElementToRace(my_auto2);

            Mensch m2 = new Mensch("Gabi");
            my_race.addElementToRace(m2);

            my_race.init();

            my_race.start();

            Console.ReadKey();
        }
    }
}
