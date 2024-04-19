using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Race_Interface
{
    internal class Auto : Race_Element
    {
        int     ps;
        int     km_stand;
        int     baujahr;
        string  marke;
        string  farbe;

        string name;

        public Auto( string in_name)
        {
            this.ps         = 1;
            this.km_stand   = 0;
            this.baujahr    = 1970;
            this.name       = in_name;
        }

        public string getName()
        {
            return this.name;
        }

        public int getPos_x()
        {
            return this.km_stand;
        }

        public char getSymbol()
        {
            return 'A';
        }

        public void move()
        {
            this.km_stand += this.ps;
        }
    }
}
