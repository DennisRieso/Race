using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Rennen
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Race my_race = new Race();
            my_race.start();

            Console.ReadKey();

        }
    }
}
